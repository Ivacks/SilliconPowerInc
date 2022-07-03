using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilliconPowerInc.Business.Contracts.Domain;
using SilliconPowerInc.Business.Impl.Domain;
using SilliconPowerInc.Infrastructure.Impl.Context;
using SilliconPowerInc.Infrastructure.Impl.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Business.Impl.Extensions
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddInfrastructureServices(configuration);

            service.AddTransient<IUnitOfWork<SilliconPowerIncDbContext>, UnitOfWork<SilliconPowerIncDbContext>>();


            return service;
        }
    }
}
