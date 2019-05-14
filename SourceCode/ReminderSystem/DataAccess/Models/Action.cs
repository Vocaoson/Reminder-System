using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Action
    {
        public Action()
        {

        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int? TemplateId { get; set; }
        public string Data { get; set; }
        public bool? IsDone { get; set; }
        public int Type { get; set; }

        [ForeignKey("TemplateId")]
        public Template Template { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}
