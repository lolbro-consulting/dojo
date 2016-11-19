using System.Web.Http;

namespace dojo.server.Controllers
{
    public class CategoryController : ApiController
    {
        public decimal GetAmmoutForCategory(string category)
        {
            switch (category)
            {
                case "Entertainment/Recreation":
                    return 120;
                case "Service Charges/Fees":
                    return 200;
                case "Electronics/General Merchandise":
                    return 150;
                case "Restaurants":
                    return 15;
                case "Home Improvement":
                    return 500;
                case "Automotive/Fuel":
                    return 600;
                case "Cable/Satellite/Telecom":
                    return 100;
                case "Credit Card Payments":
                    return 10000;
            }

            return 156;
        }     
    }
}