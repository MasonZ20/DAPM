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
    public class TaiSansController : Controller
    {
        private ModelQLCH db = new ModelQLCH();
        [Authorize]
        // GET: TaiSans
        public ActionResult Index()
        {
            var taiSans = db.TaiSans.Include(t => t.Phong);
            return View(taiSans.ToList());
        }
        [Authorize]
        // GET: TaiSans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiSan taiSan = db.TaiSans.Find(id);
            if (taiSan == null)
            {
                return HttpNotFound();
            }
            return View(taiSan);
        }
        [Authorize]
        // GET: TaiSans/Create
        public ActionResult Create()
        {
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }

        // POST: TaiSans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTaiSan,TenTaiSan,MaPhong,MoTa,TienDenBu")] TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                db.TaiSans.Add(taiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", taiSan.MaPhong);
            return View(taiSan);
        }

        // GET: TaiSans/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiSan taiSan = db.TaiSans.Find(id);
            if (taiSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", taiSan.MaPhong);
            return View(taiSan);
        }

        // POST: TaiSans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTaiSan,TenTaiSan,MaPhong,MoTa,TienDenBu")] TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", taiSan.MaPhong);
            return View(taiSan);
        }

        // GET: TaiSans/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiSan taiSan = db.TaiSans.Find(id);
            if (taiSan == null)
            {
                return HttpNotFound();
            }
            return View(taiSan);
        }

        // POST: TaiSans/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiSan taiSan = db.TaiSans.Find(id);
            db.TaiSans.Remove(taiSan);
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
