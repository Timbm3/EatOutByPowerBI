using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class TimeTable : IModificationHistory
    {
        public int TimeTableID { get; set; }

        DateTime dateTime = DateTime.Now;


        private DateTime _now = DateTime.Now;

        private string month;

        public int Year { get; set; }
        public int YearWeekNumber { get; set; }
        public string MonthName { get; set; }
        public DateTime MonthDay { get { return _now; } set
            {
                
                for (int i = 0; i < 12; i++)
                {
                    _now.ToString("MMM");
                    _now = _now.AddMonths(1);
                    _now = value;
                }
            } }
        public string WeekDay { get; set; }
        public int TimeStamp { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


    }
}
