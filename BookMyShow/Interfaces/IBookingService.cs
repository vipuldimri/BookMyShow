using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Interfaces
{
    public interface IBookingService
    {
        public int BookShow(string userName , int showId , int cinemaHallSeatId);
    }
}
