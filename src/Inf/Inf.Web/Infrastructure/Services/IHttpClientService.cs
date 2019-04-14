using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inf.Web.Infrastructure.Services
{
    public interface IHttpClientService
    {
        HttpClient GetHttpClient();
    }
}
