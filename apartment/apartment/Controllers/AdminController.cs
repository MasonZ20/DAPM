using apartment.Models.Entities;
using apartment.Models.Functions;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace apartment.Controllers
{
    public class AdminController : Controller
    {
        private ModelQLCH db = new ModelQLCH();
       

        // GET

        [Authorize]
        public ActionResult DSTaiKhoan(int? page)
        {
            
            
                // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
                // page có thể có giá trị là null ( rỗng) và kiểu int.

                // 2. Nếu page = null thì đặt lại là 1.
                if (page == null) page = 1;

                // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
                // theo Masp mới có thể phân trang.
                var sp = db.TaiKhoans.OrderBy(x => x.TenTaiKhoan);

                // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
                int pageSize = 8;

                // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
                // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
                int pageNumber = (page ?? 1);

                // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
                return View(sp.ToPagedList(pageNumber, pageSize));

            
        }

        [Authorize]
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("TrangChu", "TrangChu");
        }

        [Authorize]
        public ActionResult DSLoaiPhong()
        {
            var list = db.LoaiPhongs.ToList();
            return View(list);
        }

        [Authorize]
        public ActionResult DSPhong(int? page)
        {
           

            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.Phongs.OrderBy(x => x.MaPhong);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));


        }

        [Authorize]
        public ActionResult DSDichVu(int? page)
        {
            

            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.DichVus.OrderBy(x => x.MaDichVu);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }

        // Thêm
        [Authorize]
        public ActionResult ThemTaiKhoan()
        {
            return View(new TaiKhoan());
        }

        [Authorize]
        public ActionResult ThemLoaiPhong()
        {
            return View(new LoaiPhong());
        }

        [Authorize]
        public ActionResult ThemPhong()
        {
            ViewBag.listLoaiPhong = db.LoaiPhongs.ToList();
            return View(new Phong());
        }

        [Authorize]
        public ActionResult ThemDichVu()
        {
            return View(new DichVu());
        }

        // Sửa
        [Authorize]
        public ActionResult SuaTaiKhoan()
        {
            string TenTaiKhoan = RouteData.Values["id"].ToString();
            var taiKhoan = db.TaiKhoans.Find(TenTaiKhoan);
            return View(taiKhoan);
        }

        [Authorize]
        public ActionResult SuaLoaiPhong()
        {
            string MaLoai = RouteData.Values["id"].ToString();
            var loaiPhong = db.LoaiPhongs.Find(MaLoai);
            return View(loaiPhong);
        }

        [Authorize]
        public ActionResult SuaPhong()
        {
            string MaPhong = RouteData.Values["id"].ToString();
            ViewBag.listLoaiPhong = db.LoaiPhongs.ToList();
            var phong = db.Phongs.Find(MaPhong);
            return View(phong);
        }

        [Authorize]
        public ActionResult SuaDichVu()
        {
            string MaDichVu = RouteData.Values["id"].ToString();
            var dichVu = db.DichVus.Find(MaDichVu);
            return View(dichVu);
        }

        // Xóa
        [Authorize]
        public ActionResult XoaTaiKhoan()
        {
            string TenTaiKhoan = RouteData.Values["id"].ToString();
            // Trước khi xóa Tài Khoản phải xóa thông tin đặt Căn Hộ
            var listDatPhong = db.DatPhongs.Where(m => m.TenTaiKhoan == TenTaiKhoan).ToList();
            var HamDP = new HamDatPhong();
            foreach (DatPhong dp in listDatPhong)
                HamDP.Delete(dp.MaDatPhong);
            // Sau đó mới xóa Tài Khoản
            var HamTK = new HamTaiKhoan();
            HamTK.Delete(TenTaiKhoan);
            return RedirectToAction("DSTaiKhoan", "Admin");
        }

        [Authorize]
        public ActionResult XoaLoaiPhong()
        {
            string MaLoai = RouteData.Values["id"].ToString();
            // Trước khi xóa Loại Căn Hộ phải xóa các Căn Hộ liên quan
            // Nhưng muốn xóa Căn Hộ phải xóa Đặt Căn Hộ trước
            var listPhong = db.Phongs.Where(m => m.MaLoai == MaLoai).ToList();
            var HamP = new HamPhong();
            var HamDP = new HamDatPhong();
            foreach (Phong p in listPhong)
            {
                var listDatPhong = db.DatPhongs.Where(m => m.MaPhong == p.MaPhong).ToList();
                foreach (DatPhong dp in listDatPhong)
                    HamDP.Delete(dp.MaDatPhong);
                HamP.Delete(p.MaPhong);
            }
            // Sau đó mới xóa Loại Căn Hộ
            var HamLP = new HamLoaiPhong();
            HamLP.Delete(MaLoai);
            return RedirectToAction("DSLoaiPhong", "Admin");
        }

        [Authorize]
        public ActionResult XoaPhong()
        {
            string MaPhong = RouteData.Values["id"].ToString();
            // Trước khi xóa Căn Hộ phải xóa thông tin đặt Căn Hộ
            var listDatPhong = db.DatPhongs.Where(m => m.MaPhong == MaPhong).ToList();
            var HamDP = new HamDatPhong();
            foreach (DatPhong dp in listDatPhong)
                HamDP.Delete(dp.MaDatPhong);
            // Sau đó mới xóa Căn Hộ
            var HamP = new HamPhong();
            HamP.Delete(MaPhong);
            return RedirectToAction("DSPhong", "Admin");
        }

        [Authorize]
        public ActionResult XoaDichVu()
        {
            string MaDichVu = RouteData.Values["id"].ToString();
            var HamDV = new HamDichVu();
            HamDV.Delete(MaDichVu);
            return RedirectToAction("DSDichVu", "Admin");
        }

        // POST

        [Authorize]
        [HttpPost]
        public ActionResult ThemTaiKhoan(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var taiKhoan = db.TaiKhoans.Find(tk.TenTaiKhoan);
                if (taiKhoan != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài Khoản đã tồn tại");
                    return View(tk);
                }
                var hTK = new HamTaiKhoan();
                hTK.Insert(tk);
                return RedirectToAction("DSTaiKhoan", "Admin");
            }
            return View(tk);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ThemLoaiPhong(LoaiPhong lp, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var loaiPhong = db.LoaiPhongs.Find(lp.MaLoai);
                if (loaiPhong != null)
                {
                    ModelState.AddModelError("MaLoai", "Mã Loại đã tồn tại");
                    return View(lp);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    file.SaveAs(path);
                }
                var hLP = new HamLoaiPhong();
                hLP.Insert(lp);
                return RedirectToAction("DSLoaiPhong", "Admin");
            }
            return View(lp);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ThemPhong(Phong p)
        {
            if (ModelState.IsValid)
            {
                var phong = db.Phongs.Find(p.MaPhong);
                if (phong != null)
                {
                    ModelState.AddModelError("MaPhong", "Mã Căn Hộ đã tồn tại");
                    return View(p);
                }
                var hP = new HamPhong();
                hP.Insert(p);
                return RedirectToAction("DSPhong", "Admin");
            }
            ViewBag.listLoaiPhong = db.LoaiPhongs.ToList();
            return View(p);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ThemDichVu(DichVu dv)
        {
            if (ModelState.IsValid)
            {
                var dichVu = db.DichVus.Find(dv.MaDichVu);
                if (dichVu != null)
                {
                    ModelState.AddModelError("MaDichVu", "Mã Dịch Vụ đã tồn tại");
                    return View(dv);
                }
                var hDV = new HamDichVu();
                hDV.Insert(dv);
                return RedirectToAction("DSDichVu", "Admin");
            }
            return View(dv);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SuaTaiKhoan(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var HamTK = new HamTaiKhoan();
                HamTK.Update(tk);
                return RedirectToAction("DSTaiKhoan", "Admin");
            }
            return View(tk);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SuaLoaiPhong(LoaiPhong lp, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    file.SaveAs(path);
                }
                var HamLP = new HamLoaiPhong();
                HamLP.Update(lp);
                return RedirectToAction("DSLoaiPhong", "Admin");
            }
            return View(lp);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SuaPhong(Phong p)
        {
            if (ModelState.IsValid)
            {
                var HamP = new HamPhong();
                HamP.Update(p);
                return RedirectToAction("DSPhong", "Admin");
            }
            ViewBag.listLoaiPhong = db.LoaiPhongs.ToList();
            return View(p);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SuaDichVu(DichVu dv)
        {
            if (ModelState.IsValid)
            {
                var HamDV = new HamDichVu();
                HamDV.Update(dv);
                return RedirectToAction("DSDichVu", "Admin");
            }
            return View(dv);
        }

    }
}