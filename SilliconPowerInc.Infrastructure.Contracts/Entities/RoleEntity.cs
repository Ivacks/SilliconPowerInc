using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Contracts.Entities
{
    public class RoleEntity
    {
        public RoleEntity()
        {
            UserRoles = new HashSet<UserRoleEntity>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
