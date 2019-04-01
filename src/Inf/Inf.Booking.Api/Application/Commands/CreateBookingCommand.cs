using Inf.Booking.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Commands
{
    public class CreateBookingCommand
    {
        private readonly BookingRepository bookingRepository;

        public CreateBookingCommand(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public void Execute()
        {

        }
    }
}
