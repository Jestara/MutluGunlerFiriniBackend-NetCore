using Microsoft.Extensions.DependencyInjection;
using MutluGunlerFirini.Core.CrossCuttingConcerns.Caching;
using MutluGunlerFirini.Core.CrossCuttingConcerns.Caching.Microsoft;
using MutluGunlerFirini.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Core.DependecyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<Stopwatch>();
        }
    }
}
