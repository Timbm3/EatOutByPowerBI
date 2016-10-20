using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class ProductType : IModificationHistory
    {
        public int ProductTypeID { get; set; }
        //public ProductTypeEnum ProductTypeEnum { get; set; }
        public string ProductTypeName { get; set; }
        public int ProductTypeOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
