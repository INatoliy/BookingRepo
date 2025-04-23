using BookingService.Booking.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingService.Booking.Application.Contracts.Commands;
using BookingService.Booking.Application.Contracts.Queries;
using BookingService.Booking.Application.Contracts.Interfaces;
using BookingService.Booking.Application.Contracts.Models;
using BookingService.Booking.Application.Contracts.Exceptions;
using BookingService.Booking.Domain.Contracts.Exceptions;


namespace BookingService.Booking.Application
{
    class BookingsService : IBookingsService
    {

        public Task<long> CreateAsync(CreateBookingCommand command)
        {
            if (command.UserId <= 0 || command.ResourceId <= 0)
                throw new ValidationException("UserId и ResourceId должны быть больше 0.");

            throw new ValidationException("Заглушка");
        }
        public Task<BookingDto> GetByIdAsync(GetBookingByIdQuery idQuery)
        {
            throw new NotImplementedException();
        }
        public Task CancelAsync(CancelBookingCommand command)
        {
            if (command.BookingId <= 0)
                throw new DomainException("Некорректный идентификатор бронирования");

            throw new DomainException("Заглушка");
        }
        public Task<BookingDto[]> GetByFilterAsync(GetBookingsByFilterQuery filterQuery)
        {
            throw new NotImplementedException();
        }
        public Task<BookingStatus> GetStatusByIdAsync(GetBookingStatusByIdQuery idQuery)
        {
            throw new NotImplementedException();
        }

    }
}
