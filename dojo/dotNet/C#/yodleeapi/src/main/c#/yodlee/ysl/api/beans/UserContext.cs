using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace yodlee.ysl.api.beans
{

    public class UserContext
    {
        public User user;

        public User getUser()
        {
            return user;
        }

        public void setUserSession(User user)
        {
            this.user = user;
        }


        public class User
        {
            public Session session;


            public class Session
            {
                public String userSession;

                public String getUserSession()
                {
                    return userSession;
                }

                public void setUserSession(String userSession)
                {
                    this.userSession = userSession;
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

        }
    }

}