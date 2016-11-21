using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class LocalizedSiteAttributes
    {
        public long localeId;
        public string countryISOCode;
        public string languageISOCode;
        public string name;
        public string nameWithCountry;
        public string loginUrl;
        public string baseUrl;
        public string help;
        public string forgetPasswordURL;
        public string loginHelp;
        public LocalizedSiteAttributes()
        {
        } //*      * @return the localeId
        public virtual long LocaleId
        {
            get
            {
                return localeId;
            }
            set
            {
                this.localeId = value;
            } //*      * @return the countryISOCode
        } //*      * @param localeId the localeId to set
        public virtual string CountryISOCode
        {
            get
            {
                return countryISOCode;
            }
            set
            {
                this.countryISOCode = value;
            } //*      * @return the languageISOCode
        } //*      * @param countryISOCode the countryISOCode to set
        public virtual string LanguageISOCode
        {
            get
            {
                return languageISOCode;
            }
            set
            {
                this.languageISOCode = value;
            } //*      * @return the name
        } //*      * @param languageISOCode the languageISOCode to set
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            } //*      * @return the nameWithCountry
        } //*      * @param name the name to set
        public virtual string NameWithCountry
        {
            get
            {
                return nameWithCountry;
            }
            set
            {
                this.nameWithCountry = value;
            } //*      * @return the loginURL
        } //*      * @param nameWithCountry the nameWithCountry to set
        public virtual string LoginUrl
        {
            get
            {
                return loginUrl;
            }
            set
            {
                this.loginUrl = value;
            } //*      * @return the baseURL
        } //*      * @param loginURL the loginURL to set
        public virtual string BaseUrl
        {
            get
            {
                return baseUrl;
            }
            set
            {
                this.baseUrl = value;
            } //*      * @return the help
        } //*      * @param baseURL the baseURL to set
        public virtual string Help
        {
            get
            {
                return help;
            }
            set
            {
                this.help = value;
            } //*      * @return the forgetPasswordURL
        } //*      * @param help the help to set
        public virtual string ForgetPasswordURL
        {
            get
            {
                return forgetPasswordURL;
            }
            set
            {
                this.forgetPasswordURL = value;
            } //*      * @return the loginHelp
        } //*      * @param forgetPasswordURL the forgetPasswordURL to set
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
        } //*      * @param loginHelp the loginHelp to set
    }
}