using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatOutByBI.Data.Classes
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethods { get; set; }
        public int Factor1 { get; set; }
        public int Factor2 { get; set; }
    }
}
