using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Web
{
    public class WebRouteStrategy : DefaultRouteStrategy
    {
        public WebRouteStrategy(DotvvmConfiguration configuration, string viewsFolder = "Bookings", string pattern = "*.dothtml") : base(configuration, viewsFolder, pattern)
        {
        }

        protected override string GetRouteUrl(RouteStrategyMarkupFileInfo file)
        {
            var url = file.AppRelativePath;
            if (url.Contains("Bookings/"))
            {
                // instead of /home, we need the route to be directly in the website root /
                url = url.Replace("Bookings/", "");
            }

            if (url.Contains("Default.dothtml"))
            {
                url = url.Replace("Default.dothtml", "");
            }

            return url;
        }
    }
}
