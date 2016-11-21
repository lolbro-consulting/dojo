using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
   public class InvestmentOption
    {
        private string holdingType;
        private string cusipNumber;
        private string description;
        private string isin;
        private string id;
        private string priceAsOfDate;
        private HistoricReturns historicReturns;
        private Price price;
        private string sedol;
        private string symbol;

        public HistoricReturns HistoricReturns
        {
            get { return historicReturns; }
            set { historicReturns = value; }
        }

        public string PriceAsOfDate
        {
            get { return priceAsOfDate; }
            set { priceAsOfDate = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
       

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public string Sedol
        {
            get { return sedol; }
            set { sedol = value; }
        }

        public Price Price
        {
            get { return price; }
            set { price = value; }
        }

       

        public string Isin
        {
            get { return isin; }
            set { isin = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string CusipNumber
        {
            get { return cusipNumber; }
            set { cusipNumber = value; }
        }

        public string HoldingType
        {
            get { return holdingType; }
            set { holdingType = value; }
        }
    }
}
