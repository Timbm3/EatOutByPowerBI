using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class TimeTableDTO
    {
        public int TimeTableID { get; set; }


        public int Year { get; set; }
        public int YearWeekNumber { get; set; }

        [StringLength(30)]
        [Required]
        public string MonthName { get; set; }
        public int MonthDay
        {
            get; set;

        }
        [Required]
        [StringLength(30)]
        public string WeekDay { get; set; }
        public int TimeStamp { get; set; }
    }
}
