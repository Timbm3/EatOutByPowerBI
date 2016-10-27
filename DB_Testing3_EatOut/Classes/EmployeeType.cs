using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;

namespace EatOutByBI.Data.Classes
{
    public class EmployeeType : IModificationHistory
    {
        public int EmployeeTypeID { get; set; }
        [DisplayName("Anställnings Typ")]
        public string EmployeeTypeName { get; set; }
        public int EmployeeTypeOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
