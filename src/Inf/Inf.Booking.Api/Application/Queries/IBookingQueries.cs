using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Queries
{
    public interface IBookingQueries
    {
        Task<IEnumerable<BookingSummaryDto>> GetBookings();
        Task<BookingDetailDto> GetBooking(int bookingId);
    }
}