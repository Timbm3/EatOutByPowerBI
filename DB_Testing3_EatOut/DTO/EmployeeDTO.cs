using EatOutByBI.Data.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class EmployeeDTO
    {

        public EmployeeDTO()
        {
            EmployeeForms = new HashSet<EmployeeForm>();
            EmployeeTypes = new HashSet<EmployeeType>();
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int EmployeeFormID { get; set; }
        public IEnumerable<EmployeeForm> EmployeeForms { get; set; }


        public string FormName { get; set; }

        public int EmployeeTypeID { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }

        public string TypeName { get; set; }


    }
}
