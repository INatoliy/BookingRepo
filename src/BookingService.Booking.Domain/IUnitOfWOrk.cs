using BookingService.Booking.Domain.Bookings;

namespace BookingService.Booking.Domain;

public interface IUnitOfWork
{
    public IBookingsRepository BookingRepository { get; }
    public Task CommitAsync(CancellationToken cancellationToken = default);
}