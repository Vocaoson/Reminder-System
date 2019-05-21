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
            // edit template
            Template temp = db.Template.Where(item => item.Id == template.Id).Include(item => item.Sentence).FirstOrDefault();
            if(temp != null)
            {
                if (audio != null && audio.Length != 0)
                {
                    //save new file
                    var userId = db.User.Where(user => user.UserName == this.User.Identity.Name).First().Id;
                    string fileNameRandom = RandomString(10);
                    saveFileAudio(template, audio, userId, fileNameRandom);
                                    // get sentence read
                Sentence readSentence = temp.Sentence.First();
                // get data from read sentence, now, we just have only one row data is the audio name
                DataAccess.Models.Data data = db.Data.Where(item => item.SentenceId == readSentence.Id).First();
                data.DataStore = fileNameRandom;
                }
                // 
                temp.Name = template.Name;
                temp.Description = template.Description;
                temp.LinkBack = template.LinkBack;
                db.SaveChanges();
                ViewBag.isSucceeded = true;
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
            var userId = db.User.Where(user => user.UserName == this.User.Identity.Name).First().Id;
            string fileNameRandom = RandomString(10);
            createTemplate(template, fileNameRandom);
            saveFileAudio(template, audio, userId, fileNameRandom);
            return RedirectToAction("Index");
        }
        private void createTemplate(Template template, string fileNameRandom)
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
                new DataAccess.Models.Data(){ DataStore = fileNameRandom, Order = 1, DataType = 2}
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
        private void saveFileAudio(Template template, IFormFile audio, string userId, string fileNameRandom)
        {
            var audioPath = config.Value.AudioPath;
            FileInfo fileInfo = new FileInfo(audio.FileName);
            if (!Directory.Exists(Path.Combine(audioPath, userId)))
            {
                var dir = Directory.CreateDirectory(Path.Combine(audioPath, userId));
            }
            var path = Path.Combine(audioPath, userId, string.Concat(fileNameRandom, fileInfo.Extension));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                 audio.CopyToAsync(stream);
            }
        }

        public IActionResult Delete(int id)
        {
            Template temp = db.Template.Where(item => item.Id == id).Include(item => item.Sentence).FirstOrDefault();
            db.Template.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}