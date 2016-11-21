using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Option
    {

        public string optionValue;
        public string displayText;
        public virtual string OptionValue
        {
            get
            {
                return optionValue;
            }
            set
            {
                this.optionValue = value;
            }
        }
        public virtual string DisplayText
        {
            get
            {
                return displayText;
            }
            set
            {
                this.displayText = value;
            }
        }


    }
}
