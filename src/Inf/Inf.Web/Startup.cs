using Autofac;
using Autofac.Extensions.DependencyInjection;
using DotVVM.Framework.ViewModel.Serialization;
using Inf.Web.Infrastructure.Configuration;
using Inf.Web.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Inf.Web
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")                                            // General JSON file
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)     // Environment specific JSON file
                .AddEnvironmentVariables();                                                 // Environment variables

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IViewModelLoader>(p => new AutofacViewModelLoader(p, ApplicationContainer));

            services.AddMvc().AddControllersAsServices();
            services.AddDotVVM<DotvvmStartup>();

            services.AddOptions();
            services.AddLogging();

            services.Configure<ConfigurationOptions>(Configuration);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var container = new ContainerBuilder();
            container.Populate(services);
            container.RegisterModule(new ApplicationModule());
            ApplicationContainer = container.Build();
            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);

            app.UseMvc();

            // dispose container
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
