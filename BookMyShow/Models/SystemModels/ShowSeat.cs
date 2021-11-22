
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

        [Required]
        [ForeignKey("Show")]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }

        [Required]
        [ForeignKey("CinemaHallSeat")]
        public int CinemaHallSeatId { get; set; }
        public virtual CinemaHallSeat CinemaHallSeat { get; set; }
    }
}
