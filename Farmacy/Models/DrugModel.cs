using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Farmacy
{
    public class DrugModel
    { 
        [BsonId]
        public Guid Id { get;  set; }

        public int ProductCode { get;  set; }

        public string Name { get;  set; }

        public string Manufacturer { get; set; }

        public string Type { get;  set; }

        public InstructionModel Instruction { get; set; }

        public int Quantity { get;  set; }

        public double Price { get; set; }
    }



}
