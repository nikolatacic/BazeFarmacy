using System; //datetime
using MongoDB.Bson.Serialization.Attributes;

namespace Farmacy
{
    public class ShippingModel
    {
        [BsonId]
        public Guid CustomerId { get; set; }

        public string CompanyName { get; set; }

        public DateTime EstimatedTime { get; set; }

        public string Status { get; set; }

    }



}
