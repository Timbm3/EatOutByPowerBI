using System;
using System.Collections.Generic;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
{
    public class OrderRow : IModificationHistory
    {
        public int OrderRowID { get; set; }

        // public int ProductID { get; set; }
        public virtual List<Product> Product { get; set; }
        public int Kvantitet { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
