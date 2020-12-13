using DataLuna.Back.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLuna.Back.Persistence.Configurations
{
    public class PlayerEntityConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.NickName).IsRequired();
        }
    }
}