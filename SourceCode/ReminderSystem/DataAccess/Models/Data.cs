using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string DataStore { get; set; }
        public int? DataType { get; set; }
        public int? Order { get; set; }
        public int? SentenceId { get; set; }

        [ForeignKey("SentenceId")]
        public Sentence Sentence { get; set; }
    }
}
