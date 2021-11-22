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

        public void BookShow(string userName, int showSeatId)
        {
            _logger.LogDebug(string.Format("BookShow for username {0} and seatid {1}" ,  userName ,  showSeatId));
            var showSeat = _applicationContext.ShowSeat.SingleOrDefault(x => x.ShowSeatId == showSeatId);

            if (showSeat == null)
                throw new BusinessException("Invalid Operation","Seat not present.");
            
            if (showSeat.Status == (int)SeatStatus.Booked)
                throw new BusinessException("Seat not avilable", "Seat already booked.");


            bool status = false;
            using (var transaction = _applicationContext.Database.BeginTransaction())
            {
                try
                {
                    showSeat.Status = (int)SeatStatus.Booked;
                    _applicationContext.SaveChanges();
                    _applicationContext.Booking.Add(new Models.SystemModels.Booking()
                    {
                        DateTime = DateTime.Now,
                        ShowSeatId = showSeat.ShowSeatId,
                        UserName = userName,
                        Status = (int)BookingStatus.Booked
                    });
                    _applicationContext.SaveChanges();
                    transaction.Commit();
                    status = true;
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

        }
    }
}
