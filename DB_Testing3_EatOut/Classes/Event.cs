using System;
using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.Classes
{
    public class Event
    {
        public int Id { get; set; }

        //public ApplicationUser Artist { get; set; }d

        public string Description { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public string CreatedId { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime FinnishTime { get; set; }

        [Required]
        [StringLength(255)]
        //[Display(Name = "Name of Event")]
        public string NameOfEvent { get; set; }

        public EventType EventType { get; set; }

        [Required]
        public byte EventTypeId { get; set; }
    }
    public class EventType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }

    public class EmployeeEvent
    {
        public int Id { get; set; }

        //public ApplicationUser Artist { get; set; }

        public string Description { get; set; }

        [Required]
        public string CreatedId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        //[Display(Name = "Name of Event")]
        public string NameOfEvent { get; set; }

        public EmployeeEventType EmployeeEventType { get; set; }

        [Required]
        public byte EmployeeEventTypeId { get; set; }
    }
    public class EmployeeEventType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
