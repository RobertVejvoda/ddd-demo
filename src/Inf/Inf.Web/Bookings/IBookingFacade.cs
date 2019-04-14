using Inf.Booking.Api.Contracts.Queries;
using Inf.Web.Bookings.Request;
using Inf.Web.Infrastructure.Facade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inf.Web.Bookings
{
    public interface IBookingFacade : IAppFacade
    {
        Task<BookingDetailDto> GetBookingDetailsAsync();
        Task<IEnumerable<BookingSummaryDto>> GetBookingsAsync();
    }
}
