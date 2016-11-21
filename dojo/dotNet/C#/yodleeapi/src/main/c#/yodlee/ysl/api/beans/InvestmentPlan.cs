using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class InvestmentPlan
    {
        public string lastUpdated;
        public string providerId;
        private string providerName;
        private string asofDate;

        public string AsofDate
        {
            get { return asofDate; }
            set { asofDate = value; }
        }
        private string planName;

        public string PlanName
        {
            get { return planName; }
            set { planName = value; }
        }
        private string planNumber;

        public string PlanNumber
        {
            get { return planNumber; }
            set { planNumber = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private InvestmentOption[] investmentOption;

        public InvestmentOption[] InvestmentOption
        {
            get { return investmentOption; }
            set { investmentOption = value; }
        }
       

        

        

        

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        public string ProviderId
        {
            get { return providerId; }
            set { providerId = value; }
        }

        public string LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }

    }
}
