using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class ProductType : IModificationHistory
    {
        public int ProductTypeID { get; set; }
        //public ProductTypeEnum ProductTypeEnum { get; set; }

        [DisplayName("Produktyp")]
        [StringLength(100)]
        [Required]
        public string ProductTypeName { get; set; }
        public int ProductTypeOrderRow { get; set; }



        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
