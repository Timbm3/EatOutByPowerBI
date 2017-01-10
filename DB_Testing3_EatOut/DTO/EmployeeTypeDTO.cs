using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class EmployeeTypeDTO
    {
        public int EmployeeTypeID { get; set; }

        [DisplayName("Anställnings Typ")]
        [Required]
        [StringLength(30)]
        public string EmployeeTypeName { get; set; }

        [DisplayName("Sorterings Rad")]
        public int EmployeeTypeOrderRow { get; set; }
    }
}
