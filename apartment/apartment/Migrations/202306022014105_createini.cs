namespace apartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChitietHoaDon",
                c => new
                    {
                        MaCTHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaDichVu = c.String(maxLength: 10, unicode: false),
                        MaNguoiThue = c.String(maxLength: 10, unicode: false),
                        MaTaiSan = c.String(maxLength: 10, unicode: false),
                        GiaThue = c.Int(),
                        TienNo = c.Int(),
                        TienTamUng = c.Int(),
                        TongChiPhi = c.Int(),
                        NgayThue = c.DateTime(storeType: "date"),
                        SoNgayO = c.DateTime(storeType: "date"),
                        SoTienDaTra = c.Int(),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.DichVu", t => t.MaDichVu)
                .ForeignKey("dbo.NguoiThue", t => t.MaNguoiThue)
                .ForeignKey("dbo.TaiSan", t => t.MaTaiSan)
                .Index(t => t.MaDichVu)
                .Index(t => t.MaNguoiThue)
                .Index(t => t.MaTaiSan);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDichVu = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenDichVu = c.String(maxLength: 20),
                        GiaDichVu = c.Int(),
                    })
                .PrimaryKey(t => t.MaDichVu);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaNguoiThue = c.String(maxLength: 10, unicode: false),
                        MaPhong = c.String(maxLength: 10, unicode: false),
                        MaCTHD = c.String(maxLength: 10, unicode: false),
                        NgayTaoHD = c.DateTime(storeType: "date"),
                        TongChiPhi = c.Int(),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.ChitietHoaDon", t => t.MaCTHD)
                .ForeignKey("dbo.Phong", t => t.MaPhong)
                .ForeignKey("dbo.NguoiThue", t => t.MaNguoiThue)
                .Index(t => t.MaNguoiThue)
                .Index(t => t.MaPhong)
                .Index(t => t.MaCTHD);
            
            CreateTable(
                "dbo.NguoiThue",
                c => new
                    {
                        MaNguoiThue = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaDatPhong = c.Int(),
                        HoTen = c.String(maxLength: 30),
                        Email = c.String(maxLength: 35, unicode: false),
                        NgayDat = c.DateTime(storeType: "date"),
                        SoDienThoai = c.String(maxLength: 20, unicode: false),
                        CMND = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.MaNguoiThue)
                .ForeignKey("dbo.DatPhong", t => t.MaDatPhong)
                .Index(t => t.MaDatPhong);
            
            CreateTable(
                "dbo.DatPhong",
                c => new
                    {
                        MaDatPhong = c.Int(nullable: false),
                        TenTaiKhoan = c.String(maxLength: 20, unicode: false),
                        MaPhong = c.String(maxLength: 10, unicode: false),
                        NgayDat = c.DateTime(storeType: "date"),
                        NgayDen = c.DateTime(storeType: "date"),
                        NgayTra = c.DateTime(storeType: "date"),
                        DichVu = c.String(maxLength: 100),
                        ThanhTien = c.Int(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaDatPhong)
                .ForeignKey("dbo.Phong", t => t.MaPhong)
                .ForeignKey("dbo.TaiKhoan", t => t.TenTaiKhoan)
                .Index(t => t.TenTaiKhoan)
                .Index(t => t.MaPhong);
            
            CreateTable(
                "dbo.Phong",
                c => new
                    {
                        MaPhong = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenPhong = c.String(maxLength: 10, unicode: false),
                        MaLoai = c.String(maxLength: 10, unicode: false),
                        DienTich = c.Int(),
                        GiaThue = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhong)
                .ForeignKey("dbo.LoaiPhong", t => t.MaLoai)
                .Index(t => t.MaLoai);
            
            CreateTable(
                "dbo.LoaiPhong",
                c => new
                    {
                        MaLoai = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoai = c.String(maxLength: 30),
                        GhiChu = c.String(maxLength: 250),
                        DuongDanAnh = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.TaiSan",
                c => new
                    {
                        MaTaiSan = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenTaiSan = c.String(maxLength: 250, unicode: false),
                        MaPhong = c.String(maxLength: 10, unicode: false),
                        MoTa = c.String(maxLength: 250),
                        TienDenBu = c.Int(),
                    })
                .PrimaryKey(t => t.MaTaiSan)
                .ForeignKey("dbo.Phong", t => t.MaPhong)
                .Index(t => t.MaPhong);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TenTaiKhoan = c.String(nullable: false, maxLength: 20, unicode: false),
                        MatKhau = c.String(maxLength: 20, unicode: false),
                        HoTen = c.String(maxLength: 30),
                        SoDienThoai = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 35, unicode: false),
                        LaAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TenTaiKhoan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDon", "MaNguoiThue", "dbo.NguoiThue");
            DropForeignKey("dbo.DatPhong", "TenTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.TaiSan", "MaPhong", "dbo.Phong");
            DropForeignKey("dbo.ChitietHoaDon", "MaTaiSan", "dbo.TaiSan");
            DropForeignKey("dbo.Phong", "MaLoai", "dbo.LoaiPhong");
            DropForeignKey("dbo.HoaDon", "MaPhong", "dbo.Phong");
            DropForeignKey("dbo.DatPhong", "MaPhong", "dbo.Phong");
            DropForeignKey("dbo.NguoiThue", "MaDatPhong", "dbo.DatPhong");
            DropForeignKey("dbo.ChitietHoaDon", "MaNguoiThue", "dbo.NguoiThue");
            DropForeignKey("dbo.HoaDon", "MaCTHD", "dbo.ChitietHoaDon");
            DropForeignKey("dbo.ChitietHoaDon", "MaDichVu", "dbo.DichVu");
            DropIndex("dbo.TaiSan", new[] { "MaPhong" });
            DropIndex("dbo.Phong", new[] { "MaLoai" });
            DropIndex("dbo.DatPhong", new[] { "MaPhong" });
            DropIndex("dbo.DatPhong", new[] { "TenTaiKhoan" });
            DropIndex("dbo.NguoiThue", new[] { "MaDatPhong" });
            DropIndex("dbo.HoaDon", new[] { "MaCTHD" });
            DropIndex("dbo.HoaDon", new[] { "MaPhong" });
            DropIndex("dbo.HoaDon", new[] { "MaNguoiThue" });
            DropIndex("dbo.ChitietHoaDon", new[] { "MaTaiSan" });
            DropIndex("dbo.ChitietHoaDon", new[] { "MaNguoiThue" });
            DropIndex("dbo.ChitietHoaDon", new[] { "MaDichVu" });
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.TaiSan");
            DropTable("dbo.LoaiPhong");
            DropTable("dbo.Phong");
            DropTable("dbo.DatPhong");
            DropTable("dbo.NguoiThue");
            DropTable("dbo.HoaDon");
            DropTable("dbo.DichVu");
            DropTable("dbo.ChitietHoaDon");
        }
    }
}
