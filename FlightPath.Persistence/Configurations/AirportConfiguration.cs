using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(e => e.Designator);

            builder.Property(e => e.Designator)
                .HasMaxLength(5)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.AirportName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Category)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('Canada')");

            builder.Property(e => e.Icao).HasColumnName("ICAO");

            builder.Property(e => e.Province)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
