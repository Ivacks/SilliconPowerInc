using SilliconPowerInc.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Business.Contracts.Services
{
    public interface IUserPasswordManager
    {
        string SetHashedPassWord(UserEntity user, string password);
        bool VerifyPassword(UserEntity user, string password);
    }
}
