using System;
using System.Collections.Generic;
using System.Text;

namespace Inf.Booking.Domain.Factory
{
    public class DomainFactory
    {
        public Booking CreateBooking()
        {
            return new Inf.Booking()
        }
    }
}
