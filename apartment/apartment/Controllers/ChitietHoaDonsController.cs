using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using apartment.Models.Entities;

namespace apartment.Controllers
{
    public class ChitietHoaDonsController : Controller
    {
        private ModelQLCH db = new ModelQLCH();

        // GET: ChitietHoaDons
        public ActionResult Index()
        {
            var chitietHoaDons = db.ChitietHoaDons.Include(c => c.DichVu).Include(c => c.NguoiThue).Include(c => c.TaiSan);
            return View(chitietHoaDons.ToList());
        }

        // GET: ChitietHoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitietHoaDon chitietHoaDon = db.ChitietHoaDons.Find(id);
            if (chitietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chitietHoaDon);
        }

        // GET: ChitietHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaDichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu");
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen");
            ViewBag.MaTaiSan = new SelectList(db.TaiSans, "MaTaiSan", "TenTaiSan");
            return View();
        }

        // POST: ChitietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaDichVu,MaNguoiThue,MaTaiSan,GiaThue,TienNo,TienTamUng,TongChiPhi,NgayThue,SoNgayO,SoTienDaTra")] ChitietHoaDon chitietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChitietHoaDons.Add(chitietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu", chitietHoaDon.MaDichVu);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", chitietHoaDon.MaNguoiThue);
            ViewBag.MaTaiSan = new SelectList(db.TaiSans, "MaTaiSan", "TenTaiSan", chitietHoaDon.MaTaiSan);
            return View(chitietHoaDon);
        }

        // GET: ChitietHoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitietHoaDon chitietHoaDon = db.ChitietHoaDons.Find(id);
            if (chitietHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu", chitietHoaDon.MaDichVu);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", chitietHoaDon.MaNguoiThue);
            ViewBag.MaTaiSan = new SelectList(db.TaiSans, "MaTaiSan", "TenTaiSan", chitietHoaDon.MaTaiSan);
            return View(chitietHoaDon);
        }

        // POST: ChitietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaDichVu,MaNguoiThue,MaTaiSan,GiaThue,TienNo,TienTamUng,TongChiPhi,NgayThue,SoNgayO,SoTienDaTra")] ChitietHoaDon chitietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu", chitietHoaDon.MaDichVu);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", chitietHoaDon.MaNguoiThue);
            ViewBag.MaTaiSan = new SelectList(db.TaiSans, "MaTaiSan", "TenTaiSan", chitietHoaDon.MaTaiSan);
            return View(chitietHoaDon);
        }

        // GET: ChitietHoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitietHoaDon chitietHoaDon = db.ChitietHoaDons.Find(id);
            if (chitietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chitietHoaDon);
        }

        // POST: ChitietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChitietHoaDon chitietHoaDon = db.ChitietHoaDons.Find(id);
            db.ChitietHoaDons.Remove(chitietHoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
