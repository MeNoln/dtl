using System.Collections.Generic;

namespace DataLuna.Back.Domain
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Rank { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}