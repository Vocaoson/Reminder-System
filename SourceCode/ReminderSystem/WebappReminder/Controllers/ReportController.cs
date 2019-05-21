using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebappReminder.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWeekReport()
        {
            return Json(new List<int>() { 12, 31, 22, 17, 25, 18, 29, 14, 9 });
        }
    }
}