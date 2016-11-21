using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
   public  class AssetClassification
    {
        private string allocation;

        public string Allocation
        {
            get { return allocation; }
            set { allocation = value; }
        }
        private String classificationType;

        public String ClassificationType
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
    }
}
