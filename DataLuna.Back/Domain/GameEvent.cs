using System;

namespace DataLuna.Back.Domain
{
    public class GameEvent
    {
        public long Id { get; set; }
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public DateTime EventDate { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
    }
}