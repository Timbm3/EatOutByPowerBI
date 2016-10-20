using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class Seat : IModificationHistory
    {
        public Seat()
        {

        }
        public int SeatID { get; set; }
        public int TableNr { get; set; }
        public bool Bar { get; set; }
        public bool Outside { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
