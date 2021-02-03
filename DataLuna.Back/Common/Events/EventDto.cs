using System;
using DataLuna.Back.Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataLuna.Back.Common.Events
{
    public class EventDto
    {
        public long Id { get; set; }
        public DateTime EventDate { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public EventStatus Status { get; set; }
        public string TeamAName { get; set; }
        public string TeamBName { get; set; }
    }
}