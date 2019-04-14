using Autofac;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Inf.Web.Infrastructure.Facade;
using Inf.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Inf.Web.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly)
                .AssignableTo<DotvvmViewModelBase>()
                // .PropertiesAutowired(new DefaultPropertySelector(preserveSetValues: true))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly)
                .AssignableTo<IDotvvmPresenter>()
                .InstancePerDependency();

            builder.RegisterType<HttpClientService>()
                .As<IHttpClientService>()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly)
                .As<IAppFacade>()
                .AsImplementedInterfaces()
                .InstancePerDependency();                
        }
    }
}
