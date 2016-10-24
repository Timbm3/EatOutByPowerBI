using EatOutByBI.Data.Interfaces;
using System;

namespace EatOutByBI.Data.Classes
{
    public class OrderRow : IModificationHistory
    {
        public int OrderRowID { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Kvantitet { get; set; }

        //public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
