using Microsoft.AspNetCore.Identity;
using SilliconPowerInc.Business.Contracts.Services;
using SilliconPowerInc.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Business.Impl.Services
{
    public class UserPasswordManager : IUserPasswordManager
    {
        public string SetHashedPassWord(UserEntity user, string password)
        {
            PasswordHasher<UserEntity> hasher = new PasswordHasher<UserEntity>();
            return hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(UserEntity user, string password)
        {
            PasswordHasher<UserEntity> hasher = new PasswordHasher<UserEntity>();
            var result = hasher.VerifyHashedPassword(user, user.HashedPassword, password);

            return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
