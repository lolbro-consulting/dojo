using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    class RefreshInfo
    {
        public string refreshStatus;
        public string status;
        public string additionalStatus;
        public String statusCode;
        public String statusMessage;
        public String lastRefreshed;
        public String lastRefreshAttempt;
        public String nextRefreshScheduled;
        public String getStatusCode()
        {
            return statusCode;
        }
        public void setStatusCode(String statusCode)
        {
            this.statusCode = statusCode;
        }


        public String getadditionalStatus()
        {
            return additionalStatus;
        }
        public void setadditionalStatus(String additionalStatus)
        {
            this.additionalStatus = additionalStatus;
        }

        public String getrefreshStatus()
        {
            return refreshStatus;
        }
        public void setrefreshStatus(String refreshStatus)
        {
            this.refreshStatus = refreshStatus;
        }

        public String getStatus()
        {
            return status;
        }
        public void setStatus(String status)
        {
            this.status = status;
        }

        public String getStatusMessage()
        {
            return statusMessage;
        }
        public void setStatusMessage(String statusMessage)
        {
            this.statusMessage = statusMessage;
        }
        public String getLastRefreshed()
        {
            return lastRefreshed;
        }
        public void setLastRefreshed(String lastRefreshed)
        {
            this.lastRefreshed = lastRefreshed;
        }
        public String getLastRefreshAttempt()
        {
            return lastRefreshAttempt;
        }
        public void setLastRefreshAttempt(String lastRefreshAttempt)
        {
            this.lastRefreshAttempt = lastRefreshAttempt;
        }
        public String getNextRefreshScheduled()
        {
            return nextRefreshScheduled;
        }
        public void setNextRefreshScheduled(String nextRefreshScheduled)
        {
            this.nextRefreshScheduled = nextRefreshScheduled;
        }

        public String toString()
        {
            StringBuilder refreshInfo = new StringBuilder("");
            refreshInfo.Append(" => statusCode = " + statusCode).Append(" => statusMessage = " + statusMessage);
            return refreshInfo.ToString();
        }
    }
}
