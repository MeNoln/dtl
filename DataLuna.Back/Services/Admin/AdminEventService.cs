using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLuna.Back.Common.Events;
using DataLuna.Back.Common.Exceptions;
using DataLuna.Back.Persistence;
using DataLuna.Back.Domain;
using DataLuna.Back.Domain.Enum;

namespace DataLuna.Back.Services
{
    public class AdminEventService : IAdminEventService
    {
        private readonly DataLunaDbContext _dbContext;
        public AdminEventService(DataLunaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetAllEventsResponse> GetEvents()
        {
            var events = await _dbContext.Events.AsNoTracking()
                .Select(s => new EventDto
                {
                    Id = s.Id,
                    EventDate = s.EventDate,
                    Status = s.Status,
                })
                .ToArrayAsync();
            
            return new GetAllEventsResponse { Events = events };
        }

        public Task<EventDto> GetEvent(long eventId)
            => _dbContext.Events.AsNoTracking()
                .Include(c => c.TeamA)
                .Include(c => c.TeamB)
                .Where(w => w.Id == eventId)
                .Select(s => new EventDto
                {
                    EventDate = s.EventDate,
                    Status = s.Status,
                    TeamAName = s.TeamA.Name,
                    TeamBName = s.TeamB.Name,
                })
                .FirstOrDefaultAsync();

        public Task CreateEvent(CreateEventCommand command)
        {
            var gameEvent = new GameEvent
            {
                TeamAId = command.TeamAId,
                TeamBId = command.TeamBId,
                EventDate = command.EventDate,
                Status = command.Status,
                EventType = command.Type,
                Name = command.Name,
            };

            _dbContext.Events.Add(gameEvent);

            return _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTwitchLink(int eventId, UpdateTwtichLinkCommand command)
        {
            var ev = await _dbContext.Events.FirstOrDefaultAsync();
            if (ev == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);

            ev.TwitchLink = command.Url;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEventStatus(UpdateEventStatusCommand command)
        {
            var gameEvent = await _dbContext.Events.AsNoTracking().FirstOrDefaultAsync(f => f.Id == command.Id);
            if (gameEvent == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);

            gameEvent.Status = command.Status;

            _dbContext.Events.Update(gameEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}