using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace flightpath.api.Models
{
    public partial class AeroContext : DbContext
    {
        public AeroContext(DbContextOptions<AeroContext> options)
            : base(options)
        { }

        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<AirportFee> AirportFee { get; set; }
        public virtual DbSet<AirportFuel> AirportFuel { get; set; }
        public virtual DbSet<Radio> Radio { get; set; }
        public virtual DbSet<Runway> Runway { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.Designator);

                entity.Property(e => e.Designator)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Canada')");

                entity.Property(e => e.Icao).HasColumnName("ICAO");

                entity.Property(e => e.Province)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirportFee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designator)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FeeComments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeeFuelTax).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FeeLanding).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FeeParking).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FeeTerminal).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.DesignatorNavigation)
                    .WithMany(p => p.AirportFee)
                    .HasForeignKey(d => d.Designator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AirportFe__Desig__2D27B809");
            });

            modelBuilder.Entity<AirportFuel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designator)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FuelPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FuelPriceComments)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FuelType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FuelVenderName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FuelVenderPhone)
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.FuelVenderRadio).HasColumnType("nchar(15)");

                entity.HasOne(d => d.DesignatorNavigation)
                    .WithMany(p => p.AirportFuel)
                    .HasForeignKey(d => d.Designator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AirportFu__Desig__2E1BDC42");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RadioFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RadioName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DesignatorNavigation)
                    .WithMany(p => p.Radio)
                    .HasForeignKey(d => d.Designator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Radio__Designato__30F848ED");
            });

            modelBuilder.Entity<Runway>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designator)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RunwayNumber)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.RunwaySurface)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.DesignatorNavigation)
                    .WithMany(p => p.Runway)
                    .HasForeignKey(d => d.Designator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Runway__Designat__31EC6D26");
            });
        }
    }
}
