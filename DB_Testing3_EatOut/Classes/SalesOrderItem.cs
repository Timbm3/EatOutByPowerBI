using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatOutByBI.Data.Classes
{
    public class SalesOrderItem : IModificationHistory, IObjectWithState
    {

        public int SalesOrderItemId { get; set; }


        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public int SalesOrderId { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }


        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}
