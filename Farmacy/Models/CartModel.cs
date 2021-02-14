using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Farmacy
{
    public class CartModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Status { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }

        public DrugModel[] DrugList { get; set; }
    
    }



}
