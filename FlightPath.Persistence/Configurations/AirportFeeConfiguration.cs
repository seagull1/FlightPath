using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    public class AirportFeeConfiguration : IEntityTypeConfiguration<AirportFee>
    {
        public void Configure(EntityTypeBuilder<AirportFee> builder)
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

            builder.Property(e => e.FeeComments)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FeeFuelTax).HasColumnType("decimal(5, 2)");

            builder.Property(e => e.FeeLanding).HasColumnType("decimal(5, 2)");

            builder.Property(e => e.FeeParking).HasColumnType("decimal(5, 2)");

            builder.Property(e => e.FeeTerminal).HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.DesignatorNavigation)
                .WithMany(p => p.AirportFee)
                .HasForeignKey(d => d.Designator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AirportFe__Desig__2D27B809");
        }
    }
}
