using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Sentence
    {
        public Sentence()
        {
        }

        public int Id { get; set; }
        public int? TemplateId { get; set; }
        public int? Step { get; set; }
        public int? Type { get; set; }
        [ForeignKey("TemplateId")]
        public Template Template { get; set; }
        public ICollection<Data> Data { get; set; }
    }
}
