namespace BookingService.Booking.Application.Dates;
interface ICurrentDateTimeProvider
{
    DateTimeOffset CurrentDateTime { get; }
}