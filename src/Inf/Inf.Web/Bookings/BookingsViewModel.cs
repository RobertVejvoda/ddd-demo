using DotVVM.Framework.Controls;
using Inf.Booking.Api.Contracts.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inf.Web.Bookings
{
    public class BookingsViewModel : LayoutViewModel
    {
        private readonly IBookingFacade bookingFacade;

        public IEnumerable<BookingSummaryDto> Bookings { get; set; }

        public BookingsViewModel(IBookingFacade bookingFacade)
        {
            this.bookingFacade = bookingFacade ?? throw new ArgumentNullException(nameof(bookingFacade));
            
            this.PageTitle = "Bookings!";
        }

        public override async Task Load()
        {
            if(!Context.IsPostBack)
            {
                Bookings = await bookingFacade.GetBookingsAsync();
            }

            await base.Load();
        }
    }
}
