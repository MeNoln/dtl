using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class PreParseResponse
    {
        public string NameFile { get; set; }
        public RoundData[] Rounds { get; set; }
    }

    public class RoundData
    {
        public string RoundStart { get; set; }
        public string BeginNewMatch { get; set; }
        public string RoundFreezeEnd { get; set; }
        public string EquippedWeapons { get; set; }
        public string RoundEnd { get; set; }
        public string UsedWeaponsType { get; set; }
        public string RoundOfficiallyEnded { get; set; }
        public string ScoreRound { get; set; }
        public string StatsRound { get; set; }
        public bool MayBePistolRound { get; set; }
    }
}
