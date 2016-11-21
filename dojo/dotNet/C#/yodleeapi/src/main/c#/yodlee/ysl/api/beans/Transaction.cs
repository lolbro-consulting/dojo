using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Transaction
    {

        internal string CONTAINER_Renamed;
        internal string id;
        internal Price amount;
        internal string baseType;
        internal string category;
       // internal string description;
        internal string originalDescription;
        internal string date;
        internal string manual;
        internal string status;
        internal string cusipNumber;
        internal Price price;
        internal string quantity;
        internal string symbol;
        internal string tradeDate;
        internal string accountId;
        public virtual string CONTAINER
        {
            get
            {
                return CONTAINER_Renamed;
            }
            set
            {
                CONTAINER_Renamed = value;
            }
        }
        public virtual string Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }
        public virtual Price Amount
        {
            get
            {
                return amount;
            }
            set
            {
                this.amount = value;
            }
        }
        public virtual string BaseType
        {
            get
            {
                return baseType;
            }
            set
            {
                this.baseType = value;
            }
        }
        public virtual string Category
        {
            get
            {
                return category;
            }
            set
            {
                this.category = value;
            }
        }
        //public virtual string Description
        //{
        //    get
        //    {
        //        return description;
        //    }
        //    set
        //    {
        //        this.description = value;
        //    }
        //}
        public virtual string OriginalDescription
        {
            get
            {
                return originalDescription;
            }
            set
            {
                this.originalDescription = value;
            }
        }
        public virtual string Date
        {
            get
            {
                return date;
            }
            set
            {
                this.date = value;
            }
        }
        public virtual string Manual
        {
            get
            {
                return manual;
            }
            set
            {
                this.manual = value;
            }
        }
        public virtual string Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
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
        public virtual Price Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
            }
        }
        public virtual string Quantity
        {
            get
            {
                return quantity;
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
        public virtual string TradeDate
        {
            get
            {
                return tradeDate;
            }
            set
            {
                this.tradeDate = value;
            }
        }
        public virtual string AccountId
        {
            get
            {
                return accountId;
            }
            set
            {
                this.accountId = value;
            }
        }



    }
}