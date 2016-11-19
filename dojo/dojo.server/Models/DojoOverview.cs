using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dojo.server.Models
{
    public class DojoOverview
    {
        public int Score { get; set; }
        public int Target { get; set; }
        public int DaysRemaining { get; set; }
    }
}