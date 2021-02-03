using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class DemoParseCommand
    {
        public string Url { get; set; }
        public ParseParam[] ParseParam { get; set; }
    }

    public class ParseParam
    {
        public string NameFile { get; set; }
        public int[] PistoleRounds { get; set; }
        public int[] UsedRounds { get; set; }
    }
}
