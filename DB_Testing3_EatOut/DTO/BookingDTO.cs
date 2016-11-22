using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public DateTime DateAndTime { get; set; }


        public IEnumerable<Booking> Booking { get; set; }
        public IEnumerable<BookingTime> BookingTimes { get; set; }
        public int BookingTimeId { get; set; }

        public string Time { get; set; }

    }
}
