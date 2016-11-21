using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    /// <summary>
    /// This Class Contains variables for Refresh status
    /// </summary>
    class siteaccountId
    {
        public Int64 siteAccountId { get; set; }
        public Int64 code { get; set; }
        public string siteAddStatus { get; set; }
        public string siteRefreshStatus { get; set; }
        public Int64 nextUpdate { get; set; }

    }
}
