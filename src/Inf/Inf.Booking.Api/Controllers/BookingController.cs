using Inf.Booking.Api.Application.Commands;
using Inf.Booking.Api.Application.Queries;
using Inf.Booking.Api.Infrastructure;
using Inf.Booking.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingQueries queries;
        private readonly ICommandHandler<CreateBookingCommand> createBookingCommandHandler;
        private readonly ICommandHandler<CancelBookingCommand> cancelBookingCommandHandler;

        public BookingController(IBookingQueries queries, 
            ICommandHandler<CreateBookingCommand> createBookingCommandHandler,
            ICommandHandler<CancelBookingCommand> cancelBookingCommandHandler)
        {
            this.queries = queries;
            this.createBookingCommandHandler = createBookingCommandHandler;
            this.cancelBookingCommandHandler = cancelBookingCommandHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingSummaryDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<BookingSummaryDto>>> GetBookings()
        {
            var bookings = await queries.GetBookings();
            return Ok(bookings);
        }

        [Route("{bookingId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingDetailDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBooking(int bookingId)
        {
            try
            {
                var bookings = await queries.GetBooking(bookingId);
                return Ok(bookings);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBookingAsync([FromBody]CreateBookingCommand command)
        {
            try
            {
                await createBookingCommandHandler.HandleAsync(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("cancel")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelBookingAsync([FromBody]CancelBookingCommand command)
        {
            try
            {
                await cancelBookingCommandHandler.HandleAsync(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
