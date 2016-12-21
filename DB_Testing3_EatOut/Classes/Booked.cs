using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatOutByBI.Data.Classes
{
    public class Booked
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookedId { get; set; }

        //public DateTime DateAndTime { get; set; }

        //public int Plats { get; set; } = 10;

        //public int BookingTimeId { get; set; }
        public IEnumerable<BookingTime> BookingTimes { get; set; }

        //private bool _IsAvailable;
        //public bool IsAvailable
        //{
        //    get
        //    {
        //        if (Plats == 0)
        //        {
        //            return _IsAvailable = false;
        //        }
        //        else
        //        {
        //            return _IsAvailable = true;

        //        }

        //    }
        //    set { _IsAvailable = value; }
        //}

    }
}
