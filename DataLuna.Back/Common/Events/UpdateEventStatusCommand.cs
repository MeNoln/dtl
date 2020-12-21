using System;
using DataLuna.Back.Domain.Enum;

namespace DataLuna.Back.Common.Events
{
    public class UpdateEventStatusCommand
    {
        public long Id { get; set; }
        public EventStatus Status { get; set; }
    }
}