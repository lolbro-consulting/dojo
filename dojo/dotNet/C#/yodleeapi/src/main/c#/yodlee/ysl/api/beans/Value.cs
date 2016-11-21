using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class Value
    {
        public String amount { get; set; }
        public String currency { get; set; }

        public String getamount()
        {
            return amount;
        }

        public void setamount(String amount)
        {
            this.amount = amount;
        }

        public String getcurrency()
        {
            return currency;
        }

        public void setcurrency(String currency)
        {
            this.currency = currency;
        }

        

    }
}
