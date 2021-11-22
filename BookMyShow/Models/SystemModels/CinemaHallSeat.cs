
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.SystemModels
{
    public class CinemaHallSeat
    {
        [Column("CinemaHallSeatId")]
        [Key]
        public int CinemaHallSeatId { get; set; }
        
        [Required]
        public int SeatNo{ get; set; }

        [Required]
        public int SeatType { get; set; }

        [Required]
        [ForeignKey("CinemaHall")]
        public int CinemaHallId { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }
    }
}
