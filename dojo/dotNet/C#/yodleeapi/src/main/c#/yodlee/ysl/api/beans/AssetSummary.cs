using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class AssetSummary
    {
        private string classificationType;
        private Account[] account;

        public Account[] Account
        {
            get { return account; }
            set { account = value; }
        }

        public string ClassificationType
        {
            get { return classificationType; }
            set { classificationType = value; }
        }
        private string classificationValue;

        public string ClassificationValue
        {
            get { return classificationValue; }
            set { classificationValue = value; }
        }
        private string contribution;

        public string Contribution
        {
            get { return contribution; }
            set { contribution = value; }
        }
        private Value value;

        public Value Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private SummaryHolding[] holding;

        public SummaryHolding[] Holding
        {
            get { return holding; }
            set { holding = value; }
        }

        
    }
}
