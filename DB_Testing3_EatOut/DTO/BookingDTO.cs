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


        public int Pers { get; set; }

        public int Plats { get; set; }


        int _AntlPlatser;
        int _AntalPersoner;
        int _PlatsRäknare;
        private bool _isAvailable = true;

        public int AntalPlatser
        {
            get { return _AntlPlatser; }
            set
            {
                _AntlPlatser = value;
                _AntlPlatser = _AntlPlatser - _AntalPersoner;
            }
        }

        public int AntalPersoner
        {
            get { return _AntalPersoner; }
            set
            {
                _AntalPersoner = value;
                _AntlPlatser = _AntlPlatser - _AntalPersoner;
            }
        }

        public int PlatsRäknare { get { return _AntlPlatser; } }

        public bool IsAvailable
        {
            get
            {
                if (_AntlPlatser <= 0)
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

    }
}
