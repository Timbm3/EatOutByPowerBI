using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class EmployeeFormDTO
    {
        public int EmployeeFormID { get; set; }

        [DisplayName("Anställnings Form")]
        [Required]
        [StringLength(30)]
        public string EmployeeFormName { get; set; }
        public int EmployeeFormOrderRow { get; set; }


    }
}
