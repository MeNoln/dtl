using System;
using System.Collections.Generic;
using DataLuna.Back.Domain.Enum;

namespace DataLuna.Back.Common.Client
{
    public class GetSingleEventResponse
    {
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public EventType EventType { get; set; }
        public string TwitchLink { get; set; }
        public EventStatus Status { get; set; }
        public ClientEventTeamDto TeamA { get; set; }
        public ClientEventTeamDto TeamB { get; set; }
        public IEnumerable<CompareElem> TeamsCompare { get; set; }
    }

    public class ClientEventTeamDto
    {
        public long Id { get; set; }
        public int Rank { get; set; }
        public int WinRate { get; set; }
        public string[] Players { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string CountryLogo { get; set; }
    }

    public class CompareElem
    {
        public string StatName { get; set; }
        public TeamStat TeamA { get; set; }
        public TeamStat TeamB { get; set; }
    }

    public class TeamStat
    {
        public string Value { get; set; }
        public int Percent { get; set; }
    }
}