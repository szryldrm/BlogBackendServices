using CategoryServices.Data.Abstract;
using CategoryServices.Data.Concrete;
using CategoryServices.Service.Abstract;
using CategoryServices.Service.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SYCore.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryServices.Extensions.Messages;

namespace CategoryServices.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryMessages>().As<ICategoryMessages>();

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
