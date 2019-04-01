using Inf.Booking.Api.Infrastructure;
using Inf.Booking.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Inf.Booking.Domain;

namespace Inf.Booking.Api.Application.Queries
{
    public class BookingQueries
    {
        private readonly BookingContext bookingContext;

        public BookingQueries(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<BookingSummaryDto>> GetBookings(DateRange dateRange) 
        { 
        }

        public async Task<BookingDetailDto> GetBooking(int bookingId)
        {
            
        }
    }
}
