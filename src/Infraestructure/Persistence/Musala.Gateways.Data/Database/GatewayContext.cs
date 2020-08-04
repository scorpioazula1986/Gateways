using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Musala.Gateways.Data.Database
{
    public partial class GatewayContext : DbContext
    {
        public GatewayContext()
        {
        }

        public GatewayContext(DbContextOptions<GatewayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatDevice> DatDevice { get; set; }
        public virtual DbSet<DatGateway> DatGateway { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Gateways;Username=postgres;Password=naruto;Port=5432;Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<DatDevice>(entity =>
            {
                entity.ToTable("dat_device");

                entity.HasIndex(e => e.NumUid)
                    .HasName("dat_device_num_uid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DesVendor)
                    .IsRequired()
                    .HasColumnName("des_vendor")
                    .HasMaxLength(100);

                entity.Property(e => e.FkGateway).HasColumnName("fk_gateway");

                entity.Property(e => e.FlgStatus).HasColumnName("flg_status");

                entity.Property(e => e.NumUid).HasColumnName("num_uid");

                entity.HasOne(d => d.FkGatewayNavigation)
                    .WithMany(p => p.DatDevice)
                    .HasForeignKey(d => d.FkGateway)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkdat_device984729");
            });

            modelBuilder.Entity<DatGateway>(entity =>
            {
                entity.ToTable("dat_gateway");

                entity.HasIndex(e => e.DesSerialNumber)
                    .HasName("dat_gateway_des_serial_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DesIpv4)
                    .IsRequired()
                    .HasColumnName("des_ipv4")
                    .HasMaxLength(20);

                entity.Property(e => e.DesName)
                    .IsRequired()
                    .HasColumnName("des_name")
                    .HasMaxLength(50);

                entity.Property(e => e.DesSerialNumber)
                    .IsRequired()
                    .HasColumnName("des_serial_number")
                    .HasMaxLength(50);
            });
        }
    }
}
