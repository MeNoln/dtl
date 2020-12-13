using DataLuna.Back.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLuna.Back.Persistence.Configurations
{
    public class GameEventEntityConfiguration : IEntityTypeConfiguration<GameEvent>
    {
        public void Configure(EntityTypeBuilder<GameEvent> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}