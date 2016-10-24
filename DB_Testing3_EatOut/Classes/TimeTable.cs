using EatOutByBI.Data.Interfaces;
using System;

namespace EatOutByBI.Data.Classes
{
    public class TimeTable : IModificationHistory
    {
        public int TimeTableID { get; set; }


        public int Year { get; set; }
        public int YearWeekNumber { get; set; }
        public string MonthName { get; set; }
        public int MonthDay
        {
            get; set;
        }
        public string WeekDay { get; set; }
        public int TimeStamp { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


    }
}
