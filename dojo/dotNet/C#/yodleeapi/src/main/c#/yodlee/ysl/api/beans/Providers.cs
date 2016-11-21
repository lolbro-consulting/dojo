
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Providers
    {
        //public List<Providers> pro { get; set; }
        
    
        //public long providerId { get; set; }
        //public String providerName{get;set;}
        //public long getProviderId()
        //{
        //    return providerId;
        //}
        //public void setProviderId(long providerId)
        //{
        //    this.providerId = providerId;
        //}
        //public String getProviderName()
        //{
        //    return providerName;
        //}
        //public void setProviderName(String providerName)
        //{
        //    this.providerName = providerName;
        //}
        //public string ToString()
        //{
        //    StringBuilder provider = new StringBuilder("");
        //    for (int i = 0; i < pro.Count; i++)
        //    {
        //        provider.Append(pro[i].getProviderId()).Append("=>").Append(pro[i].getProviderName()).Append("\n");
        //    }
        //    return provider.ToString();
        //}

        public Provider[] provider;
       // public List<Provider> providr { get; set; }

        public Provider[] getProvider()
        {
            return provider;

        }

        public void setProvider(Provider[] provider)
        {
           this.provider = provider;
        }

        public String toString()
        {
            StringBuilder providers = new StringBuilder("");
            if (provider == null)
                return providers.ToString();
            for (int i = 0; i < provider.Length; i++)
            {
                providers.Append(provider[i].toString());
            }
            return providers.ToString();
        }
    }
}
