using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class ProductGroupDTO
    {
        public int ProductGroupID { get; set; }

        //[Display(Name = "Produkt Grupp")]
        [DisplayName("Produkgrupp")]
        [StringLength(100)]
        [Required]
        public string ProductGroupName { get; set; }
        public int ProductGroupOrderRow { get; set; }
    }
}
