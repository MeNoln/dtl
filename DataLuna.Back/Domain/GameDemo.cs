namespace DataLuna.Back.Domain
{
    public class GameDemo
    {
        public long Id { get; set; }
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public string DemoData { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
    }
}