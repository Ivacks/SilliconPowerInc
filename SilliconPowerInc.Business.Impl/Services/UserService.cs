using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilliconPowerInc.Business.Contracts.Domain;
using SilliconPowerInc.Business.Contracts.Services;
using SilliconPowerInc.CrossCutting;
using SilliconPowerInc.Dtos;
using SilliconPowerInc.Infrastructure.Contracts.Entities;
using SilliconPowerInc.Infrastructure.Contracts.Repositories;
using SilliconPowerInc.Infrastructure.Impl.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SilliconPowerInc.Business.Impl.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork<SilliconPowerIncDbContext> _uow;
        private readonly IRoleBackupRepository _roleBackupRepository;
        private readonly IUserPasswordManager _userPasswordManager;

        public UserService(ILogger<UserService> logger, IUserRepository repository, IUnitOfWork<SilliconPowerIncDbContext> uow, IRoleBackupRepository roleBackupRepository, IUserPasswordManager userPasswordManager)
        {
            _logger = logger;
            _repository = repository;
            _uow = uow;
            _roleBackupRepository = roleBackupRepository;
            _userPasswordManager = userPasswordManager;
        }

        public async Task<OperationResult> RegisterUser(UserDto userDto, CancellationToken cancellationToken)
        {
            OperationResult operationResult = new OperationResult();

            if ((await _repository.FindAsync(u => u.UserName.Equals(userDto.Username), cancellationToken)) == null)
            {
                UserEntity user = new UserEntity();
                user.Id = Guid.NewGuid();
                user.UserName = userDto.Username;
                user.HashedPassword = _userPasswordManager.SetHashedPassWord(user, userDto.Password);

                foreach (var roleName in userDto.Roles)
                {
                    var role = await _roleBackupRepository.FindAsync(r => r.Name.Equals(roleName), cancellationToken);

                    if (role != null)
                    {
                        user.UserRoles.Add(new UserRoleEntity()
                        {
                            Role = role,
                            User = user,
                            RoleId = role.Id,
                            UserId = user.Id
                        });

                    }
                    else
                    {
                        operationResult.AddError(1, $"The role {roleName} doesn't exists.");
                    }
                }

                await _repository.AddDataAsync(user, cancellationToken);
                await _repository.SaveChangesAsync();
            }
            else
            {
                operationResult.AddError(2, $"The user {userDto.Username} already exists.");
            }

            return operationResult;
        }
    }
}
