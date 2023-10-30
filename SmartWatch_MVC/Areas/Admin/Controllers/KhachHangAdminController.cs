using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using X.PagedList;

namespace SmartWatch_MVC_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/khachhangadmin")]
    public class KhachHangAdminController : Controller
    {
      QLBanDongHoContext db = new QLBanDongHoContext();
        //danh sách khác hàng


        [Route("DanhMucKhachHangFs")]
        public IActionResult DanhMucKhachHangFs(int? page, string? search)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (string.IsNullOrEmpty(search))
            {
                var lstKhachHang = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang).ToPagedList(pageNumber, pageSize);

                return PartialView("TableKH", lstKhachHang);

            }
            else
            {
                var results = db.TKhachHangs.Where(x => x.TenKhachHang.ToLower().Contains(search.Trim().ToLower()))
                    .ToPagedList(pageNumber, pageSize);
                return PartialView("TableKH", results);
            }



        }
        [Route("DanhMucKhachHang")]
        public IActionResult DanhMucKhachHang(int? page)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstKhachHang = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang);
            PagedList<TKhachHang> lst = new PagedList<TKhachHang>(lstKhachHang, pageNumber, pageSize);
            return View("DanhMucKhachHang",lst);
        }
    }
}
