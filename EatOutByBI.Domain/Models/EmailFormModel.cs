using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Domain.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Ditt Namn")]
        public string FromName { get; set; }


        [Required, Display(Name = "Din Email"), EmailAddress]
        public string FromEmail { get; set; }


        [Required]
        public string Message { get; set; }
    }
}