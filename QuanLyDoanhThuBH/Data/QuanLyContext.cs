using Microsoft.EntityFrameworkCore;
using QuanLyDoanhThuBH.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace QuanLyDoanhThuBH.Data
{
    public class QuanLyContext : DbContext
    {
        public QuanLyContext(DbContextOptions<QuanLyContext> options) : base(options)
        {
        }
        public DbSet<DoanhThu> DoanhThu { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<DoanhThu>()
            .Property(d => d.TongDoanhThu)
            .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<SanPham>()
            .Property(s => s.DonGia)
            .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<HoaDon>()
            .Property(h => h.DonGia)
            .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<HoaDon>()
            .Property(h => h.TongTien)
            .HasColumnType("decimal(18,2)");


            // Quan hệ: KhachHang - HoaDon
            modelBuilder.Entity<KhachHang>()
            .HasMany(k => k.HoaDon)
            .WithOne(h => h.KhachHang)
            .HasForeignKey(h => h.MaKH)
            .OnDelete(DeleteBehavior.Restrict);


            // Quan hệ: SanPham - HoaDon
            modelBuilder.Entity<SanPham>()
            .HasMany(s => s.HoaDon)
            .WithOne(h => h.SanPham)
            .HasForeignKey(h => h.MaSP)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}