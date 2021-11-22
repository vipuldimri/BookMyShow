using BookMyShow.Interfaces;
using BookMyShow.Models.DTOModels.InputDTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly ILoggerManager _logger;
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService ,ILoggerManager logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        // Booking
        // api/Booking
        /// <summary>
        /// Booking movie show
        /// <returns>201 created</returns>
        /// <response code="200">If everyting is fine return 201</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult BookShow([FromBody] BookingInputDTO bookingInputDTO)
        {
            _logger.LogDebug(string.Format("BookShow api involked for username {0} and cinemaHallSeatId {1}", bookingInputDTO.userName, bookingInputDTO.cinemaHallSeatId));
            if (!validatetoken(bookingInputDTO.token))
            {
                return Unauthorized();
            }
            int bookingId =  _bookingService.BookShow(bookingInputDTO.userName, bookingInputDTO.ShowId , bookingInputDTO.cinemaHallSeatId);
            return Ok(bookingId);
        }

        /// <summary>
        /// Validating token 24 hr 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool validatetoken(string token)
        {
            try
            {
                byte[] data = Convert.FromBase64String(token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when < DateTime.UtcNow.AddHours(-24))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
