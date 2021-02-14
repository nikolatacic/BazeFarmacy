using System; //datetime

namespace Farmacy
{
    class OrderModel
    {
        public DateTime OrderedOn { get; set; }

        public string Notes { get; set; }

        public ShippingModel Shipping { get; set; }

        public PaymentModel Payment { get; set; }

    }



}
