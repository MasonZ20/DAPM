using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apartment.Models.Entities
{
    public partial class ModelQLCH : DbContext
    {
        public ModelQLCH()
            : base("name=ModelQLCH")
        {
        }

        public virtual DbSet<ChitietHoaDon> ChitietHoaDons { get; set; }
        public virtual DbSet<DatPhong> DatPhongs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NguoiThue> NguoiThues { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiSan> TaiSans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitietHoaDon>()
                .Property(e => e.MaCTHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietHoaDon>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietHoaDon>()
                .Property(e => e.MaNguoiThue)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietHoaDon>()
                .Property(e => e.MaTaiSan)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNguoiThue)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaCTHD)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.DuongDanAnh)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiThue>()
                .Property(e => e.MaNguoiThue)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiThue>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiThue>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiThue>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.TenPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiSan>()
                .Property(e => e.MaTaiSan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiSan>()
                .Property(e => e.TenTaiSan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiSan>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);
        }
    }
}
