using MongoDB.Bson.Serialization.Attributes;
using System; //datetime
using System.Collections.Generic;

namespace Farmacy
{
    public class OrderModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public string Notes { get; set; }

        public List<DrugModel> DrugsList{ get; set; }

        public ShippingModel Shipping { get; set; }

        public PaymentModel Payment { get; set; }

    }



}
