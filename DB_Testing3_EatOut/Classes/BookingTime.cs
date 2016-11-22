using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatOutByBI.Data.Classes
{
    public class BookingTime
    {
        public int BookingTimeId { get; set; }

        [Required]
        public string Time { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
