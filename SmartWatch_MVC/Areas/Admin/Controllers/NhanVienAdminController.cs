using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;
using X.PagedList;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/nhanvienadmin")]
    public class NhanVienAdminController : Controller
    {
        QLBanDongHoContext db = new QLBanDongHoContext();
        public NhanVienAdminController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private readonly IWebHostEnvironment _hostingEnvironment;
        //danh muc nhân viên 
        [Route("DanhMucNhanVienFs")]
        public IActionResult DanhMucNhanVienFs(int? page, string? search)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (string.IsNullOrEmpty(search))
            {
                var lstNhanVien = db.TNhanViens.AsNoTracking().OrderBy(x => x.TenNhanVien).ToPagedList(pageNumber, pageSize);

                return PartialView("TableNV", lstNhanVien);

            }
            else
            {
                var results = db.TNhanViens.Where(x => x.TenNhanVien.ToLower().Contains(search.Trim().ToLower()))
                    .ToPagedList(pageNumber, pageSize);
                return PartialView("TableNV", results);
            }



        }


        [Route("DanhMucNhanVien")]
        public IActionResult DanhMucNhanVien(int? page)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstNhanVien = db.TNhanViens.AsNoTracking().OrderBy(x => x.TenNhanVien);
            PagedList<TNhanVien> lst = new PagedList<TNhanVien>(lstNhanVien, pageNumber, pageSize);
            return View("DanhMucNhanVien", lst);
        }

      


        //thêm nhân viên mới 
        [Route("ThemNhanVienMoi")]
        [HttpGet]
        public IActionResult ThemNhanVienMoi()
        {
            NhanVienViewModel x = new NhanVienViewModel();
            return View();
        }

        [Route("ThemNhanVienMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVienMoi(NhanVienViewModel nhanVien)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
              
                string FileName = "";
                if (nhanVien.img != null)
                {
                    string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/EmployeeImg/");
                    FileName = "NV_" + nhanVien.MaNhanVien + System.IO.Path.GetExtension(nhanVien.img.FileName);
                    string filepath = Path.Combine(_path, FileName);
                    nhanVien.img.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                TUser u = new TUser(nhanVien.Username, nhanVien.Password, 1);
                db.TUsers.Add(u);
                db.SaveChanges();
                TNhanVien a = new TNhanVien(nhanVien.MaNhanVien, nhanVien.Username, nhanVien.TenNhanVien, 
                nhanVien.NgaySinh,nhanVien.DiaChi, nhanVien.SoDienThoai, nhanVien.ChucVu, FileName, nhanVien.GhiChu, nhanVien.GioiTinh);
                db.TNhanViens.Add(a);
                db.SaveChanges();
                TempData["Message"] = "Thêm thành công";
                return RedirectToAction("DanhMucNhanVien");

            }
            TempData["Message"] = "Thêm không thành công";
            return View(nhanVien);

        }
        [Route("ChiTietNhanVien")]
        [HttpGet]
        public IActionResult ChiTietNhanVien(string maNhanVien)
        {
            var nhanvien = db.TNhanViens.Find(maNhanVien);
            var user = db.TUsers.Find(nhanvien.Username);
            NhanVienViewModel x = new NhanVienViewModel(nhanvien, user);

            return View(x);
        }

        [Route("SuaNhanVien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string maNhanVien)
        {
            var nhanVien = db.TNhanViens.Find(maNhanVien);
            NhanVienViewModel x=new NhanVienViewModel(nhanVien);
            return View(x);
        }

        [Route("SuaNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVienViewModel nhanVien)
        {
            if (ModelState.IsValid)
            {
                    string FileName = "";
                if (nhanVien.img != null)
                {
                    string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/EmployeeImg/");
                    FileName = "NV_" + nhanVien.MaNhanVien + System.IO.Path.GetExtension(nhanVien.img.FileName);
                    string filepath = Path.Combine(_path, FileName);
                    nhanVien.img.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                TUser u = new TUser(nhanVien.Username, nhanVien.Password, 1);
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                TNhanVien a = new TNhanVien(nhanVien.MaNhanVien, nhanVien.Username, nhanVien.TenNhanVien,
                nhanVien.NgaySinh, nhanVien.DiaChi, nhanVien.SoDienThoai, nhanVien.ChucVu, FileName, nhanVien.GhiChu, nhanVien.GioiTinh);
                //db.Update(nhanVien); dùng cái này cùng được 
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucNhanVien", "NhanVienAdmin");
            }
            return View(nhanVien);

        }
    }
}
