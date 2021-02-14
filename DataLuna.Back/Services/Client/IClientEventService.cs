using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.Client;

namespace DataLuna.Back.Services
{
    public interface IClientEventService
    {
        Task<GetSingleEventResponse> GetEvent(int id);
    }
}