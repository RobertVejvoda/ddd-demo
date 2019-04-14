using Autofac;
using Autofac.Extensions.DependencyInjection;
using Inf.Booking.Api.Infrastructure.AutofacModules;
using Inf.Booking.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Inf.Booking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();

            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<BookingContext>(options =>
                   {
                       options.UseSqlServer(Configuration["ConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(BookingContext).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Booking HTTP API",
                    Version = "v1",
                    Description = "The Booking Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            services.AddOptions();
            services.Configure<BookingSettings>(Configuration);
            services.Configure<ApiBehaviorOptions>(options =>
                 {
                     options.InvalidModelStateResponseFactory = context =>
                     {
                         var problemDetails = new ValidationProblemDetails(context.ModelState)
                         {
                             Instance = context.HttpContext.Request.Path,
                             Status = StatusCodes.Status400BadRequest,
                             Detail = "Please refer to the errors property for additional details."
                         };

                         return new BadRequestObjectResult(problemDetails)
                         {
                             ContentTypes = { "application/problem+json", "application/problem+xml" }
                         };
                     };
                 });

            var container = new ContainerBuilder();
            container.Populate(services);
            container.RegisterModule(new ApplicationModule());
            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking.API V1");
               });
        }
    }
}
