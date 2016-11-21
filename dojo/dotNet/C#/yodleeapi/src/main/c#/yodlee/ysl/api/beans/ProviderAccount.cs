using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    class ProviderAccount
    {
        public RefreshStatus providerAccount { get; set; }
        //public String id;
        //public RefreshInfo refreshInfo;
        //public LoginForm loginForm;

        //public LoginForm getLoginForm()
        //{
        //    return loginForm;
        //}
        //public void setLoginForm(LoginForm loginForm)
        //{
        //    this.loginForm = loginForm;
        //}
        //public String getId()
        //{
        //    return id;
        //}
        //public void setProviderAccountId(String id)
        //{
        //    this.id = id;
        //}
        //public RefreshInfo getRefreshInfo()
        //{
        //    return refreshInfo;
        //}
        //public void setRefreshInfo(RefreshInfo refreshInfo)
        //{
        //    this.refreshInfo = refreshInfo;
        //}

        public String toString()
        {
            StringBuilder pAccount = new StringBuilder("");
            pAccount.Append(providerAccount);
            return providerAccount.ToString();
        }
    }
}
