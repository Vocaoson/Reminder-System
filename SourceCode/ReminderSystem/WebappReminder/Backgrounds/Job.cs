using AsteriskConnector;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebappReminder.Data;
using WebappReminder.Models;

namespace WebappReminder.Backgrounds
{
    public class Job
    {
        Asterisk asterisk;
        ApplicationDbContext db;
        IOptions<Config> config;
        public Job(ApplicationDbContext db, IOptions<Config> config)
        {
            this.db = db;
            this.config = config;
            asterisk = new Asterisk(this.config.Value.AsteriskIp, this.config.Value.AsteriskPort, this.config.Value.AsteriskUserName, this.config.Value.AsteriskPassword);
        }
        public void RunAction()
        {
            List<DataAccess.Models.Action> actions = db.Action.ToList();
            var user = db.User.Include(u => u.Template);
            foreach (var action in actions)
            {
                if (action.Type == 1) // call
                {
                    if (action.IsDone == false)
                    {
                        bool actionResult = asterisk.Call(string.Concat(this.config.Value.Trunk,action.PhoneNumber), string.Concat("ActionId=", action.Id)).Result;
                        if (actionResult)
                        {
                            action.IsDone = true;
                            db.SaveChanges();
                        }
                    }
                }
                else if (action.Type == 2) // message
                {

                }

            }
        }
        public void SendDataBack()
        {
            // loop through Result table, if isSend == false => send to linkback 
            // data = {templateId,data,result}
            HttpClient httpClient = new HttpClient();
            var results = db.Result.Include(item => item.Action).ToList();
            foreach (var result in results)
            {
                if (result.IsSend == false)
                {
                    var action = result.Action;
                    var template = db.Template.Where(temp => temp.Id == action.TemplateId).First();
                    // send
                    var values = new Dictionary<string, string>()
                    {
                        {"templateId",template.Id.ToString()},
                        {"data",action.Data },
                        {"result", $"[{result.ResultData}]" }
                    };
                    var content = new FormUrlEncodedContent(values);
                    var rs = httpClient.PostAsync(template.LinkBack, content);
                    result.IsSend = true;
                    db.SaveChanges();
                }
            }


        }
    }
}
