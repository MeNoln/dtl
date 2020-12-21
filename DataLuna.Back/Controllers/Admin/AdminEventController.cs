using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Services;
using DataLuna.Back.Common.Attributes;
using DataLuna.Back.Common.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("admin/event")]
    [AdminAuthorize]
    public class AdminEventController : ControllerBase
    {
        private readonly IAdminEventService _eventService;
        public AdminEventController(IAdminEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(await _eventService.GetEvents());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute]long id)
        {
            return Ok(await _eventService.GetEvent(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]CreateEventCommand command)
        {
            await _eventService.CreateEvent(command);
            return Ok();
        }

        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeEventStatus([FromBody]UpdateEventStatusCommand command)
        {
            await _eventService.UpdateEventStatus(command);
            return Ok();
        }
    }
}