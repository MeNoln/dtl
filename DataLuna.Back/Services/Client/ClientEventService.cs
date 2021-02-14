using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using DataLuna.Back.Persistence;
using DataLuna.Back.Common.Exceptions;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Common.Client;

namespace DataLuna.Back.Services
{
    public class ClientEventService : IClientEventService
    {
        private readonly DataLunaDbContext _context;
        public ClientEventService(DataLunaDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleEventResponse> GetEvent(int id)
        {
            var ev = await _context.Events.AsNoTracking()
                .Include(c => c.TeamA).ThenInclude(t => t.Players)
                .Include(c => c.TeamB).ThenInclude(t => t.Players)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (ev == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var teamAComparisons = await GetComparisons(ev.TeamAId);
            var teamBComparisons = await GetComparisons(ev.TeamBId);

            var eventResponse = new GetSingleEventResponse
            {
                StartDate = ev.EventDate,
                Name = ev.Name,
                EventType = ev.EventType,
                TwitchLink = ev.TwitchLink,
                Status = ev.Status,
                TeamA = new ClientEventTeamDto
                {
                    Id = ev.TeamA.Id,
                    Rank = ev.TeamA.Rank,
                    Players = ev.TeamA.Players.Select(s => s.NickName).ToArray(),
                    Name = ev.TeamA.Name,
                    Logo = ev.TeamA.ImagePath,
                },
                TeamB = new ClientEventTeamDto
                {
                    Id = ev.TeamB.Id,
                    Rank = ev.TeamB.Rank,
                    Players = ev.TeamB.Players.Select(s => s.NickName).ToArray(),
                    Name = ev.TeamB.Name,
                    Logo = ev.TeamB.ImagePath,
                },
            };

            eventResponse.TeamsCompare = BuildStats(teamAComparisons, teamBComparisons);
            return eventResponse;
        }

        private async Task<TeamComparison[]> GetComparisons(long teamId)
        {
            var demos = (await _context.Demos.AsNoTracking()
                .Where(w => w.TeamAId == teamId || w.TeamBId == teamId)
                .OrderByDescending(o => o.DateCreated)
                .Select(s => s.DemoData)
                .Take(10)
                .ToListAsync())
                .Select(s => JsonConvert.DeserializeObject<DemoParseResponse>(s))
                .ToArray();

            var comparisons = demos.Select(s => s.TeamA).ToList();
            comparisons.AddRange(demos.Select(s => s.TeamB));

            return comparisons.Where(w => w.TeamId == teamId).Select(s => s.TeamComparison).ToArray();
        }

        private IEnumerable<CompareElem> BuildStats(TeamComparison[] teamADemos, TeamComparison[] teamBDemos)
        {
            var stats = new List<CompareElem>();

            var teamAKills = teamADemos.Sum(s => s.TeamKills);
            var teamADeaths = teamADemos.Sum(s => s.TeamDeaths);
            var teamBKills = teamBDemos.Sum(s => s.TeamKills);
            var teamBDeaths = teamBDemos.Sum(s => s.TeamDeaths);
            stats.Add(CreateElem("Average team K/D", $"{teamAKills}/{teamADeaths}", $"{teamBKills}/{teamBDeaths}"));

            var teamAHsPercent = teamAKills != 0 ? teamADemos.Sum(s => s.TeamHeadshotCount) / teamAKills : 0;
            var teamBHsPercent = teamBKills != 0 ? teamBDemos.Sum(s => s.TeamHeadshotCount) / teamBKills : 0;
            stats.Add(CreateElem("Headshot %", teamAHsPercent.ToString(), teamBHsPercent.ToString()));

            stats.Add(CreateElem("Damage round", teamADemos.Sum(s => s.TeamDamage).ToString(), teamBDemos.Sum(s => s.TeamDamage).ToString()));

            stats.Add(CreateElem("Clutch 1vs1", teamADemos.Sum(s => s.ClutchVsOneCount).ToString(), teamBDemos.Sum(s => s.ClutchVsOneCount).ToString()));

            stats.Add(CreateElem("Clutch 1vs2", teamADemos.Sum(s => s.ClutchVsTwoCount).ToString(), teamBDemos.Sum(s => s.ClutchVsTwoCount).ToString()));

            stats.Add(CreateElem("Clutch 1vs3", teamADemos.Sum(s => s.ClutchVsThreeCount).ToString(), teamBDemos.Sum(s => s.ClutchVsThreeCount).ToString()));

            stats.Add(CreateElem("Clutch 1vs4", teamADemos.Sum(s => s.ClutchVsFourCount).ToString(), teamBDemos.Sum(s => s.ClutchVsFourCount).ToString()));

            stats.Add(CreateElem("Pistol rounds won", teamADemos.Sum(s => s.PistolRoundWinsCount).ToString(), teamBDemos.Sum(s => s.PistolRoundWinsCount).ToString()));

            stats.Add(CreateElem("Eco rounds won", teamADemos.Sum(s => s.EcoRoundWinsCount).ToString(), teamBDemos.Sum(s => s.EcoRoundWinsCount).ToString()));

            return stats;
        }

        private CompareElem CreateElem(string statName, string teamAVal, string teamBVal)
            => new CompareElem
            {
                StatName = statName,
                TeamA = new TeamStat { Value = teamAVal },
                TeamB = new TeamStat { Value = teamBVal },
            };
    }
}