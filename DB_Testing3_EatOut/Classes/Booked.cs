using EatOutByBI.Data.DTO;
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

        //public int BookingTimeId { get; set; }
        public IEnumerable<BookingTime> BookingTimes { get; set; }

        public bool IsDateAvailable { get; set; } = true;


        //private bool _isDateAvailable = true;
        //public bool IsDateAvailable
        //{
        //    get
        //    {
        //        var NoAvailableTimes = BookingTimes.All(c => c.IsAvailable == false);
        //        if (NoAvailableTimes)
        //        {
        //            return _isDateAvailable = false;
        //        }
        //        else
        //        {
        //            return _isDateAvailable = true;

        //        }


        //    }
        //    set { _isDateAvailable = value; }
        //}

    }
}
