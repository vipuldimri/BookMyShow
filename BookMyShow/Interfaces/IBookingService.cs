using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Interfaces
{
    public interface IBookingService
    {
        public void BookShow(string userName , int showSeatId);
    }
}
