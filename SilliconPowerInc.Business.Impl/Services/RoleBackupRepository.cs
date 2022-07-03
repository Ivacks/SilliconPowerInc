using SilliconPowerInc.Business.Contracts.Services;
using SilliconPowerInc.Infrastructure.Contracts.Entities;
using SilliconPowerInc.Infrastructure.Impl.Context;
using SilliconPowerInc.Infrastructure.Impl.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Business.Impl.Services
{
    public class RoleBackupRepository : Repository<SilliconPowerIncDbContext, RoleEntity, Guid>, IRoleBackupRepository
    {
        public RoleBackupRepository(SilliconPowerIncDbContext context) : base(context)
        {

        }
    }
}
