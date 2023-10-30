
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;
using System.ComponentModel;
using X.PagedList;


namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/sanphamadmin")]
    public class SanPhamAdminController : Controller
    {
        public SanPhamAdminController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private readonly IWebHostEnvironment _hostingEnvironment;
        QLBanDongHoContext db = new QLBanDongHoContext();

        [Route("DanhMucSanPhamFs")]
        public IActionResult DanhMucSanPhamFs(int? page, string? search)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (string.IsNullOrEmpty(search))
            {
                var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp).ToPagedList(pageNumber, pageSize);

                return PartialView("TableSP", lstSanPham);

            }
            else
            {
                var results = db.TDanhMucSps.Where(x => x.TenSp.ToLower().Contains(search.Trim().ToLower()))
                    .ToPagedList(pageNumber, pageSize);
                return PartialView("TableSP", results);
            }
           
           
           
        }
        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 7;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return PartialView("DanhMucSanPham", lst);
        }
        [Route("ChiTietSanPham")]
        [HttpGet]
        public IActionResult ChiTietSanPham(int maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDacTinh = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }




        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDacTinh = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");        
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(SanPhamViewModel sanPham)
        {
            TempData["Message"] = "";
               
            if (ModelState.IsValid)
            {   
                string FileName = "";
                if (sanPham.img != null)
                {
                    string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/ProductImg/");
                    FileName = "SP_" + sanPham.MaSp + System.IO.Path.GetExtension(sanPham.img.FileName);
                    string filepath = Path.Combine(_path, FileName);
                    sanPham.img.CopyTo(new FileStream(filepath, FileMode.Create));

                }
                TDanhMucSp p = new TDanhMucSp(sanPham.MaSp, sanPham.TenSp, sanPham.MaChatLieu, sanPham.CanNang,
                  sanPham.MaHangSx, sanPham.MaNuocSx, sanPham.MaDacTinh, sanPham.ThoiGianBaoHanh, sanPham.GioiThieuSp,
                    sanPham.ChietKhau, sanPham.MaLoai, sanPham.MaDt, FileName, sanPham.GiaNhoNhat, sanPham.GiaLonNhat
                );
                db.TDanhMucSps.Add(p);
                db.SaveChanges();
                if (sanPham.Listimg != null)
                {
                    int count = 0;
                    foreach (var i in sanPham.Listimg)
                    {
                        count++;
                        string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/ProductImg/DetailProductImg/");
                        FileName = "SP_" + sanPham.MaSp + "_" + count + System.IO.Path.GetExtension(sanPham.img.FileName);
                        string filepath = Path.Combine(_path, FileName);
                        sanPham.img.CopyTo(new FileStream(filepath, FileMode.Create));
                        TAnhSp t = new TAnhSp
                        {
                            MaSp = sanPham.MaSp,
                            TenFileAnh = FileName
                        };
                        db.TAnhSps.Add(t);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("DanhMucSanPham");
            }
            TempData["Message"] = "Thêm không thành công";
            return View(sanPham);
          //  return RedirectToAction("DanhMucSanPham");
        }


        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDacTinh = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            SanPhamViewModel x=new SanPhamViewModel(sanPham);
            return View(x);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPhamViewModel sanPham)
        {
            if (ModelState.IsValid)
            {
                string FileName = "";
                if (sanPham.img != null)
                {
                    string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/ProductImg/");
                    FileName = "SP_" + sanPham.MaSp + System.IO.Path.GetExtension(sanPham.img.FileName);
                    string filepath = Path.Combine(_path, FileName);
                    sanPham.img.CopyTo(new FileStream(filepath, FileMode.Create));

                }
                TDanhMucSp p = new TDanhMucSp(sanPham.MaSp, sanPham.TenSp, sanPham.MaChatLieu, sanPham.CanNang,
                  sanPham.MaHangSx, sanPham.MaNuocSx, sanPham.MaDacTinh, sanPham.ThoiGianBaoHanh, sanPham.GioiThieuSp,
                    sanPham.ChietKhau, sanPham.MaLoai, sanPham.MaDt, FileName, sanPham.GiaNhoNhat, sanPham.GiaLonNhat
                );
                //db.Update(sanPham);
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                if (sanPham.Listimg != null)
                {
                    int count = 0;
                    foreach (var i in sanPham.Listimg)
                    {
                        count++;
                        string _path = Path.Combine(_hostingEnvironment.WebRootPath, "images/ProductImg/");
                        FileName = "SP_" + sanPham.MaSp + "_" + count + System.IO.Path.GetExtension(sanPham.img.FileName);
                        string filepath = Path.Combine(_path, FileName);
                        sanPham.img.CopyTo(new FileStream(filepath, FileMode.Create));
                        TAnhSp t = new TAnhSp
                        {
                            MaSp = sanPham.MaSp,
                            TenFileAnh = FileName
                        };
                        db.TAnhSps.Add(t);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("DanhMucSanPham", "SanPhamAdmin");
            }
            return View(sanPham);

        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int maSanPham)
        {
            //thông báo cho người dùng biết có xóa được hay không 
            TempData["Message"] = "";// để khi chuyển hướng vấn giữ được giá trị
            //kiểm tra chi tiết sản phẩm có tồn tại mã sản phẩm này ko        
            // ngược lại thì xóa ảnh và danh mục sản phẩm vì , ảnh là bên nhiều
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham).ToList();
            //nếu tồn tại ảnh sản phảm thì xóa 
            if (anhSanPham.Any())
            {
                //xóa một lúc nhiều bản ghi
                db.RemoveRange(anhSanPham);
            }
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Xóa sản phẩm thành công";
            return RedirectToAction("DanhMucSanPham", "SanPhamAdmin");
        }


    }
}
