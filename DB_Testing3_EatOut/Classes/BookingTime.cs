using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatOutByBI.Data.DTO;

namespace EatOutByBI.Data.Classes
{
    public class BookingTime
    {
        public int BookingTimeId { get; set; }

        [Required]
        public string Time { get; set; }
        public string Date { get; set; }

        public DateTime DateAndTime { get; set; }

        public int AvailableSeats { get; set; } = 10;

        private bool _isAvailable;
        public bool IsAvailable
        {
            get
            {
                if (AvailableSeats == 0)
                {
                    return _isAvailable = false;
                }
                else
                {
                    return _isAvailable = true;

                }

            }
            set { _isAvailable = value; }
        }

        public int BookedId { get; set; }
        public Booked Booked { get; set; }

        //public DateTime DateCreated { get; set; }
        //public DateTime DateModified { get; set; }

        public static List<BookingTime> AddDefaultTimes(BookingDTO bookingDto, int finalBookedId)
        {
            var time1 = "17:00:00";
            var time2 = "19:00:00";
            var time3 = "21:00:00";

            List<BookingTime> bookingTimes = new List<BookingTime>()
                    {
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time1,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        },
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time2,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        },
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time3,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        }
                    };
            return bookingTimes;
        }

    }
}
