using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class NewDemoCommand
    {
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public DemoParseResponse Demo { get; set; }
    }

}