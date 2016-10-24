using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
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
