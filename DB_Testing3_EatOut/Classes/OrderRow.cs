using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class OrderRow : IModificationHistory
    {
        public int OrderRowID { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
