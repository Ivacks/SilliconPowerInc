using Microsoft.EntityFrameworkCore;
using SilliconPowerInc.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Infrastructure.Impl.Context
{
    public class SilliconPowerIncDbContext : DbContext
    {
        public SilliconPowerIncDbContext(DbContextOptions<SilliconPowerIncDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserRoleEntity> UsersRoles { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<SessionEntity> Sessions { get; set; }
        public virtual DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=SilliconPowerIncBackup;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionEntity>().HasKey(e => new { e.Jti, e.UserId });
            modelBuilder.Entity<UserRoleEntity>().HasKey(e => new { e.UserId, e.RoleId });
        }

    }
}
