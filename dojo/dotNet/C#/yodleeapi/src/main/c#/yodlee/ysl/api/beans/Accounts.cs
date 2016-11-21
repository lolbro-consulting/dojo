using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Accounts
    {
        public List<Account> account { get; set; }//getting all the deserialized value for variables declaired in Account class
        public string ToString()
        {
            StringBuilder accounts = new StringBuilder("");
            if (account == null)
                return accounts.ToString();
            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].InvestmentPlan != null)
                {
                    if (account[i].InvestmentPlan.InvestmentOption != null)
                    {
                        for (int j = 0; j < account[i].InvestmentPlan.InvestmentOption.Count(); j++)
                        {
                            string description = "NA";
                            if (account[i].InvestmentPlan.InvestmentOption[j].CusipNumber != null)
                                description = account[i].InvestmentPlan.InvestmentOption[j].Description;
                            string cusipNo = "NA";
                            if (account[i].InvestmentPlan.InvestmentOption[j].CusipNumber != null)
                                cusipNo = account[i].InvestmentPlan.InvestmentOption[j].CusipNumber;
                            string holdingType = "NA";
                            if (account[i].InvestmentPlan.InvestmentOption[j].HoldingType != null)
                                holdingType = account[i].InvestmentPlan.InvestmentOption[j].HoldingType;
                            string price = "NA";
                            if (account[i].InvestmentPlan.InvestmentOption[j].Price != null)
                                price = account[i].InvestmentPlan.InvestmentOption[j].Price.amount;

                            accounts.Append(account[i].getId().PadRight(12, '-')).Append(" ").Append(account[i].InvestmentPlan.PlanName.PadRight(15, '-')).Append(account[i].InvestmentPlan.ProviderName.PadRight(15, '-')).Append(" ").Append(cusipNo.PadRight(12, '-')).Append(description.PadRight(12, '-')).Append(holdingType.PadRight(12, '-')).Append(price.PadRight(20, '-')).Append("\n");
                        }
                    }
                }
                else
                    accounts.Append(account[i].getId().PadRight(12,'-')).Append(" ").Append(account[i].getAccountName()).Append("\n");
            }
            return accounts.ToString();
        }

    }
}