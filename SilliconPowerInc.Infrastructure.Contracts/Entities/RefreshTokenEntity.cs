using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Contracts.Entities
{
    public class RefreshTokenEntity
    {
        public RefreshTokenEntity()
        {
            Sessions = new HashSet<SessionEntity>();
        }

        [Key]
        public Guid Jti { get; set; }
        public string Token { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public virtual ICollection<SessionEntity> Sessions { get; set; }
    }
}
