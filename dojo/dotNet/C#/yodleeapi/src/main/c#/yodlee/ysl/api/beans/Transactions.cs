using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Transactions
    {
        public List<Transaction> transaction { get; set; }//getting deserialized value for Transaction class
        

        public override string ToString()
        {
            StringBuilder transactions = new StringBuilder("");
            if(transaction==null)
                return transactions.ToString();
            for (int i = 0; i < transaction.Count; i++)
            {
                Price amount = transaction[i].amount;
                String myAmount = "0";
                if (amount != null)
                    myAmount = amount.amount;
                transactions.Append(transaction[i].Id).Append(" ").Append("=>").Append(" ").Append(myAmount).Append(" ").Append("=> " + transaction[i].BaseType).Append("\n");
            }
            return transactions.ToString();
        }
    }
}