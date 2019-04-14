using Inf.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Booking.Domain.Events
{
    public class BookingCreatedEvent : IEvent
    {
        public BookingCreatedEvent(Domain.Model.Booking booking)
        {
            Booking = booking;
        }

        public Domain.Model.Booking Booking { get; }
    }
}
