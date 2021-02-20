using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class DemoParseCommand
    {
        public string url { get; set; }
        public ParseParam[] parseParam { get; set; }
    }

    public class ParseParam
    {
        public string nameFile { get; set; }
        public int[] pistoleRounds { get; set; }
        public int[] usedRounds { get; set; }
    }
}
