using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class ProductGroup   : IModificationHistory
    {
        public int ProductGroupID { get; set; }

        public string ProductGroupName { get; set; }
        public int ProductGroupOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
