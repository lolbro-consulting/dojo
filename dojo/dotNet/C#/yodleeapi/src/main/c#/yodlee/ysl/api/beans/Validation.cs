using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Validation
    {

        public string regExp;
        public string errorMsg;
        public virtual string RegExp
        {
            get
            {
                return regExp;
            }
            set
            {
                this.regExp = value;
            }
        }
        public virtual string ErrorMsg
        {
            get
            {
                return errorMsg;
            }
            set
            {
                this.errorMsg = value;
            }
        }



    }
}
