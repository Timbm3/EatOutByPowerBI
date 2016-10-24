using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
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
