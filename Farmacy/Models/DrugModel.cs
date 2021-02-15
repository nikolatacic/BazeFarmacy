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

        public string formatString()
        {
            string text = "";
            string nl = "\r\n\r\n";

            text += "Product Code: " + ProductCode.ToString() + nl
                + "Manufacturer: " + Manufacturer + nl
                + "Type: " + Type + nl
                + Instruction.formatString() + nl
                + "Quantity: " + Quantity.ToString() + nl
                + "Price: " + Price.ToString();
            return text;
        }
    }



}
