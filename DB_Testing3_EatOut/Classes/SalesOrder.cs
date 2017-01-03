using EatOutByBI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatOutByBI.Data.Classes
{
    public class SalesOrder : IModificationHistory, IObjectWithState
    {
        public SalesOrder()
        {
            SalesOrderItems = new List<SalesOrderItem>();
        }

        public int SalesOrderId { get; set; }

        public string CustomerName { get; set; }

        public virtual List<SalesOrderItem> SalesOrderItems { get; set; }

        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //public int TimeTableID { get; set; }
        //public TimeTable TimeTable { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public DateTime DateTime { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}
