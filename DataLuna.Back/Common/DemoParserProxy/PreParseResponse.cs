using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class PreParseResponse
    {
        public string nameFile { get; set; }
        public RoundData[] rounds { get; set; }
    }

    public class RoundData
    {
        public string round_start { get; set; }
        public string begin_new_match { get; set; }
        public string round_freeze_end { get; set; }
        public string equippedWeapons { get; set; }
        public string round_end { get; set; }
        public string usedWeaponsType { get; set; }
        public string round_officially_ended { get; set; }
        public string scoreRound { get; set; }
        public string statsRound { get; set; }
        public bool mayBePistolRound { get; set; }
    }
}
