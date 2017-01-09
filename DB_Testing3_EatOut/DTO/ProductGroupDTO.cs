using EatOutByBI.Data.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class ProductGroupDTO
    {

        public ProductGroupDTO()
        {
            ProductTypes = new HashSet<ProductType>();
        }
        public int ProductGroupID { get; set; }

        //[Display(Name = "Produkt Grupp")]
        [DisplayName("Grupp")]
        [StringLength(100)]
        [Required]
        public string ProductGroupName { get; set; }

        [DisplayName("Sorterings Rad")]
        public int ProductGroupOrderRow { get; set; }

        public int ProductTypeID { get; set; }

        [DisplayName("Produkts Typ")]
        public string ProductTypeName { get; set; }

        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}
