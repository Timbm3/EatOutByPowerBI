using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class Employee : IModificationHistory
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        public int EmployeeFormID { get; set; }
        public virtual EmployeeForm EmployeeForm { get; set; }


        public int EmployeeTypeID { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }



        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
