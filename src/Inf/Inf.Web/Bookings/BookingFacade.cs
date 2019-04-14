using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inf.Booking.Api.Contracts.Queries;
using Inf.Web.Bookings.Request;
using Inf.Web.Infrastructure.Configuration;
using Inf.Web.Infrastructure.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Inf.Web.Bookings
{
    public class BookingFacade : IBookingFacade
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettings> options;

        public BookingFacade(IHttpClientService httpClientService, IOptions<AppSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            var svc = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            httpClient = svc.GetHttpClient();
        }

        public async Task<BookingDetailDto> GetBookingDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingSummaryDto>> GetBookingsAsync()
        {
            // naive impl. first...
            var response = await httpClient.GetStringAsync(options.Value.BookingApi);
            return JsonConvert.DeserializeObject<List<BookingSummaryDto>>(response);
        }
    }
}
