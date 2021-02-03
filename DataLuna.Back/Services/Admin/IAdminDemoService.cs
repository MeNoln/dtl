using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.DemoParserProxy;

namespace DataLuna.Back.Services
{
    public interface IAdminDemoService
    {
        Task SaveDemoData(NewDemoCommand demo);
    }
}