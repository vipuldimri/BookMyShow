using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.SystemModels
{
    public class Booking
    {
        [Column("BookingId")]
        [Key]
        public int BookingId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }


        [Required]
        public int Status { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserName { get; set; }
        public virtual User User { get; set; }


        [Required]
        [ForeignKey("Show")]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
    }
}
