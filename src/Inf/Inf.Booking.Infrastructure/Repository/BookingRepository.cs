using Inf.Booking.Domain;
using Inf.Booking.Domain.Events;
using Inf.Booking.Domain.Model;
using Inf.Booking.Infrastructure.Entities;
using Inf.Booking.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace Inf.Booking.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext context;

        public IUnitOfWork UnitOfWork => context;

        public BookingRepository(BookingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Court> GetCourtAsync(int courtId)
        {
            var entity = await context.Set<CourtEntity>().FindAsync(courtId);
            if (entity != null)
            {
                return new Court(entity.Id, (CourtType)entity.CourtType);
            }

            return null;
        }

        public async Task<Domain.Model.Booking> GetBookingAsync(int bookingId)
        {
            var bookingEntity = await context.Set<BookingEntity>().FindAsync(bookingId);
            if (bookingEntity != null)
            {
                // load court
                await context.Entry(bookingEntity).Reference(i => i.Court).LoadAsync();
                var court = new Court(bookingEntity.Court.Id, (CourtType) bookingEntity.Court.CourtType);

                return new Domain.Model.Booking(bookingEntity.Id, bookingEntity.PhoneNo, court, bookingEntity.BookedFrom, (BookingStatus) bookingEntity.Status);
            }

            return null;
        }

        public void Add(Domain.Model.Booking booking)
        {
            foreach (var e in booking.DequeueDomainEvents())
                Handle((dynamic)e);
        }

        private void Handle(BookingCreatedEvent e)
        {
            var entity = new BookingEntity()
            {
                PhoneNo = e.Booking.PhoneNo,
                CourtId = e.Booking.Court.Id,
                BookedFrom = e.Booking.BookedFrom,
                BookedTo = e.Booking.BookedTo,
                Status = (int) e.Booking.Status,
                CreatedBy = "Anonymous",
                CreatedDate = DateTime.Now,
            };
            context.Set<BookingEntity>().Add(entity);
        }

        private void Handle(BookingCancelledEvent e)
        {
            var booking = context.Set<BookingEntity>().Find(e.Booking.Id);
            booking.Status = (int) e.Booking.Status;
            booking.ModifiedBy = "Anonymous";
            booking.ModifiedDate = DateTime.Now;
            context.Set<BookingEntity>().Update(booking);
        }
    }
}
