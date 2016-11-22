using EatOutByBI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class EmployeeForm : IModificationHistory
    {
        public int EmployeeFormID { get; set; }

        [DisplayName("Anställnings Form")]
        [Required]
        [StringLength(30)]
        public string EmployeeFormName { get; set; }
        public int EmployeeFormOrderRow { get; set; }
        public IList<Employee> Employees { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }



    }
}
