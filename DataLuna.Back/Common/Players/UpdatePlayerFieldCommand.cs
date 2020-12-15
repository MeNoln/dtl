using System;

namespace DataLuna.Back.Common.Players
{
    public class UpdatePlayerFieldCommand
    {
        public long Id { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
    }
}