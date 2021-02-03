using System;

namespace DataLuna.Back.Common.DemoParserProxy
{
    public class GetStatusResponse
    {
        public string Url { get; set; }
        public bool FileCached { get; set; }
        public string Status { get; set; }
        public string PreparseCached { get; set; }
    }
}