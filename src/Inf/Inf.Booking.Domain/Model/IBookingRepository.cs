using Inf.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Booking.Domain.Model
{
    public interface IBookingRepository : IRepository<Model.Booking>
    {
        Task<Court> GetCourtAsync(int courtId);
        Task<Domain.Model.Booking> GetBookingAsync(int bookingId);
        void Add(Domain.Model.Booking booking);
    }
}
