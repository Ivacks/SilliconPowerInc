using SilliconPowerInc.Infrastructure.Contracts.Entities;
using SilliconPowerInc.Infrastructure.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Business.Contracts.Services
{
    public interface IRoleBackupRepository : IRepository<RoleEntity, Guid>
    {
    }
}
