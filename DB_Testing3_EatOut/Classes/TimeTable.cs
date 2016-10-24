using System;
using EatOutByBI.Data.Interfaces;

namespace EatOutByBI.Data.Classes
{
    public class TimeTable : IModificationHistory
    {
        public int TimeTableID { get; set; }

        public int Year { get; set; }
        public int YearWeekNumber { get; set; }
        public int MonthNr { get; set; }
        public string MonthName { get; set; }
        public DateTime MonthDay { get; set; }
        public string WeekDay { get; set; }
        public int DayOfYear { get; set; }
        public int TimeStamp { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


    }
}
