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
    public class HoaDonsController : Controller
    {
        private ModelQLCH db = new ModelQLCH();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.ChitietHoaDon).Include(h => h.NguoiThue).Include(h => h.Phong);
            return View(hoaDons.ToList());
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaCTHD = new SelectList(db.ChitietHoaDons, "MaCTHD", "MaDichVu");
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen");
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaNguoiThue,MaPhong,MaCTHD,NgayTaoHD,TongChiPhi")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCTHD = new SelectList(db.ChitietHoaDons, "MaCTHD", "MaDichVu", hoaDon.MaCTHD);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", hoaDon.MaNguoiThue);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCTHD = new SelectList(db.ChitietHoaDons, "MaCTHD", "MaDichVu", hoaDon.MaCTHD);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", hoaDon.MaNguoiThue);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaNguoiThue,MaPhong,MaCTHD,NgayTaoHD,TongChiPhi")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCTHD = new SelectList(db.ChitietHoaDons, "MaCTHD", "MaDichVu", hoaDon.MaCTHD);
            ViewBag.MaNguoiThue = new SelectList(db.NguoiThues, "MaNguoiThue", "HoTen", hoaDon.MaNguoiThue);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
