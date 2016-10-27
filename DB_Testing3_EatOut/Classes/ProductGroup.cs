using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;

namespace EatOutByBI.Data.Classes
{
    public class ProductGroup : IModificationHistory
    {
        public int ProductGroupID { get; set; }

        //[Display(Name = "Produkt Grupp")]
        [DisplayName("Produkt Grupp Namn")]
        public string ProductGroupName { get; set; }
        public int ProductGroupOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

