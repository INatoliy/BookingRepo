namespace BookingService.Booking.Application.Dates;
class DefaultCurrentDateTimeProvider : ICurrentDateTimeProvider
{
    public DateTimeOffset CurrentDateTime { get; } = DateTimeOffset.UtcNow;
}