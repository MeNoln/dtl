using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class GetStatusResponse
    {
        public string url { get; set; }
        public bool fileCashed { get; set; }
        public string status { get; set; }
        public string preparseCashed { get; set; }
    }
}