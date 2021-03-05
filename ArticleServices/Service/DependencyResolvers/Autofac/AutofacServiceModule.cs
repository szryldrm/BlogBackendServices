using ArticleServices.Data.Abstract;
using ArticleServices.Data.Concrete;
using ArticleServices.Extensions.Messages;
using ArticleServices.Service.Abstract;
using ArticleServices.Service.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SYCore.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<ArticleMessages>().As<IArticleMessages>();

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
