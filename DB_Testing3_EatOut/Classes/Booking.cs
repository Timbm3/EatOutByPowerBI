using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatOutByBI.Data.Classes
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Telephone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Time { get; set; }

        [Required]
        public string Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Välj en tid.")]
        public DateTime DateAndTime { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        //public DateTime DateModified { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Välj en tid.")]    
        public int BookingTimeId { get; set; }
        public IEnumerable<BookingTime> BookingTime { get; set; }

        public int BookedId { get; set; }
        public IEnumerable<Booked> Bookeds { get; set; }

        public int NrOfPeople { get; set; }

    }
}
