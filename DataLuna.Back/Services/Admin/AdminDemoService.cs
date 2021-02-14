using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Persistence;
using DataLuna.Back.Domain;
using DataLuna.Back.Common.Exceptions;
using Newtonsoft.Json;

namespace DataLuna.Back.Services
{
    public class AdminDemoService : IAdminDemoService
    {
        private readonly DataLunaDbContext _context;
        public AdminDemoService(DataLunaDbContext context)
        {
            _context = context;
        }

        public async Task SaveDemoData(NewDemoCommand demo)
        {
            var teamA = await _context.Teams.AsNoTracking().FirstOrDefaultAsync(f => f.Id == demo.TeamAId);
            var teamB = await _context.Teams.AsNoTracking().FirstOrDefaultAsync(f => f.Id == demo.TeamBId);

            if (teamA == null || teamB == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Command not found");

            var teamADemos = demo.Demo.TeamA.TeamName.ToLower() == teamA.Name.ToLower() ? demo.Demo.TeamA :
                demo.Demo.TeamB.TeamName.ToLower() == teamA.Name.ToLower() ? demo.Demo.TeamB :
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, $"Team {teamA.Name} from demo files not found");

            teamADemos.TeamId = teamA.Id;

            var teamBDemos = demo.Demo.TeamA.TeamName.ToLower() == teamB.Name.ToLower() ? demo.Demo.TeamA :
                demo.Demo.TeamB.TeamName.ToLower() == teamB.Name.ToLower() ? demo.Demo.TeamB :
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, $"Team {teamB.Name} from demo files not found");

            teamBDemos.TeamId = teamB.Id;

            demo.Demo.TeamA = teamADemos;
            demo.Demo.TeamB = teamBDemos;

            var newDemo = new GameDemo
            {
                TeamAId = teamA.Id,
                TeamBId = teamB.Id,
                DateCreated = DateTime.UtcNow,
                DemoData = JsonConvert.SerializeObject(demo.Demo),
            };

            _context.Demos.Add(newDemo);
            await _context.SaveChangesAsync();
        }

        public async Task<GameDemo[]> GetDemos()
        {
            return await _context.Demos.AsNoTracking()
                .Include(c => c.TeamA).Include(c => c.TeamB)
                .OrderBy(o => o.DateCreated)
                .ToArrayAsync();
        }
    }
}