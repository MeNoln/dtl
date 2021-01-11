namespace DataLuna.Back.Domain
{
    public class Player
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string NickName { get; set; }
        public string SteamId { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Enum.PlayerRole Role { get; set; }

        public Team Team { get; set; }
    }
}