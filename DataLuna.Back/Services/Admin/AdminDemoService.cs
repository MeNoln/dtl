using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Persistence;
using DataLuna.Back.Domain;
using Newtonsoft.Json;

namespace DataLuna.Back.Services
{
    public class AdminDemoService : IAdminDemoService
    {
        private readonly DataLunaDbContext _context;
        public AdminDemoService(DataLunaDbContext context)
        {
            _context = context;
        }

        public async Task SaveDemoData(NewDemoCommand demo)
        {
            var newDemo = new GameDemo
            {
                TeamAId = demo.TeamAId,
                TeamBId = demo.TeamBId,
                DateCreated = DateTime.UtcNow,
                DemoData = JsonConvert.SerializeObject(demo.Demo),
            };

            _context.Demos.Add(newDemo);
            await _context.SaveChangesAsync();
        }
    }
}