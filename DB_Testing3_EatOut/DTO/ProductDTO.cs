using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }

        [DisplayName("Produktnamn")]
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }



        public int OrderRowID { get; set; }


        public int ProductTypeID { get; set; }


        public int ProductGroupID { get; set; }
    }
}
