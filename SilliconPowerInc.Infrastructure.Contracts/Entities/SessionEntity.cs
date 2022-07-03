using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Contracts.Entities
{
    public class SessionEntity
    {
        public Guid UserId { get; set; }
        public Guid Jti { get; set; }

        [ForeignKey("Jti")]
        public virtual RefreshTokenEntity RefreshToken { get; set; }
        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
    }
}
