using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Farmacy
{
    public class InstructionModel
    {
        public string Dose {get; set; }
        
        public string[] Symptoms { get; set; }
        
        public string[] SideEffects { get; set; }

        public string Warning { get; set; }

        [BsonElement("HowToUse")]
        public string Usage { get; set; }
    }



}
