using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Services;
using DataLuna.Back.Common.Attributes;
using DataLuna.Back.Common.DemoParserProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("admin/demo")]
    [AdminAuthorize]
    public class AdminDemoController : ControllerBase
    {
        private readonly IAdminDemoService _demoService;
        public AdminDemoController(IAdminDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpPost("savedemo")]
        public async Task<IActionResult> SaveDemo([FromBody]NewDemoCommand demo)
        {
            await _demoService.SaveDemoData(demo);

            return Ok();
        }
    }
}