using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class User: IdentityUser
    {
        public User()
        {   
        }
        //public int Id { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }

        public ICollection<Template> Template { get; set; }
    }
}
