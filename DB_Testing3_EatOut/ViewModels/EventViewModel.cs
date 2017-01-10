using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EatOutByBI.Data.ViewModels
{
    public class EventViewModel
    {
        [Required]
        [DisplayName("Namn på Event")]
        public string NameOfEvent { get; set; }

        [Required]
        [FutureDate]
        [DisplayName("Datum")]
        public string Date { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [DisplayName("Bild")]
        public byte[] Image { get; set; }

        [Required]
        [ValidTime]
        [DisplayName("Starttid")]
        public string Time { get; set; }

        [ValidTime]
        [DisplayName("Sluttid")]
        public string EndTime { get; set; }


        [Required]
        [DisplayName("Event Typ")]
        public byte EventType { get; set; }

        public IEnumerable<EventType> EventTypes { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}:00", Date, Time));
        }

        public DateTime GetEndTime()
        {
            return DateTime.Parse(string.Format("{0} {1}:00", Date, EndTime));
        }
    }

    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }

    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid);
        }
    }

    public class EmployeeEventViewModel
    {

        [Required]
        public string NameOfEvent { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte EmployeeEventType { get; set; }

        public IEnumerable<EmployeeEventType> EmployeeEventTypes { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));

        }
    }
}
