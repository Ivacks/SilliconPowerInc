using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilliconPowerInc.Infrastructure.Contracts.Repositories;
using SilliconPowerInc.Infrastructure.Impl.Context;
using SilliconPowerInc.Infrastructure.Impl.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Impl.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContextPool<SilliconPowerIncDbContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("SilliconPowerInc"));
            });

            service.AddTransient<IUserRepository, UserRepository>();

            return service;
        }
    }
}
