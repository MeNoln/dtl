using System;
using DataLuna.Back.Domain.Enum;

namespace DataLuna.Back.Common.Events
{
    public class CreateEventCommand
    {
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public DateTime EventDate { get; set; }
        public EventStatus Status { get; set; }
        public EventType Type { get; set; }
        public string Name { get; set; }
    }
}