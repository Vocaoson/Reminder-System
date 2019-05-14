using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Models;

namespace DataAccess.Models
{
    public class ReminderSystemContext : DbContext
    {
        public ReminderSystemContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("Server=localhost;Database=remindersystem;User=root;Password=;");
        }

        public ReminderSystemContext(DbContextOptions<ReminderSystemContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Sentence> Sentence { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
