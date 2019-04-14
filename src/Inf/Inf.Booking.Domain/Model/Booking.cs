using Inf.Booking.Domain.Events;
using Inf.Core.Domain;
using System;

namespace Inf.Booking.Domain.Model
{
    public class Booking : DomainObject, IAggregateRoot
    {
        public Booking(string phoneNo, Court court, DateTime bookedFrom)
        {
            PhoneNo = phoneNo;
            Court = court;
            BookedFrom = bookedFrom;
            BookedTo = bookedFrom.AddHours(1);
            Status = BookingStatus.Active;

            EnqueueDomainEvent(new BookingCreatedEvent(this));
        }

        public Booking(int id, string phoneNo, Court court, DateTime bookedFrom, BookingStatus status)
        {
            base.Id = id;
            PhoneNo = phoneNo;
            Court = court;
            BookedFrom = bookedFrom;
            BookedTo = bookedFrom.AddHours(1);
            Status = status;
        }

        public void Cancel()
        {
            if (Status == BookingStatus.Cancelled)
                throw new Exception("Booking is already cancelled.");

            Status = BookingStatus.Cancelled;
            EnqueueDomainEvent(new BookingCancelledEvent(this));
        }

        public string PhoneNo { get; }
        public Court Court { get; }
        public DateTime BookedFrom { get; }
        public DateTime BookedTo { get; }
        public BookingStatus Status { get; private set; }
    }
}
