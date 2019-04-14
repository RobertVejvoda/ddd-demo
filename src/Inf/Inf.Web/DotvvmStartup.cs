using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Bootstrap4;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Web
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void ConfigureServices(IDotvvmServiceCollection services)
        {
            services.AddDefaultTempStorages("Temp");
        }

        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrap4Configuration();
            config.RouteTable.AutoDiscoverRoutes(new WebRouteStrategy(config));
        }
    }
}
