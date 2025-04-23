using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Application.Contracts.Queries
{
    public class GetBookingByIdQuery
    {
        public long BookingId { get; set; } 
    }
}
