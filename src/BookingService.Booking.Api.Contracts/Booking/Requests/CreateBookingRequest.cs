﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Application.Contracts.Commands
{
    class CreateBookingRequest
    {
        public long UserId { get; set; }
        public long ResourceId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
