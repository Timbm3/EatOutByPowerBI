using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class EmployeeType : IModificationHistory
    {
        public int EmployeeTypeID { get; set; }

        [DisplayName("Anställnings Typ")]
        [Required]
        [StringLength(30)]
        public string EmployeeTypeName { get; set; }
        public int EmployeeTypeOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
