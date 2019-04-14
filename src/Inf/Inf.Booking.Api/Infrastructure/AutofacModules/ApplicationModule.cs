using Autofac;
using Inf.Booking.Api.Application.Commands;
using Inf.Booking.Api.Application.Queries;
using Inf.Booking.Domain.Model;
using Inf.Booking.Infrastructure.Repository;
using Inf.Core.Commands;
using System.Reflection;

namespace Inf.Booking.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookingQueries>()
                .As<IBookingQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingRepository>()
                .As<IBookingRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(BookingCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>));
        }
    }
}
