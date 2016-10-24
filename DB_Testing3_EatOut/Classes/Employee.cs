using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
{
    public class Employee : IModificationHistory
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }

        public int EmployeeFormID { get; set; } 
        public virtual EmployeeForm EmployeeForm { get; set; }

        public int EmployeeTypeID { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
