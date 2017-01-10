using EatOutByBI.Data.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class ProductDTO
    {



        public ProductDTO()
        {
            ProductGroups = new HashSet<ProductGroup>();
            //ProductTypes = new HashSet<ProductType>();
        }


        public int ProductID { get; set; }

        [DisplayName("Namn")]
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }



        public IEnumerable<ProductGroup> ProductGroups { get; set; }
        //public IEnumerable<ProductType> ProductTypes { get; set; }


        public int Amount { get; set; }
        public string Unit { get; set; }



        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        //Html.TextBoxFor(m => m.PositiveNumber, 
        //              new { @type = "number", @class = "span4", @min = "0" })

        [DisplayName("Pris")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Grupp")]
        public string ProductGroupName { get; set; }
        [DisplayName("Produkts Typ")]
        public string ProductTypeName { get; set; }

        public int ProductGroupID { get; set; }
        public int ProductTypeID { get; set; }

    }
}
