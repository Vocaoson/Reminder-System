using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Template
    {
        public Template()
        {
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Link back")]
        public string LinkBack { get; set; }
        public string DataBackTemplate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual ICollection<Action> Action { get; set; }
        public virtual ICollection<Sentence> Sentence { get; set; }
    }
}
