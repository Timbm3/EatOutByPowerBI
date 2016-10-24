using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
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
