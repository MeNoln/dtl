using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using DataLuna.Back.Persistence;
using DataLuna.Back.Common.Exceptions;
using DataLuna.Back.Common.DemoParserProxy;

namespace DataLuna.Back.Services
{
    public class ClientEventService : IClientEventService
    {
        private readonly DataLunaDbContext _context;
        public ClientEventService(DataLunaDbContext context)
        {
            _context = context;
        }

        public async Task GetEvent(int id)
        {
            var ev = await _context.Events.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
            if (ev == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var teamADemos = (await _context.Demos.AsNoTracking()
                .Where(w => w.TeamAId == ev.TeamAId || w.TeamBId == ev.TeamAId)
                .OrderByDescending(o => o.DateCreated)
                .Select(s => s.DemoData)
                .Take(10)
                .ToListAsync())
                .Select(s => JsonConvert.DeserializeObject<DemoParseResponse>(s))
                .ToArray();

            var teamBDemos = (await _context.Demos.AsNoTracking()
                .Where(w => w.TeamAId == ev.TeamBId || w.TeamBId == ev.TeamBId)
                .OrderByDescending(o => o.DateCreated)
                .Select(s => s.DemoData)
                .Take(10)
                .ToListAsync())
                .Select(s => JsonConvert.DeserializeObject<DemoParseResponse>(s))
                .ToArray();
        }
    }
}