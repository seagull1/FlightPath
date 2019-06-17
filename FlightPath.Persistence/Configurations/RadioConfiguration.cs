using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightPath.Domain.Entities;

namespace FlightPath.Persistence.Configurations
{
    public class RadioConfiguration : IEntityTypeConfiguration<Radio>
    {
        public void Configure(EntityTypeBuilder<Radio> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.AirportName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Designator)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.RadioFrequency)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.RadioName)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.DesignatorNavigation)
                .WithMany(p => p.Radio)
                .HasForeignKey(d => d.Designator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Radio__Designato__30F848ED");
        }
    }
}
