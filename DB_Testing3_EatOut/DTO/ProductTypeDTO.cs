using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class ProductTypeDTO
    {
        public int ProductTypeID { get; set; }
        //public ProductTypeEnum ProductTypeEnum { get; set; }

        [DisplayName("Produktyp")]
        [StringLength(100)]
        [Required]
        public string ProductTypeName { get; set; }
        public int ProductTypeOrderRow { get; set; }

    }
}
