using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace QuanLyKho.Models
{
    public partial class QuanLyKhoContext : DbContext
    {
        public QuanLyKhoContext()
        {
        }

        public QuanLyKhoContext(DbContextOptions<QuanLyKhoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyContr"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet)
                    .HasName("PK__ChiTietD__CDF0A11411037395");

                entity.ToTable("ChiTietDonDatHang");

                entity.Property(e => e.GiaTien).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.ChiTietDonDatHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .HasConstraintName("FK_DDH_CT");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietDonDatHangs)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_SP_CT");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc)
                    .HasName("PK__DanhMuc__B3750887B21A7A2A");

                entity.ToTable("DanhMuc");

                entity.Property(e => e.TenDanhMuc).HasMaxLength(100);
            });

            modelBuilder.Entity<DonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__DonDatHa__129584ADDA90CDB3");

                entity.ToTable("DonDatHang");

                entity.Property(e => e.NgayDat).HasColumnType("date");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap)
                    .HasName("PK__NhaCungC__53DA9205F6B4CEBB");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.DienThoai).HasMaxLength(20);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(100);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__FAC7442D6202D680");

                entity.ToTable("SanPham");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("FK_DM_SP");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("FK_NCC_SP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
