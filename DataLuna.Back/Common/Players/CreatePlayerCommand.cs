namespace DataLuna.Back.Common.Players
{
    public class CreatePlayerCommand
    {
        public long TeamId { get; set; }
        public string NickName { get; set; }
        public string SteamId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}