using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatOutByBI.Data.Classes;

namespace EatOutByBI.Data.DTO
{
    public class BookingDTO
    {
        public BookingDTO()
        {
            BookingTimes = new HashSet<BookingTime>();
        }

        public int BookingId { get; set; }

        [Required(ErrorMessage = "Ange ditt namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ange ditt telefon nummer")]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Ange din email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Välj ett datum")]
        public string Date { get; set; }
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "Välj en tid")]
        public string Time { get; set; }

        public IEnumerable<Booking> Booking { get; set; }
        public IEnumerable<BookingTime> BookingTimes { get; set; }
        public int BookingTimeId { get; set; }



    }
}
