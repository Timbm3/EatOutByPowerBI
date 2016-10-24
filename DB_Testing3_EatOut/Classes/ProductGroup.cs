using DB_Testing3_EatOut.Interfaces;
using System;

namespace DB_Testing3_EatOut
{
    public class ProductGroup : IModificationHistory
    {
        public int ProductGroupID { get; set; }

        public string ProductGroupName { get; set; }
        public int ProductGroupOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
