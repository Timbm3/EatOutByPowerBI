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

        [Required]
        public string Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Välj en tid.")]
        public DateTime DateAndTime { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        //public DateTime DateModified { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Välj en tid.")]    
        public int BookingTimeId { get; set; }
        public IEnumerable<BookingTime> BookingTime { get; set; }

        public int Pers { get; set; }

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
                if (_AntlPlatser == 0)
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
