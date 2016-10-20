using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
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
