using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Services;
using DataLuna.Back.Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("admin/demo")]
    [AdminAuthorize]
    public class AdminDemoController : ControllerBase
    {
        [HttpGet("preparse")]
        public IActionResult PreParseDemo()
        {
            return Ok(new {message = "stub"});
        }

        [HttpGet("parse")]
        public IActionResult ParseDemo()
        {
            return Ok(new {message = "stub"});
        }
    }
}