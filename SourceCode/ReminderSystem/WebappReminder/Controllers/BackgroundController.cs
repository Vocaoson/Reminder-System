using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteriskConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappReminder.Data;

namespace WebappReminder.Controllers
{
    public class BackgroundController : Controller
    {
        ApplicationDbContext db;
        Asterisk asterisk;
        public BackgroundController(ApplicationDbContext context)
        {
            this.db = context;
            asterisk = new Asterisk("192.168.137.129", 5038, "son", "123456");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RunAction()
        {
            List<DataAccess.Models.Action> actions = db.Action.ToList();
            var user = db.User.Include(u => u.Template);
            foreach (var action in actions)
            {
                if (action.Type == 1) // call
                {
                    if (action.IsDone == false)
                    {
                        bool actionResult = asterisk.Call(action.PhoneNumber, string.Concat("ActionId=", action.Id)).Result;
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
            return Json(true);
        }
    }
}