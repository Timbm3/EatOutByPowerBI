using EatOutByBI.Data.Classes;
using System.Collections.Generic;

namespace EatOutByBI.Data.DTO
{
    public class OrderRowDTO
    {
        //public OrderRowDTO()
        //{
        //    Products = new HashSet<Product>();
        //}
        public int OrderRowID { get; set; }

        public int ProductID { get; set; }

        public string ProduktNamn { get; set; }

        public int Kvantitet { get; set; }



        public IEnumerable<Product> Products { get; set; }

        //public int OrderID { get; set; }

    }
}
