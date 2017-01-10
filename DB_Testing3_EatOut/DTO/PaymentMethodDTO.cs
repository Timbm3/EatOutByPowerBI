using System.ComponentModel;

namespace EatOutByBI.Data.DTO
{
    public class PaymentMethodDTO
    {
        public int PaymentMethodId { get; set; }

        [DisplayName("Betalningsmetod")]
        public string PaymentMethodType { get; set; }
    }
}
