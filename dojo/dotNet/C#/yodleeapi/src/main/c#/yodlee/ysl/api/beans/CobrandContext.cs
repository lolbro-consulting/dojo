using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{


    public class CobrandContext
    {

     //   public string cobrandId{get;set;}
     //   public string applicationId{get;set;}
     //   public Sessionn session;
     //   public class Sessionn
     //   {
    
     //       public String externalSessionID;

     //       public String getExternalSessionID()
     //       {
     //           return externalSessionID;
     //      }
     // }
     //public Sessionn getCobrandConversationCredentials()
     //   {
     //       return session;
     //   }
     //   public String getSession()
     //   {
     //      return this.getCobrandConversationCredentials().getExternalSessionID();
          
     //  }


     //   public String getCobrandId()
     //   {
     //       return cobrandId;
     //   }



     //   public String getApplicationId()
     //   {
     //       return applicationId;
     //   }

     //   public String toString()
     //   {
     //       StringBuilder sb = new StringBuilder(this.cobrandId + this.applicationId);
     //       Console.WriteLine("CoBrand : toString() = " + sb);
     //       return sb.ToString();
     //   }
        public String cobrandId { get; set; }
        public String applicationId {get;set;}
        public Session session;


        public class Session
        {
            public String cobSession;

            public String getCobSession()
            {
                return cobSession;
            }

            public void setCobSession(String cobSession)
            {
                this.cobSession = cobSession;
            }


        }

        public Session getSession()
        {
            return session;
        }



        public void setSession(Session session)
        {
            this.session = session;
        }



        public void setCobrandId(String cobrandId)
        {
            this.cobrandId = cobrandId;
        }



        public void setApplicationId(String applicationId)
        {
            this.applicationId = applicationId;
        }



        public String getCobrandId()
        {
            return cobrandId;
        }



        public String getApplicationId()
        {
            return applicationId;
        }

        public String toString()
	{
		StringBuilder sb = new StringBuilder(this.cobrandId+this.applicationId);
		Console.WriteLine("CoBrand : toString() = " + sb);
        return sb.ToString();
	}
    }
}
