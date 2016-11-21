
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace yodlee.ysl.api.beans
{

    public class Provider
    {
    //    public IList<Site> provider { get; set;}//getting deserialized value for Site class 
       

    //    public virtual IList<Site> getProvider()
    //    {
    //        return provider;
    //    }

    //    public virtual void setProvider(Site[] provider)
    //    {
    //        this.provider = provider;
    //    }
        public long id;

        public String name;

        public String nameWithCountry;

        public String loginUrl;

        public String baseUrl;

        public string favicon;

        public string logo;

        public String status;

        public String[] containerNames;

        public String mfaType;

        public String help;

        public String primaryLanguageISOCode;

        public String countryISOCode;

        public String oAuthSite;

        public LocalizedSiteAttributes[] localizedSiteAttributes;

        public String lastModified;

        public String forgetPasswordUrl;

        public String loginHelp;

        public LoginForm loginForm;

        public String availableFrom;

        public long getId()
        {

            return id;

        }

        public void setId(long id)
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

        public String getNameWithCountry()
        {

            return nameWithCountry;

        }

        public void setNameWithCountry(String nameWithCountry)
        {

            this.nameWithCountry = nameWithCountry;

        }

        public String getLoginUrl()
        {

            return loginUrl;

        }

        public void setLoginUrl(String loginUrl)
        {

            this.loginUrl = loginUrl;

        }

        public String getBaseUrl()
        {

            return baseUrl;

        }

        public void setBaseUrl(String baseUrl)
        {

            this.baseUrl = baseUrl;

        }

        public LoginForm getLoginForm()
        {

            return loginForm;

        }

        public void setLoginForm(LoginForm loginForm)
        {

            this.loginForm = loginForm;

        }

        public string getFavicon()
        {

            return favicon;

        }

        public void setFavicon(string favicon)
        {

            this.favicon = favicon;

        }

        public string getLogo()
        {

            return logo;

        }

        public void setLogo(string logo)
        {

            this.logo = logo;

        }

        public String getStatus()
        {

            return status;

        }

        public void setStatus(String status)
        {

            this.status = status;

        }

        public String[] getContainerNames()
        {

            return containerNames;

        }

        public void setContainerNames(String[] containerNames)
        {

            this.containerNames = containerNames;

        }

        public String getMfaType()
        {

            return mfaType;

        }

        public void setMfaType(String mfaType)
        {

            this.mfaType = mfaType;

        }

        public String getHelp()
        {

            return help;

        }

        public void setHelp(String help)
        {

            this.help = help;

        }

        public String getPrimaryLanguageISOCode()
        {

            return primaryLanguageISOCode;

        }

        public void setPrimaryLanguageISOCode(String primaryLanguageISOCode)
        {

            this.primaryLanguageISOCode = primaryLanguageISOCode;

        }

        public String getCountryISOCode()
        {

            return countryISOCode;

        }

        public void setCountryISOCode(String countryISOCode)
        {

            this.countryISOCode = countryISOCode;

        }

        public String getoAuthSite()
        {

            return oAuthSite;

        }

        public void setoAuthSite(String oAuthSite)
        {

            this.oAuthSite = oAuthSite;

        }

        public LocalizedSiteAttributes[] getLocalizedSiteAttributes()
        {

            return localizedSiteAttributes;

        }

        public void setLocalizedSiteAttributes(

                LocalizedSiteAttributes[] localizedSiteAttributes)
        {

            this.localizedSiteAttributes = localizedSiteAttributes;

        }

        public String getLastModified()
        {

            return lastModified;

        }

        public void setLastModified(String lastModified)
        {

            this.lastModified = lastModified;

        }

        public String getForgetPasswordUrl()
        {

            return forgetPasswordUrl;

        }

        public void setForgetPasswordUrl(String forgetPasswordUrl)
        {

            this.forgetPasswordUrl = forgetPasswordUrl;

        }

        public String getLoginHelp()
        {

            return loginHelp;

        }

        public void setLoginHelp(String loginHelp)
        {

            this.loginHelp = loginHelp;

        }

        public String getAvailableFrom()
        {

            return availableFrom;

        }

        public void setAvailableFrom(String availableFrom)
        {

            this.availableFrom = availableFrom;

        }
        public String toString()
        {
            StringBuilder provider = new StringBuilder("");
            provider.Append(this.id).Append("=>").Append("name= ").Append(this.name).Append("=> loginUrl = " + this.loginUrl).Append("\n");
            return provider.ToString();
        }



    }



}
