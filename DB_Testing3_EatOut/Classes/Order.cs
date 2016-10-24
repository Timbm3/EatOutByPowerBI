using System;
using System.Collections.Generic;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
{
    public class Order : IModificationHistory
    {
        public int OrderID { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

        public int SeatID { get; set; }
        public virtual Seat Seat { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public int TimeTableID { get; set; }    
        public TimeTable TimeTable { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
