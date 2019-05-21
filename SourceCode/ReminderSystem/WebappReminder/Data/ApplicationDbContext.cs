using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebappReminder.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext() { }
        public virtual DbSet<DataAccess.Models.Action> Action { get; set; }
        public virtual DbSet<DataAccess.Models.Data> Data { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Sentence> Sentence { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<DataAccess.Models.Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
