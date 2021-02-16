namespace Farmacy
{
    public class PaymentModel 
    { 
        public string Method { get; set; }

        public string TransactionId { get; set; }

        public string Currency { get; set; }

        public string formatString()
        {
            return Currency + ", Method: " + Method + "Transaction: " + TransactionId; 
        }

    }



}
