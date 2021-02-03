using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class DemoParseResponse
    {
        public WinnerSide Winner { get; set; }
        public DemoParseTeam TeamA { get; set; }
        public DemoParseTeam TeamB { get; set; }
    }

    public enum WinnerSide
    {
        A = 0,
        B = 1,
    }

    public class DemoParseTeam
    {
        public string TeamName { get; set; }
        public TeamComparison TeamComparison { get; set; }
    }

    public class TeamComparison
    {
        public int TeamKills { get; set; }
        public int TeamDeaths { get; set; }
        public int TeamHeadshotCount { get; set; }
        public int TeamDamage { get; set; } //Damage round idk what it is????
        public int ClutchVsOneCount { get; set; }
        public int ClutchVsTwoCount { get; set; }
        public int ClutchVsThreeCount { get; set; }
        public int ClutchVsFourCount { get; set; }
        public int PistolRoundWinsCount { get; set; }
        public int EcoRoundWinsCount { get; set; }
    }
}