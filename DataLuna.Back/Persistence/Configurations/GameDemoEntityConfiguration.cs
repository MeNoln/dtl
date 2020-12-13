using DataLuna.Back.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLuna.Back.Persistence.Configurations
{
    public class GameDemoEntityConfiguration : IEntityTypeConfiguration<GameDemo>
    {
        public void Configure(EntityTypeBuilder<GameDemo> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}