using System;
using DataLuna.Back.Domain.Enum;

namespace DataLuna.Back.Domain
{
    public class GameEvent
    {
        public long Id { get; set; }
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public DateTime EventDate { get; set; }
        public EventStatus Status { get; set; }
        public EventType EventType { get; set; }
        public string TwitchLink { get; set; }
        public string Name { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
    }
}