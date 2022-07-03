using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SilliconPowerInc.Business.Contracts.Services;
using SilliconPowerInc.Dtos;
using System.Threading;

namespace SilliconPowerInc.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Insert new user in the database.
        /// </summary>
        /// <param name="userDto">Introduce username, password, and a list of roles. </param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
        {
            var operationResult = await _userService.RegisterUser(userDto, new CancellationToken());
            if (operationResult.HasErrors)
            {
                return BadRequest(operationResult.Errors);
            }
            else
            {
                return Ok();
            }
        }

        /// <summary>
        /// Insert new user in the database.
        /// </summary>
        /// <param name="userDto">Introduce username, password, and a list of roles. </param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> OnPost([FromBody] UserDto userDto)
        {
            var operationResult = await _userService.RegisterUser(userDto, new CancellationToken());
            if (operationResult.HasErrors)
            {
                return BadRequest(operationResult.Errors);
            }
            else
            {
                return Ok();
            }
        }


    }
}
