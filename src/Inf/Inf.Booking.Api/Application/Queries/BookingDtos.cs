using Inf.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Queries
{
    public class BookingSummaryDto
    {
        public int BookingId { get; set; }
        public string Phone { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Court { get; set; }
        public string CourtName { get; set; } 
    }

    public class BookingDetailDto
    {
        public int BookingId { get; set; }
        public string Phone { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Court { get; set; }
        public string CourtName { get; set; }
        public string BookedBy { get; set; }
        public DateTime DateBooked { get; set; }
    }
}
