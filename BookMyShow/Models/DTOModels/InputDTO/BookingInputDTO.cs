using System.ComponentModel.DataAnnotations;
namespace BookMyShow.Models.DTOModels.InputDTO
{
    public class BookingInputDTO
    {
        [Required]
        public int ShowId { get; set; }
        [Required]
        public int cinemaHallSeatId { get; set; }
        [Required]
        public string userName { get; set; }

        public string token { get; set; }
    }
}
