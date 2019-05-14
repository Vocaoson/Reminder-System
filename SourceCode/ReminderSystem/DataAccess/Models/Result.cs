using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string ResultData { get; set; }
        public bool? IsSend { get; set; }
        public int? ActionId { get; set; }

        [ForeignKey("ActionId")]
        public Action Action { get; set; }
    }
}
