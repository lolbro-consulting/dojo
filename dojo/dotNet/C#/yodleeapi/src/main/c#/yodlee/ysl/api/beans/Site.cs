using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class Site
    {
        public long id;
        public string name;
        public string nameWithCountry;
        public string loginUrl;
        public string baseUrl;
        public sbyte[] favicon;
        public sbyte[] logo;
        public string status;
        public string[] containerNames;
        public string mfaType;
        public string help;
        public string primaryLanguageISOCode;
        public string countryISOCode;
        public string oAuthSite;
        public LocalizedSiteAttributes[] localizedSiteAttributes;
        public string lastModified;
        public string forgetPasswordUrl;
        public string loginHelp;
        public LoginForm loginForm;
        public string availableFrom;
        public virtual long Id
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
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public virtual string NameWithCountry
        {
            get
            {
                return nameWithCountry;
            }
            set
            {
                this.nameWithCountry = value;
            }
        }
        public virtual string LoginUrl
        {
            get
            {
                return loginUrl;
            }
            set
            {
                this.loginUrl = value;
            }
        }
        public virtual string BaseUrl
        {
            get
            {
                return baseUrl;
            }
            set
            {
                this.baseUrl = value;
            }
        }
        public virtual LoginForm LoginForm
        {
            get
            {
                return loginForm;
            }
            set
            {
                this.loginForm = value;
            }
        }
        public virtual sbyte[] Favicon
        {
            get
            {
                return favicon;
            }
            set
            {
                this.favicon = value;
            }
        }
        public virtual sbyte[] Logo
        {
            get
            {
                return logo;
            }
            set
            {
                this.logo = value;
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
        public virtual string[] ContainerNames
        {
            get
            {
                return containerNames;
            }
            set
            {
                this.containerNames = value;
            }
        }
        public virtual string MfaType
        {
            get
            {
                return mfaType;
            }
            set
            {
                this.mfaType = value;
            }
        }
        public virtual string Help
        {
            get
            {
                return help;
            }
            set
            {
                this.help = value;
            }
        }
        public virtual string PrimaryLanguageISOCode
        {
            get
            {
                return primaryLanguageISOCode;
            }
            set
            {
                this.primaryLanguageISOCode = value;
            }
        }
        public virtual string CountryISOCode
        {
            get
            {
                return countryISOCode;
            }
            set
            {
                this.countryISOCode = value;
            }
        }
        public virtual string getoAuthSite()
        {
            return oAuthSite;
        }
        public virtual void setoAuthSite(string oAuthSite)
        {
            this.oAuthSite = oAuthSite;
        }
        public virtual LocalizedSiteAttributes[] LocalizedSiteAttributes
        {
            get
            {
                return localizedSiteAttributes;
            }
            set
            {
                this.localizedSiteAttributes = value;
            }
        }
        public virtual string LastModified
        {
            get
            {
                return lastModified;
            }
            set
            {
                this.lastModified = value;
            }
        }
        public virtual string ForgetPasswordUrl
        {
            get
            {
                return forgetPasswordUrl;
            }
            set
            {
                this.forgetPasswordUrl = value;
            }
        }
        public virtual string LoginHelp
        {
            get
            {
                return loginHelp;
            }
            set
            {
                this.loginHelp = value;
            }
        }
        public virtual string AvailableFrom
        {
            get
            {
                return availableFrom;
            }
            set
            {
                this.availableFrom = value;
            }
        }
    }
}