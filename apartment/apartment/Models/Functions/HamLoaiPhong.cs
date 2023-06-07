using apartment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apartment.Models.Functions
{
    public class HamLoaiPhong
    {
        private ModelQLCH db;

        public HamLoaiPhong()
        {
            db = new ModelQLCH();
        }

        public IQueryable<LoaiPhong> LoaiPhongs
        {
            get { return db.LoaiPhongs; }
        }

        public string Insert(LoaiPhong model)
        {
            db.LoaiPhongs.Add(model);
            db.SaveChanges();
            return model.MaLoai;
        }

        public string Update(LoaiPhong model)
        {
            LoaiPhong dbEntry = db.LoaiPhongs.Find(model.MaLoai);
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.MaLoai = model.MaLoai;
            dbEntry.TenLoai = model.TenLoai;
            dbEntry.GhiChu = model.GhiChu;
            dbEntry.DuongDanAnh = model.DuongDanAnh;
            db.SaveChanges();
            return model.MaLoai;
        }

        public string Delete(string MaLoai)
        {
            LoaiPhong dbEntry = db.LoaiPhongs.Find(MaLoai);
            if (dbEntry == null)
            {
                return null;
            }
            db.LoaiPhongs.Remove(dbEntry);
            db.SaveChanges();
            return MaLoai;
        }

        //internal void Update(Entities.LoaiPhong lp)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void Insert(Entities.LoaiPhong lp)
        //{
        //    throw new NotImplementedException();
        //}
    }
}