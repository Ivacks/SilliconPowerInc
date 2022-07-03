using Microsoft.AspNetCore.Mvc;
using SilliconPowerInc.CrossCutting;
using SilliconPowerInc.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Business.Contracts.Services
{
    public interface IUserService
    {
        Task<OperationResult> RegisterUser(UserDto userDto, CancellationToken cancellationToken);
    }
}
