using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPowerInc.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
