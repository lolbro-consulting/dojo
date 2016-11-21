using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    class RefreshStatus
    {
        public String providerAccountId;
        public RefreshInfo refreshInfo;
       public LoginForm loginForm;
       public String id;
       public String getId()
       {
           return id;
       }
       public void setLoginForm(String id)
       {
           this.id = id;
       }

        public LoginForm getLoginForm()
        {
            return loginForm;
        }
        public void setLoginForm(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }
        public String getProviderAccountId()
        {
            return providerAccountId;
        }
        public void setProviderAccountId(String providerAccountId)
        {
            this.providerAccountId = providerAccountId;
        }
        public RefreshInfo getRefreshInfo()
        {
            return refreshInfo;
        }
        public void setRefreshInfo(RefreshInfo refreshInfo)
        {
            this.refreshInfo = refreshInfo;
        }

        public String toString()
        {
            StringBuilder refreshStatus = new StringBuilder("");
            refreshStatus.Append("providerAccountId = " + providerAccountId).Append(refreshInfo.toString());
            return refreshStatus.ToString();
        }
    }
}
