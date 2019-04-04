﻿using Inf.Booking.Domain.Model;
using Inf.Booking.Infrastructure;
using Inf.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Queries
{
    public class BookingQueries : IBookingQueries
    {
        private readonly BookingContext bookingContext;

        public BookingQueries(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<BookingSummaryDto>> GetBookings()
        {
            return await bookingContext.Set<BookingEntity>()
                .Select(x => new BookingSummaryDto()
                {
                    BookingId = x.Id,
                    PhoneNo = x.PhoneNo,
                    CourtId = x.Court.Id,
                    CourtType = (CourtType) x.Court.CourtType,
                    BookedFrom = x.BookedFrom,
                    BookedTo = x.BookedTo,
                    Status = (BookingStatus) x.Status
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BookingDetailDto> GetBooking(int bookingId)
        {
            return await bookingContext.Set<BookingEntity>()
                .Where(x => x.Id == bookingId)
                .Select(x => new BookingDetailDto()
                {
                    BookingId = x.Id,
                    PhoneNo = x.PhoneNo,
                    CourtId = x.Court.Id,
                    CourtType = (CourtType)x.Court.CourtType,
                    BookedFrom = x.BookedFrom,
                    BookedTo = x.BookedTo,
                    Status = (BookingStatus)x.Status,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,

                })
                .SingleOrDefaultAsync();
        }
    }
}
