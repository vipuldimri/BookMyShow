using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Interfaces;
using BookMyShow.Models.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookMyShow.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly ILoggerManager _logger;
        public BookingService(ApplicationContext applicationContext, ILoggerManager logger)
        {
            _applicationContext = applicationContext;
            _logger =  logger;
        }

        public int BookShow(string userName,int showId, int cinemaHallSeatId)
        {
            int bookingId = 0;

            _logger.LogDebug(string.Format("BookShow for username {0} and cinemaSeatId {1}",  userName , cinemaHallSeatId));
            var cinemaHallSeat = _applicationContext.CinemaHallSeat.SingleOrDefault(x => x.CinemaHallSeatId == cinemaHallSeatId);

            if (cinemaHallSeat == null)
                throw new BusinessException("Invalid Operation","Seat not present.");

            var show = _applicationContext.Show.SingleOrDefault(x => x.ShowId == showId);
            if (show == null)
                throw new BusinessException("Invalid Operation", "show not present.");

            if (_applicationContext.ShowSeat.Any(x => x.Booking.ShowId == showId && x.CinemaHallSeatId == cinemaHallSeatId && x.Status == (int)SeatStatus.Booked))
                throw new BusinessException("Invalid Operation", "Seat already booked.");


            bool status = false;
            using (var transaction = _applicationContext.Database.BeginTransaction())
            {
                try
                {
                    var newBooking = new Models.SystemModels.Booking()
                    {
                        DateTime = DateTime.Now,
                        ShowId = showId,
                        UserName = userName,
                        Status = (int)BookingStatus.Booked
                    };
                    _applicationContext.Booking.Add(newBooking);
                    _applicationContext.SaveChanges();

                    _applicationContext.ShowSeat.Add(new Models.SystemModels.ShowSeat()
                    {
                        BookingId = newBooking.BookingId,
                        CinemaHallSeatId = cinemaHallSeatId,
                        Price = 100,
                        Status =  (int)SeatStatus.Booked
                    });
                    transaction.Commit();
                    status = true;
                    bookingId = newBooking.BookingId;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    _logger.LogError("Exception in BookShow Currency " + ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception in BookShow " + ex.Message);
                    transaction.Rollback();
                }
            }

            if (!status)
                throw new BusinessException("Error", "Something went wrong!");

            return bookingId;
        }
    }
}
