using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class ProductGroup : IModificationHistory
    {
        public int ProductGroupID { get; set; }

        //[Display(Name = "Produkt Grupp")]
        [DisplayName("Produkgrupp")]
        [StringLength(100)]
        [Required]
        public string ProductGroupName { get; set; }
        public int ProductGroupOrderRow { get; set; }

        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}

