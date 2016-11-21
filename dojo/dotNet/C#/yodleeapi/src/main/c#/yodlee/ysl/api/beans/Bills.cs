using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace yodlee.ysl.api.beans
{

    public class Bills
    {
        public List<Bill> bill { get; set; }//getting desirialized value for variables present in bill class
       
        public override string ToString()
        {
            StringBuilder bills = new StringBuilder("");
            if (bill == null)
                return bills.ToString();
            for (int i = 0; i < bill.Count; i++)
            {
                bills.Append(bill[i].id).Append(" ").Append("=>").Append(" ").Append(bill[i].dueAmount).Append("\n");
            }
            return bills.ToString();
        }

    }
}