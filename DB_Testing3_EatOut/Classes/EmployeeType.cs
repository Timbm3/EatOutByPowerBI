using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
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
