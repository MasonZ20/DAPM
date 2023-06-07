using apartment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apartment.Controllers
{
    public class HomeController : Controller
    {
        private ModelQLCH db = new ModelQLCH();
        public ActionResult Index()
        {
            List<LoaiPhong> list = db.LoaiPhongs.ToList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}