using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
{
    public class EmployeeForm : IModificationHistory
    {
        public int EmployeeFormID { get; set; }
        public string EmployeeFormName { get; set; }
        public int EmployeeFormOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        

    }
}
