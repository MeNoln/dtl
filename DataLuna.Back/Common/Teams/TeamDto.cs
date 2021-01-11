namespace DataLuna.Back.Common.Teams
{
    public class TeamDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public TeamPlayersDto Players { get; set; }
    }

    public class TeamPlayersDto
    {
        public string Igl { get; set; }
        public string Lurk { get; set; }
        public string Support { get; set; }
        public string Sniper { get; set; }
        public string Entry { get; set; }
    }
}