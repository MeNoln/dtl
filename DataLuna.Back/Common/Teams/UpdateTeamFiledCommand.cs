using System;

namespace DataLuna.Back.Common.Teams
{
    public class UpdateTeamFiledCommand
    {
        public long Id { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
    }
}