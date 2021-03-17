using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using LogServices.Data.Abstract;
using LogServices.Data.Concrete;
using LogServices.Extensions.Messages;
using LogServices.Service.Abstract;
using LogServices.Service.Concrete;
using SYCore.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogService>().As<ILogService>();
            builder.RegisterType<LogRepository>().As<ILogRepository>();
            builder.RegisterType<LogMessages>().As<ILogMessages>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(
                    new ProxyGenerationOptions()
                    {
                        Selector = new AspectInterceptorSelector()
                    }).SingleInstance();
        }
    }
}
