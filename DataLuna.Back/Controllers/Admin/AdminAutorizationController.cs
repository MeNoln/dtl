using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DataLuna.Back.Common.AdminUsers;

namespace DataLuna.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminAutorizationController : ControllerBase
    {
        [HttpPost("SignIn")]
        public IActionResult SignIn([FromBody]AdminSignInCommand command)
        {
            var admin = AdminsCollection.Admins.FirstOrDefault(f => (f.Login, f.Password) == (command.Login, command.Password));
            if (admin == null)
                return Unauthorized();

            return Ok(new { token = admin.Token });
        }
    }
}