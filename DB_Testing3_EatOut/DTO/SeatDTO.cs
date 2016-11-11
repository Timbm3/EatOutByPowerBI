using System.ComponentModel.DataAnnotations;

namespace EatOutByBI.Data.DTO
{
    public class SeatDTO
    {
        public int SeatID { get; set; }


        [Required]
        [StringLength(30)]
        public string SeatPlace { get; set; }
    }
}
