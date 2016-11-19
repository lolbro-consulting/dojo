using System;
using System.Web.Http;

namespace dojo.server.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryController()
        {
        }

        public decimal GetAmmoutForCategory(string category, int timeInterval)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException(nameof(category));
            }

            switch (category)
            {
                case "Entertainment/Recreation":
                    return 120 * timeInterval;
                case "Service Charges/Fees":
                    return 200 * timeInterval;
                case "Electronics/General Merchandise":
                    return 150 * timeInterval;
                case "Restaurants":
                    return 15 * timeInterval;
                case "Home Improvement":
                    return 500 * timeInterval;
                case "Automotive/Fuel":
                    return 600 * timeInterval;
                case "Cable/Satellite/Telecom":
                    return 100 * timeInterval;
                case "Credit Card Payments":
                    return 10000 * timeInterval;
            }

            return 156;
        }     
    }
}