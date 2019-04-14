using Inf.Booking.Api.Contracts.Commands;
using Inf.Booking.Domain.Model;
using Inf.Booking.Infrastructure.Repository;
using Inf.Core.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Commands
{
    public class BookingCommandHandler : ICommandHandler<CreateBookingCommand>, ICommandHandler<CancelBookingCommand>
    {
        private readonly IBookingRepository bookingRepository;

        public BookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<int> HandleAsync(CreateBookingCommand message, CancellationToken cancellationToken)
        {
            var court = await bookingRepository.GetCourtAsync(message.CourtId);
            var booking = new Domain.Model.Booking(message.PhoneNo, court, message.BookedFrom);
            bookingRepository.Add(booking);

            return await bookingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> HandleAsync(CancelBookingCommand message, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.GetBookingAsync(message.BookingId);
            booking.Cancel();
            bookingRepository.Add(booking);

            return await bookingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
