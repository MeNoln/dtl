namespace DataLuna.Back.Domain
{
    public class GameDemo
    {
        public long Id { get; set; }
        public long FinishedMatchId { get; set; }
        public string DemoData { get; set; }

        public FinishedMatch FinishedMatch { get; set; }
    }
}