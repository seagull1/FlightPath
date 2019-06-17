using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    public class AirportFuelConfiguration : IEntityTypeConfiguration<AirportFuel>
    {
        public void Configure(EntityTypeBuilder<AirportFuel> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.AirportName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CreateDate)
                .HasColumnType("smalldatetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Designator)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.FuelPrice).HasColumnType("decimal(6, 2)");

            builder.Property(e => e.FuelPriceComments)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.FuelType)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.FuelVenderName)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.FuelVenderPhone)
                .HasMaxLength(22)
                .IsUnicode(false);

            builder.Property(e => e.FuelVenderRadio).HasColumnType("nchar(15)");

            builder.HasOne(d => d.DesignatorNavigation)
                .WithMany(p => p.AirportFuel)
                .HasForeignKey(d => d.Designator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AirportFu__Desig__2E1BDC42");
        }
    }
}
