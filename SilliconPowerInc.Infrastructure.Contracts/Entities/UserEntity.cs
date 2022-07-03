using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Contracts.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Sessions = new HashSet<SessionEntity>();
            UserRoles = new HashSet<UserRoleEntity>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }

        public virtual ICollection<SessionEntity> Sessions { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
