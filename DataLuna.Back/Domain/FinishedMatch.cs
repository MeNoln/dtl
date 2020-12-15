using System;
using System.Collections.Generic;

namespace DataLuna.Back.Domain
{
    public class FinishedMatch
    {
        public FinishedMatch()
        {
            GameDemos = new HashSet<GameDemo>();
        }

        public long Id { get; set; }
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public DateTime MatchDate { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public ICollection<GameDemo> GameDemos { get; set; }
    }
}