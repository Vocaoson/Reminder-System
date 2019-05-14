using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebappReminder.Data;

namespace WebappReminder.Controllers
{
    public class ApiController : Controller
    {
        ApplicationDbContext db;
        public ApiController(ApplicationDbContext context)
        {
            this.db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Call([FromBody]DataAccess.Models.Action action)
        {
            action.IsDone = false;
            db.Action.Add(action);
            var rs = db.SaveChanges();
            if (rs > 0)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}