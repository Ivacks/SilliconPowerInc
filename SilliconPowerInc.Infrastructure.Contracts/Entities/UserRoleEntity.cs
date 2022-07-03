using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Contracts.Entities
{
    public class UserRoleEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity Role { get; set; }
        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
    }
}
