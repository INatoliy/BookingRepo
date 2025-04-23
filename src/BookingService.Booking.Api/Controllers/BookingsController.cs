using Microsoft.AspNetCore.Mvc;
using BookingService.Booking.Api.Contracts.Bookings;
using BookingService.Booking.Api.Contracts.Booking.Dtos;
using BookingService.Booking.Application.Contracts.Interfaces;
using BookingService.Booking.Application.Contracts.Commands;
using BookingService.Booking.Application.Contracts.Queries;
using BookingService.Booking.Application.Contracts.Models;
using BookingService.Booking.Domain.Contracts.Models;

namespace BookingService.Booking.Api.Controllers
{
    [Route(WebRoutes.BasePath)]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;
        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpPost(WebRoutes.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookingRequest request)
        {
            // Маппинг DTO API в команду для севисного слоя
            var command = new CreateBookingCommand
            {
                UserId = request.UserId,
                ResourceId = request.ResourceId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            var bookingId = await _bookingsService.CreateAsync(command);
            return CreatedAtAction(nameof(GetBooking), new { id = bookingId });
        }

        [HttpPost(WebRoutes.Cancel)]
        public async Task<IActionResult> CancelBooking(long id)
        {
            var command = new CancelBookingCommand { BookingId = id };
            await _bookingsService.CancelAsync(command);
            return NoContent();
        }

        [HttpGet(WebRoutes.GetById)]
        public async Task<ActionResult<BookingData>> GetBooking(long id)
        {
            var query = new GetBookingByIdQuery { BookingId = id };
            var bookingDto = await _bookingsService.GetByIdAsync(query);
            return Ok(MapToBookingData(bookingDto));
        }

        [HttpGet(WebRoutes.GetByFilter)]
        public async Task<ActionResult<BookingData[]>> GetBookingsByFilter([FromQuery] GetBookingsByFilterRequest request)
        {
            var query = new GetBookingsByFilterQuery
            {
                UserId = request.UserId,
                ResourceId = request.ResourceId,
                Status = request.Status != null ? Enum.Parse<BookingStatus>(request.Status) : null,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var bookings = await _bookingsService.GetByFilterAsync(query);
            return Ok(bookings.Select(MapToBookingData).ToArray());
        }
      
        [HttpGet(WebRoutes.GetStatusById)]
        public async Task<ActionResult<string>> GetBookingStatus(long id)
        {
            var query = new GetBookingStatusByIdQuery { BookingId = id };
            var status = await _bookingsService.GetStatusByIdAsync(query);
            return Ok(status.ToString());
        }

        // Маппинг
        private static BookingData MapToBookingData(BookingDto bookingDto)
        {
            return new BookingData
            {
                Id = bookingDto.Id,
                Status = bookingDto.Status.ToString(),
                UserId = bookingDto.UserId,
                ResourceId = bookingDto.ResourceId,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                CreatedDate = bookingDto.CreatedDate
            };
        }

    }
}

