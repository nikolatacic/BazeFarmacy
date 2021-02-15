using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Farmacy
{
    public class CartModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Status { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public List<DrugModel> DrugList { get; set; }

    }



}
