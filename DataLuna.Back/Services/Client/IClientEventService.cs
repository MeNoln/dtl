using System;
using System.Threading.Tasks;

namespace DataLuna.Back.Services
{
    public interface IClientEventService
    {
        Task GetEvent(int id);
    }
}