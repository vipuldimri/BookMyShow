
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookMyShow.Models.SystemModels
{
    public class ShowSeat
    {
        [Column("ShowSeatId")]
        [Key]
        public int ShowSeatId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }

        public int CinemaHallSeatId { get; set; }
    }
}
