using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Domain;

namespace DataLuna.Back.Services
{
    public interface IAdminDemoService
    {
        Task SaveDemoData(NewDemoCommand demo);
        Task<GameDemo[]> GetDemos();
    }
}