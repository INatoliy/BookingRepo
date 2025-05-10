using BookingService.Booking.Domain.Bookings;

namespace BookingService.Booking.Domain;

public interface IUnitOfWOrk
{
    public IBookingsRepository BookingRepository { get; }
    public Task CommitAsync(CancellationToken cancellationToken = default);
}