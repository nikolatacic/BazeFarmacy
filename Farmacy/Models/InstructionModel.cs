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

        public string formatString()
        {
            string text = "";
            string nl = "\r\n\r\n";
            text += "Dose: " + Dose + nl
                + "Symptoms: " + string.Join(", ", Symptoms) + nl
                + "Side effects: " + string.Join(", ", SideEffects) + nl
                + "Warning: " + Warning + nl
                + "Usage: " + Usage;
            return text;
        }
    }



}
