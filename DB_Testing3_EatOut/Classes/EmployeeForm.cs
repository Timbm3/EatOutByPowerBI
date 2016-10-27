using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;

namespace EatOutByBI.Data.Classes
{
    public class EmployeeForm : IModificationHistory
    {
        public int EmployeeFormID { get; set; }

        [DisplayName("Anställnings Form")]
        public string EmployeeFormName { get; set; }
        public int EmployeeFormOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }



    }
}
