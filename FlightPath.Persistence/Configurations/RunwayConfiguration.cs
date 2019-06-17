using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    public class RunwayConfiguration : IEntityTypeConfiguration<Runway>
    {
        public void Configure(EntityTypeBuilder<Runway> builder)
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

            builder.Property(e => e.RunwayNumber)
                .IsRequired()
                .HasMaxLength(7)
                .IsUnicode(false);

            builder.Property(e => e.RunwaySurface)
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.HasOne(d => d.DesignatorNavigation)
                .WithMany(p => p.Runway)
                .HasForeignKey(d => d.Designator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Runway__Designat__31EC6D26");
        }
    }
}
