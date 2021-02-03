using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;
using DataLuna.Back.Common.Attributes;
using DataLuna.Back.Infrastructure.DemoParse;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("admin/proxy")]
    [AdminAuthorize]
    public class AdminParserProxyController : ControllerBase
    {
        private readonly IDemoParseProvider _parserProvider;
        public AdminParserProxyController(IDemoParseProvider parserProvider)
            => (_parserProvider) = (parserProvider);

        [HttpGet("state")]
        public async Task<IActionResult> GetState()
        {
            return Ok(await _parserProvider.GetDemosStatus());
        }

        [HttpPost("demodata")]
        public async Task<IActionResult> PostDemoData([FromBody]DemoParseCommand command)
        {
            return Ok(await _parserProvider.ParseDemo(command));
        }

        [HttpPost("preparse")]
        public async Task<IActionResult> PreparseData([FromBody]PreParseCommand command)
        {
            return Ok(await _parserProvider.PreParseDemo(command));
        }
    }
}