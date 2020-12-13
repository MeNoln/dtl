using DataLuna.Back.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLuna.Back.Persistence.Configurations
{
    public class FinishedMatchEntityConfiguration : IEntityTypeConfiguration<FinishedMatch>
    {
        public void Configure(EntityTypeBuilder<FinishedMatch> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}