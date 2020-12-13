using DataLuna.Back.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLuna.Back.Persistence.Configurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}