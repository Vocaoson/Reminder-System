using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappReminder.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebappReminder.Models;

namespace WebappReminder.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        ApplicationDbContext db;
        IOptions<Config> config;
        public TemplateController(ApplicationDbContext db, IOptions<Config> config)
        {
            this.db = db;
            this.config = config;

        }
        public IActionResult Index()
        {
            var templates = db.User.Include(item => item.Template).Where(user => user.UserName == this.User.Identity.Name).First().Template.ToList();
            return View(templates);
        }
        public IActionResult Edit(int id)
        {
            Template template = db.Template.Where(temp => temp.Id == id).FirstOrDefault();
            if(template == null)
            {
                return View();
            }
            return View(template);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile audio, Template template)
        {
            if(audio != null && audio.Length == 0)
            {
                //save file

            }
            // edit template
            Template temp = db.Template.Where(item => item.Id == template.Id).FirstOrDefault();
            if(temp == null)
            {

            } else
            {
                temp.Name = template.Name;
                temp.Description = template.Description;
                temp.LinkBack = template.LinkBack;
            }
            return View(temp);
       
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile audio, Template template)
        {
            if (audio == null || audio.Length == 0)
                return Content("file not selected");

            //
            string audioPath = saveFileAudio(template, audio);
            createTemplate(template, audioPath);
            return RedirectToAction("Index");
        }

        private void createTemplate(Template template, string audioPath)
        {
            // get user id
            var userId = db.User.Where(user => user.UserName == this.User.Identity.Name).First().Id;
            // insert template
            template.UserId = userId;
            var rs = db.Template.Add(template);
            // create two sentence
            Sentence sentenceRead = new Sentence()
            {
                Step = 1,
                Type = 1
            };
            // add autio to read sentence
            sentenceRead.Data = new List<DataAccess.Models.Data>()
            {
                new DataAccess.Models.Data(){ DataStore = audioPath, Order = 1, DataType = 2}
            };
            template.Sentence = new List<Sentence>();
            template.Sentence.Add(sentenceRead);
            Sentence sentenceWrite = new Sentence()
            {
                Step = 2,
                Type = 2
            };
            template.Sentence.Add(sentenceWrite);
            db.SaveChanges();

        }
        private string saveFileAudio(Template template, IFormFile audio)
        {
            var audioPath = config.Value.AudioPath;
            if (!Directory.Exists(Path.Combine(audioPath, template.Id.ToString())))
            {
                var dir = Directory.CreateDirectory(Path.Combine(audioPath, template.Id.ToString()));
                audioPath = dir.FullName;
            }
            var path = Path.Combine(audioPath, audio.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                audio.CopyToAsync(stream);
            }
            return path;
        }

    }
}