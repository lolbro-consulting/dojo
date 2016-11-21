using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Account
    {
        public String CONTAINER{get;set;}
        public String accountName { get; set; }
        public String accountNumber { get; set; }
        public String isAsset { get; set; }
        public Price balance { get; set; }
        public String currency { get; set; }
        public String errorCode { get; set; }
        public String id { get; set; }
        public string lastUpdated { get; set; }
        public String nickname { get; set; }
        public String status { get; set; }
        public Price availableBalance { get; set; }
        public Price currentBalance { get; set; }
        public String type { get; set; }
        public String classification { get; set; }
        public String routingNumber { get; set; }
        public Price amountDue { get; set; }
        public String apr { get; set; }
        public Price availableCash { get; set; }
        public Price availableCredit { get; set; }
        public string dueDate { get; set; }
        public string lastPaymentDate { get; set; }
        public Price lastPaymentAmount { get; set; }
        public Price minimumAmountDue { get; set; }
        public Price runningBalance { get; set; }
        public Price availableLoan { get; set; }
        public Price _401kLoan { get; set; }
        public Price cash { get; set; }
        public string maturityDate { get; set; }
        public String term { get; set; }
        public String enrollmentDate { get; set; }
        public String primaryRewardUnit { get; set; }
        private InvestmentPlan investmentPlan;
        private Value value;
        private string accountStatus;
        private string providerId;
        private string providerName;
        private string accountType;
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
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

        public string AccountStatus
        {
            get { return accountStatus; }
            set { accountStatus = value; }
        }

        public Value Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public InvestmentPlan InvestmentPlan
        {
            get { return investmentPlan; }
            set { investmentPlan = value; }
        }

        public String getCONTAINER()
        {
            return CONTAINER;
        }

        public void setCONTAINER(String cONTAINER)
        {
            CONTAINER = cONTAINER;
        }

        public String getAccountName()
        {
            return accountName;
        }

        public void setAccountName(String accountName)
        {
            this.accountName = accountName;
        }

        public String getAccountNumber()
        {
            return accountNumber;
        }

        public void setAccountNumber(String accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public String getIsAsset()
        {
            return isAsset;
        }

        public void setIsAsset(String isAsset)
        {
            this.isAsset = isAsset;
        }

        public Price getBalance()
        {
            return balance;
        }

        public void setBalance(Price balance)
        {
            this.balance = balance;
        }

        public String getCurrency()
        {
            return currency;
        }

        public void setCurrency(String currency)
        {
            this.currency = currency;
        }

        public String getErrorCode()
        {
            return errorCode;
        }

        public void setErrorCode(String errorCode)
        {
            this.errorCode = errorCode;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public string getLastUpdated()
        {
            return lastUpdated;
        }

        public void setLastUpdated(string lastUpdated)
        {
            this.lastUpdated = lastUpdated;
        }

        public String getNickname()
        {
            return nickname;
        }

        public void setNickname(String nickname)
        {
            this.nickname = nickname;
        }

        public String getStatus()
        {
            return status;
        }

        public void setStatus(String status)
        {
            this.status = status;
        }

        public Price getAvailableBalance()
        {
            return availableBalance;
        }

        public void setAvailableBalance(Price availableBalance)
        {
            this.availableBalance = availableBalance;
        }

        public Price getCurrentBalance()
        {
            return currentBalance;
        }

        public void setCurrentBalance(Price currentBalance)
        {
            this.currentBalance = currentBalance;
        }

        public String getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getClassification()
        {
            return classification;
        }

        public void setClassification(String classification)
        {
            this.classification = classification;
        }

        public String getRoutingNumber()
        {
            return routingNumber;
        }

        public void setRoutingNumber(String routingNumber)
        {
            this.routingNumber = routingNumber;
        }

        public Price getAmountDue()
        {
            return amountDue;
        }

        public void setAmountDue(Price amountDue)
        {
            this.amountDue = amountDue;
        }

        public String getApr()
        {
            return apr;
        }

        public void setApr(String apr)
        {
            this.apr = apr;
        }

        public Price getAvailableCash()
        {
            return availableCash;
        }

        public void setAvailableCash(Price availableCash)
        {
            this.availableCash = availableCash;
        }

        public Price getAvailableCredit()
        {
            return availableCredit;
        }

        public void setAvailableCredit(Price availableCredit)
        {
            this.availableCredit = availableCredit;
        }

        public string getDueDate()
        {
            return dueDate;
        }

        public void setDueDate(string dueDate)
        {
            this.dueDate = dueDate;
        }

        public string getLastPaymentDate()
        {
            return lastPaymentDate;
        }

        public void setLastPaymentDate(string lastPaymentDate)
        {
            this.lastPaymentDate = lastPaymentDate;
        }

        public Price getLastPaymentAmount()
        {
            return lastPaymentAmount;
        }

        public void setLastPaymentAmount(Price lastPaymentAmount)
        {
            this.lastPaymentAmount = lastPaymentAmount;
        }

        public Price getMinimumAmountDue()
        {
            return minimumAmountDue;
        }

        public void setMinimumAmountDue(Price minimumAmountDue)
        {
            this.minimumAmountDue = minimumAmountDue;
        }

        public Price getRunningBalance()
        {
            return runningBalance;
        }

        public void setRunningBalance(Price runningBalance)
        {
            this.runningBalance = runningBalance;
        }

        public Price getAvailableLoan()
        {
            return availableLoan;
        }

        public void setAvailableLoan(Price availableLoan)
        {
            this.availableLoan = availableLoan;
        }

        public Price get_401kLoan()
        {
            return _401kLoan;
        }

        public void set_401kLoan(Price _401kLoan)
        {
            this._401kLoan = _401kLoan;
        }

  

        public Price getCash()
        {
            return cash;
        }

        public void setCash(Price cash)
        {
            this.cash = cash;
        }

  
        public string getMaturityDate()
        {
            return maturityDate;
        }

        public void setMaturityDate(string maturityDate)
        {
            this.maturityDate = maturityDate;
        }

        public String getTerm()
        {
            return term;
        }

        public void setTerm(String term)
        {
            this.term = term;
        }

  
        public String getEnrollmentDate()
        {
            return enrollmentDate;
        }

        public void setEnrollmentDate(String enrollmentDate)
        {
            this.enrollmentDate = enrollmentDate;
        }

        public String getPrimaryRewardUnit()
        {
            return primaryRewardUnit;
        }

        public void setPrimaryRewardUnit(String primaryRewardUnit)
        {
            this.primaryRewardUnit = primaryRewardUnit;
        }

       
    }
}