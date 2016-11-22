using EatOutByBI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class Product : IModificationHistory
    {
        public int ProductID { get; set; }

        [DisplayName("Produktnamn")]
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }

        public int ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


    }
}
