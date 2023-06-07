using apartment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apartment.Controllers
{
    public class TrangChuController : Controller
    {
        private ModelQLCH db = new ModelQLCH();
        // GET: TrangChu
        // GET

        public ActionResult TrangChu()
        {
            if (Request.IsAuthenticated) return RedirectToAction("DSTaiKhoan", "Admin");
            if (Session["TaiKhoan"] == null)
            {
                if (Request.Cookies["TenTaiKhoan"] != null)
                {
                    HttpCookie TenTaiKhoan = Request.Cookies["TenTaiKhoan"];
                    HttpCookie MatKhau = Request.Cookies["MatKhau"];
                    var listTK = db.TaiKhoans.Where(m => m.TenTaiKhoan == TenTaiKhoan.Value && m.MatKhau == MatKhau.Value).ToList();
                    if (listTK.Count != 0)
                    {
                        TaiKhoan taiKhoan = listTK.First();
                        Session["TaiKhoan"] = taiKhoan;
                    }
                }
            }
            List<LoaiPhong> list = db.LoaiPhongs.ToList();
            return View(list);
        }

        public ActionResult TinTuc()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }


        // POST
    }
}