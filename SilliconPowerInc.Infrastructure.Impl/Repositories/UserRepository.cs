using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SilliconPowerInc.Infrastructure.Contracts.Entities;
using SilliconPowerInc.Infrastructure.Contracts.Repositories;
using SilliconPowerInc.Infrastructure.Impl.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Infrastructure.Impl.Repositories
{
    public class UserRepository : Repository<SilliconPowerIncDbContext, UserEntity, Guid>,IUserRepository
    {
        public UserRepository(SilliconPowerIncDbContext context) : base(context)
        {
        }

        public async Task<UserEntity> GetUserByNameAsync(string userName, CancellationToken token)
        {
            var user = await DbSet.SingleOrDefaultAsync(u => u.UserName.Equals(userName), token);
            user.UserRoles = await Context.UsersRoles.Where(ur => ur.UserId.Equals(user.Id)).ToListAsync(token);

            foreach (var userRole in user.UserRoles)
            {
                userRole.Role = await Context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.RoleId, token);
            }

            user.Sessions = await Context.Sessions.Where(ur => ur.UserId.Equals(user.Id)).ToListAsync(token);

            foreach (var session in user.Sessions)
            {
                session.RefreshToken = await Context.RefreshTokens.FirstOrDefaultAsync(r => r.Jti == session.Jti, token);
            }

            return user;
        }
    }
}
