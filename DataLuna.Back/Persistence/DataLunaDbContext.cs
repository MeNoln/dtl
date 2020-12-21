using DataLuna.Back.Domain;
using DataLuna.Back.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataLuna.Back.Persistence
{
    public class DataLunaDbContext : DbContext
    {
        public DataLunaDbContext()
        {
        }
        public DataLunaDbContext(DbContextOptions<DataLunaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<GameEvent> Events { get; set; }
        public DbSet<GameDemo> Demos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GameEventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GameDemoEntityConfiguration());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseNpgsql("host=localhost;port=5432;database=csgo_db;username=postgres;password=1234");
                optionsBuilder.UseNpgsql("host=rc1b-k29oylptgdr996zf.mdb.yandexcloud.net;port=6432;database=dataluna_db;username=dataluna_user;password=c8051d3491bee7d9c0a6bcdb;sslmode=verify-full;target_session_attrs=read-write");
        }
    }
}