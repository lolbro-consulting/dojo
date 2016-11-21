using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Holding
    {

        public Price costBasis;
        private Price price;

        public Price Price
        {
            get { return price; }
            set { price = value; }
        }
        private Value value;

        public Value Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private Price employeeContribution;

        public Price EmployeeContribution
        {
            get { return employeeContribution; }
            set { employeeContribution = value; }
        }
        private Price employerContribution;

        public Price EmployerContribution
        {
            get { return employerContribution; }
            set { employerContribution = value; }
        }
        private string accountId;

        public string AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string contractQuantity;

        public string ContractQuantity
        {
            get { return contractQuantity; }
            set { contractQuantity = value; }
        }
        public string cusipNumber;
        private string couponRate;

        public string CouponRate
        {
            get { return couponRate; }
            set { couponRate = value; }
        }
        private string currencyType;

        public string CurrencyType
        {
            get { return currencyType; }
            set { currencyType = value; }
        }
        private string exercisedQuantity;

        public string ExercisedQuantity
        {
            get { return exercisedQuantity; }
            set { exercisedQuantity = value; }
        }
        private string interestRate;

        public string InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        public string dailyChange;
        public string description;
        public string exchange;
        private String optionType;

        public String OptionType
        {
            get { return optionType; }
            set { optionType = value; }
        }
        private AssetClassification[] assetClassification;

        public AssetClassification[] AssetClassification
        {
            get { return assetClassification; }
            set { assetClassification = value; }
        }

       
        public string holdingType;
        public string isin;
        public string quantity;
        public string symbol;

        public virtual Price CostBasis
        {
            get
            {
                return costBasis;
            }
            set
            {
                this.costBasis = value;
            }
        }
        public virtual string CusipNumber
        {
            get
            {
                return cusipNumber;
            }
            set
            {
                this.cusipNumber = value;
            }
        }
        public virtual string DailyChange
        {
            get
            {
                return dailyChange;
            }
            set
            {
                this.dailyChange = value;
            }
        }
        public virtual string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
            }
        }
        public virtual string Exchange
        {
            get
            {
                return exchange;
            }
            set
            {
                this.exchange = value;
            }
        }
        public virtual string HoldingType
        {
            get
            {
                return holdingType;
            }
            set
            {
                this.holdingType = value;
            }
        }
        public virtual string Isin
        {
            get
            {
                return isin;
            }
            set
            {
                this.isin = value;
            }
        }
      
        public virtual string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
        public virtual string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                this.symbol = value;
            }
        }
        

    }
}