using EatOutByBI.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace EatOutByBI.Data.Classes
{
    public class Product : IModificationHistory
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }



        public int OrderRowID { get; set; }
        public List<OrderRow> OrderRow { get; set; }

        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public int ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
