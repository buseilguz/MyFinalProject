using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
 