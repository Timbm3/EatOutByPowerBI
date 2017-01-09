using EatOutByBI.Data.Classes;
using System.Collections.Generic;
using System.ComponentModel;
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


        [DisplayName("Namn")]
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int EmployeeFormID { get; set; }
        public IEnumerable<EmployeeForm> EmployeeForms { get; set; }


        [DisplayName("Anställnings Form")]
        public string FormName { get; set; }

        public int EmployeeTypeID { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }

        [DisplayName("Anställnings Typ")]
        public string TypeName { get; set; }


    }
}
