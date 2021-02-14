using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Events;

namespace DataLuna.Back.Services
{
    public interface IAdminEventService
    {
        Task<GetAllEventsResponse> GetEvents();
        Task<EventDto> GetEvent(long eventId);
        Task CreateEvent(CreateEventCommand command);
        Task UpdateTwitchLink(int eventId, UpdateTwtichLinkCommand command);
        Task UpdateEventStatus(UpdateEventStatusCommand command);
    }
}