using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappReminder.Models
{
    public class Config
    {
        public string AudioPath { get; set; }
        public string Trunk { get; set; }
        public string AsteriskIp { get; set; }
        public int AsteriskPort { get; set; }
        public string AsteriskUserName { get; set; }
        public string AsteriskPassword { get; set; }
    }
}
