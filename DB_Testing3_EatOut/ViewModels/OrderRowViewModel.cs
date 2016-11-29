using EatOutByBI.Data.Classes;
using System.Collections.Generic;

namespace EatOutByBI.Data.ViewModels
{
    public class OrderRowViewModel
    {
        //public List<OrderRowDTO> OrderRowItems { get; set; }

        public OrderRowViewModel()
        {
            Products = new HashSet<Product>();
            ProduktNamn = "HEJ";
        }
        public int OrderRowID { get; set; }

        public int ProductID { get; set; }

        public string ProduktNamn { get; set; }

        public int Kvantitet { get; set; }



        public IEnumerable<Product> Products { get; set; }

    }
}
