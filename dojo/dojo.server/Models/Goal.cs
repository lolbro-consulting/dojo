using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dojo.server.Models
{
    public class Goal
    {
        public int Points { get; set; }
        public int Target { get; set; }
        public string Reason { get; set; }
    }
}