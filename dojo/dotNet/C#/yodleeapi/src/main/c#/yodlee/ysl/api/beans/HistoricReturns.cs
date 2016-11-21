using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
   public class HistoricReturns
    {
        private string oneMonthReturn;
        private string threeMonthReturn;
        private string oneYearReturn;
        private string threeYearReturn;
        private string fiveYearReturn;
        private string tenYearReturn;

        public string OneMonthReturn
        {
            get { return oneMonthReturn; }
            set { oneMonthReturn = value; }
        }
       

        public string ThreeMonthReturn
        {
            get { return threeMonthReturn; }
            set { threeMonthReturn = value; }
        }

        public string OneYearReturn
        {
            get { return oneYearReturn; }
            set { oneYearReturn = value; }
        }
        

        public string ThreeYearReturn
        {
            get { return threeYearReturn; }
            set { threeYearReturn = value; }
        }
        

        public string FiveYearReturn
        {
            get { return fiveYearReturn; }
            set { fiveYearReturn = value; }
        }
        

        public string TenYearReturn
        {
            get { return tenYearReturn; }
            set { tenYearReturn = value; }
        }
    }
}
