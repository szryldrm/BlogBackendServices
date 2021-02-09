using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IoC;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        private IConfiguration _configuration;

        public CoreModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            services.AddSingleton<ICacheManager, RedisCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
