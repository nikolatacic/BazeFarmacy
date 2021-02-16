using System; //datetime
using MongoDB.Bson.Serialization.Attributes;

namespace Farmacy
{
    public class ShippingModel
    {
        public string CustomerUsername { get; set; }

        public string CompanyName { get; set; }

        public DateTime EstimatedTime { get; set; }

        public string Status { get; set; }

        public string formatString()
        {
            return "Company name: " + "Time of arrival: " + EstimatedTime.ToString();
        }

    }



}
