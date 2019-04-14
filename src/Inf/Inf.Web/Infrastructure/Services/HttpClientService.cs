using System.Net.Http;

namespace Inf.Web.Infrastructure.Services
{
    internal class HttpClientService : IHttpClientService
    {
        private readonly HttpClient httpClient;

        public HttpClientService()
        {
            httpClient = new HttpClient(new HttpClientHandler());
        }

        public HttpClient GetHttpClient() => httpClient;
    }
}
