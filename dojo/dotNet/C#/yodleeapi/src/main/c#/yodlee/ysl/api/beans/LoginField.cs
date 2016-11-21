using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class LoginField
    {
        public String id;
        public String name;
        public String type;
        public String value;
        public String size;
        public Boolean IsOptional;
        public String valueEditable { get; set; }
        public int maxLength;
        public String required;
        public Option[] option;
        public Validation[] validation;
        public String prefix;
        public String suffix;
        public String image;


        public Boolean isOptional()
        {
            return IsOptional;
        }
        public void setOptional(Boolean IsOptional)
        {
            this.IsOptional = IsOptional;
        }
        //public Boolean isValueEditable()
        //{
        //    return valueEditable;
        //}
        //public void setValueEditable(Boolean valueEditable)
        //{
        //    this.valueEditable = valueEditable;
        //}
        public String getImage()
        {
            return image;
        }
        public void setImage(String image)
        {
            this.image = image;
        }


        public String getId()
        {
            return id;
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getType()
        {
            return type;
        }
        public void setType(String type)
        {
            this.type = type;
        }
        public String getSize()
        {
            return size;
        }
        public void setSize(String size)
        {
            this.size = size;
        }
        public int getMaxLength()
        {
            return maxLength;
        }
        public void setMaxLength(int maxLength)
        {
            this.maxLength = maxLength;
        }
        public String getRequired()
        {
            return required;
        }
        public void setRequired(String required)
        {
            this.required = required;
        }
        public Option[] getOption()
        {
            return option;
        }
        public void setOption(Option[] option)
        {
            this.option = option;
        }
        public Validation[] getValidation()
        {
            return validation;
        }
        public void setValidation(Validation[] validation)
        {
            this.validation = validation;
        }
        public String getValue()
        {
            return value;
        }
        public void setValue(String value)
        {
            this.value = value;
        }

        public String getPrefix()
        {
            return prefix;
        }
        public void setPrefix(String prefix)
        {
            this.prefix = prefix;
        }
        public String getSuffix()
        {
            return suffix;
        }
        public void setSuffix(String suffix)
        {
            this.suffix = suffix;
        }


    }
}