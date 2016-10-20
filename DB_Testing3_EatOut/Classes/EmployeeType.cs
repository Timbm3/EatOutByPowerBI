using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class EmployeeType : IModificationHistory
    {
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public int EmployeeTypeOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
