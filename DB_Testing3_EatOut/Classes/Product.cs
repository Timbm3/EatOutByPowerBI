using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatOutByBI.Data.Classes
{
    public class Product : IModificationHistory, IObjectWithState
    {
        public int ProductId { get; set; }

        [DisplayName("Produktnamn")]
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }

        public int ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}
