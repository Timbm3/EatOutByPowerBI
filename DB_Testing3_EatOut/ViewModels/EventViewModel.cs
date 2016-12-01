using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EatOutByBI.Data.ViewModels
{
    public class EventViewModel
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
        public byte EventType { get; set; }

        public IEnumerable<EventType> EventTypes { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
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
                "HH:mm",
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
