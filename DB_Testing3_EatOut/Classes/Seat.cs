using EatOutByBI.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class Seat : IModificationHistory
    {
        public Seat()
        {

        }
        public int SeatId { get; set; }


        [Required]
        [StringLength(30)]
        public string SeatPlace { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int Factor1 { get; set; }
        public int Factor2 { get; set; }

    }
}
