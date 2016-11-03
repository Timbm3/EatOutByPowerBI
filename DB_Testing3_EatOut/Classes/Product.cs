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



        public int OrderRowID { get; set; }
        public List<OrderRow> OrderRow { get; set; }

        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public int ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
