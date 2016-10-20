using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class Product : IModificationHistory
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        //public int OrderRowID { get; set; } 
        public virtual List<OrderRow> OrderRows { get; set; }

        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public int ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }


        //public ProductTypeEnum ProductTypeEnum { get; set; }
        // public ProductGroupEnum ProductGroupEnum { get; set; }  

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
