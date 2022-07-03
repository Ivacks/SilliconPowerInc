using SilliconPowerInc.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Infrastructure.Contracts.Repositories
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
        Task<UserEntity> GetUserByNameAsync(string userName, CancellationToken token);
    }
}
