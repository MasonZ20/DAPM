﻿using apartment.Models.Entities;
using apartment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apartment.Models.Functions
{
    public class HamPhong
    {
        private ModelQLCH db;

        public HamPhong()
        {
            db = new ModelQLCH();
        }

        public IQueryable<Phong> Phongs
        {
            get { return db.Phongs; }
        }

        public string Insert(Phong model)
        {
            db.Phongs.Add(model);
            db.SaveChanges();
            return model.MaPhong;
        }

        public string Update(Phong model)
        {
            Phong dbEntry = db.Phongs.Find(model.MaPhong);
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.MaPhong = model.MaPhong;
            dbEntry.TenPhong = model.TenPhong;
            dbEntry.MaLoai = model.MaLoai;
            dbEntry.DienTich = model.DienTich;
            dbEntry.GiaThue = model.GiaThue;
            db.SaveChanges();
            return model.MaPhong;
        }

        public string Delete(string MaPhong)
        {
            Phong dbEntry = db.Phongs.Find(MaPhong);
            if (dbEntry == null)
            {
                return null;
            }
            db.Phongs.Remove(dbEntry);
            db.SaveChanges();
            return MaPhong;
        }

        public List<PhongView> toanBoPhong()
        {
            List<PhongView> listPhongView;
            var query = from s in db.LoaiPhongs
                        join r in db.Phongs on s.MaLoai equals r.MaLoai
                        select new PhongView
                        {
                            MaPhong = r.MaPhong,
                            TenPhong = r.TenPhong,
                            MaLoai = r.MaLoai,
                            DienTich = r.DienTich,
                            GiaThue = r.GiaThue,
                            TenLoai = s.TenLoai,
                            DuongDanAnh = s.DuongDanAnh
                        };
            listPhongView = query.ToList();
            return listPhongView;
        }

        public List<PhongView> timKiem(string loaiTimKiem, string mucTimKiem, int giaTriTimKiem)
        {
            List<PhongView> listPhongView;
            var query = from s in db.Phongs
                        join r in db.LoaiPhongs on s.MaLoai equals r.MaLoai
                        select new PhongView
                        {
                            MaPhong = s.MaPhong,
                            TenPhong = s.TenPhong,
                            DienTich = s.DienTich,
                            GiaThue = s.GiaThue,
                            MaLoai = r.MaLoai,
                            TenLoai = r.TenLoai,
                            DuongDanAnh = r.DuongDanAnh
                        };
            if (loaiTimKiem == "Diện Tích")
            {
                if (mucTimKiem == "<=") listPhongView = query.Where(m => m.DienTich <= giaTriTimKiem).ToList();
                else listPhongView = query.Where(m => m.DienTich >= giaTriTimKiem).ToList();
            }
            else
            {
                if (mucTimKiem == "<=") listPhongView = query.Where(m => m.GiaThue <= giaTriTimKiem).ToList();
                else listPhongView = query.Where(m => m.GiaThue >= giaTriTimKiem).ToList();
            }
            return listPhongView;
        }

        //internal void Insert(Entities.Phong p)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void Update(Entities.Phong p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}