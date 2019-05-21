using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
            // check authentication
            string userName = Request.Headers["username"];
            string password = Request.Headers["password"];
            var user = db.User.Where(item => item.UserName == userName).First();
            PasswordHasher<User> hasher = new PasswordHasher<User>(
      new OptionsWrapper<PasswordHasherOptions>(
          new PasswordHasherOptions()
          {
              CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
          })
  );
            if(hasher.VerifyHashedPassword(user,user.PasswordHash,password) != PasswordVerificationResult.Failed)
            {
                action.IsDone = false;
                action.Type = 1;// call
                db.Action.Add(action);
                var rs = db.SaveChanges();
                if (rs > 0)
                {
                    return Json(true);
                }
                return Json(false);
            }
            return Json(new { Message = "User name and password is not correct" });
        }
    }
}