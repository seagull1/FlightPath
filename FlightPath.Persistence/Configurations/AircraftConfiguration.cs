using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

            builder.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
        }
    }
}
