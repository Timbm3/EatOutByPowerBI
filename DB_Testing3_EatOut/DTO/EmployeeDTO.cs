using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int EmployeeFormID { get; set; }

        public int EmployeeTypeID { get; set; }


    }
}
