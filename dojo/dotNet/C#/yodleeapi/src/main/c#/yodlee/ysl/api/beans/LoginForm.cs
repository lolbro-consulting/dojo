using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class LoginForm
    {

        public String id;
        public String help;
        public String forgetPasswordURL;
        public String helpTitle;
        public String mfaInfo;
        public String mfaInfoTitle;
        public String formType;
        public Int64 mfaTimeout;
        public LoginFormRow[] row;



        public String getId()
        {
            return id;
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public String getHelp()
        {
            return help;
        }
        public void setHelp(String help)
        {
            this.help = help;
        }
        public String getForgetPasswordURL()
        {
            return forgetPasswordURL;
        }
        public void setForgetPasswordURL(String forgetPasswordURL)
        {
            this.forgetPasswordURL = forgetPasswordURL;
        }
        public LoginFormRow[] getRow()
        {
            return row;
        }
        public void setRow(LoginFormRow[] row)
        {
            this.row = row;
        }
        public String getHelpTitle()
        {
            return helpTitle;
        }
        public void setHelpTitle(String helpTitle)
        {
            this.helpTitle = helpTitle;
        }
        public String getMfaInfo()
        {
            return mfaInfo;
        }
        public void setMfaInfo(String mfaInfo)
        {
            this.mfaInfo = mfaInfo;
        }
        public String getMfaInfoTitle()
        {
            return mfaInfoTitle;
        }
        public void setMfaInfoTitle(String mfaInfoTitle)
        {
            this.mfaInfoTitle = mfaInfoTitle;
        }
        public String getFormType()
        {
            return formType;
        }
        public void setFormType(String formType)
        {
            this.formType = formType;
        }
        //public String getMfaTimeout()
        //{
        //    return mfaTimeout;
        //}
        //public void setMfaTimeout(String mfaTimeout)
        //{
        //    this.mfaTimeout = mfaTimeout;
        //}

    }
}