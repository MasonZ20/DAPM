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
    public class NguoiThuesController : Controller
    {
        private ModelQLCH db = new ModelQLCH();

        // GET: NguoiThues
        public ActionResult Index()
        {
            var nguoiThues = db.NguoiThues.Include(n => n.DatPhong);
            return View(nguoiThues.ToList());
        }

        // GET: NguoiThues/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThue nguoiThue = db.NguoiThues.Find(id);
            if (nguoiThue == null)
            {
                return HttpNotFound();
            }
            return View(nguoiThue);
        }

        // GET: NguoiThues/Create
        public ActionResult Create()
        {
            ViewBag.MaDatPhong = new SelectList(db.DatPhongs, "MaDatPhong", "TenTaiKhoan");
            return View();
        }

        // POST: NguoiThues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiThue,MaDatPhong,HoTen,Email,NgayDat,SoDienThoai,CMND")] NguoiThue nguoiThue)
        {
            if (ModelState.IsValid)
            {
                db.NguoiThues.Add(nguoiThue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDatPhong = new SelectList(db.DatPhongs, "MaDatPhong", "TenTaiKhoan", nguoiThue.MaDatPhong);
            return View(nguoiThue);
        }

        // GET: NguoiThues/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThue nguoiThue = db.NguoiThues.Find(id);
            if (nguoiThue == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDatPhong = new SelectList(db.DatPhongs, "MaDatPhong", "TenTaiKhoan", nguoiThue.MaDatPhong);
            return View(nguoiThue);
        }

        // POST: NguoiThues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiThue,MaDatPhong,HoTen,Email,NgayDat,SoDienThoai,CMND")] NguoiThue nguoiThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDatPhong = new SelectList(db.DatPhongs, "MaDatPhong", "TenTaiKhoan", nguoiThue.MaDatPhong);
            return View(nguoiThue);
        }

        // GET: NguoiThues/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThue nguoiThue = db.NguoiThues.Find(id);
            if (nguoiThue == null)
            {
                return HttpNotFound();
            }
            return View(nguoiThue);
        }

        // POST: NguoiThues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguoiThue nguoiThue = db.NguoiThues.Find(id);
            db.NguoiThues.Remove(nguoiThue);
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
