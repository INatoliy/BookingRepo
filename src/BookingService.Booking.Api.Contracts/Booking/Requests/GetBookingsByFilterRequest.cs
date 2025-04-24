using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Application.Contracts.Commands
{
   public class GetBookingsByFilterRequest
    {
        public string? Status { get; set; }
        public long? UserId { get; set; }
        public long? ResourceId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}
