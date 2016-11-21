using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class LoginFormRow
    {

        public String id;
        public String label;
        public String form;
        public String fieldRowChoice;
        public LoginField[] field;// = new[] {LoginField()};
        public String help;
        public String isMfaFieldRow;
        public String rowCriteria;

        public String getIsMfaFieldRow()
        {
            return isMfaFieldRow;
        }
        public void setIsMfaFieldRow(String isMfaFieldRow)
        {
            this.isMfaFieldRow = isMfaFieldRow;
        }
        public String getRowCriteria()
        {
            return rowCriteria;
        }
        public void setRowCriteria(String rowCriteria)
        {
            this.rowCriteria = rowCriteria;
        }


        public String getId()
        {
            return id;
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public String getLabel()
        {
            return label;
        }
        public void setLabel(String label)
        {
            this.label = label;
        }
        public LoginField[] getField()
        {
            return field;
        }
        public void setField(LoginField[] field)
        {
            this.field = field;
        }
        public String getFieldRowChoice()
        {
            return fieldRowChoice;
        }
        public void setFieldRowChoice(String fieldRowChoice)
        {
            this.fieldRowChoice = fieldRowChoice;
        }
        public String getForm()
        {
            return form;
        }
        public void setForm(String form)
        {
            this.form = form;
        }
        public String getHelp()
        {
            return help;
        }
        public void setHelp(String help)
        {
            this.help = help;
        }
    }
}