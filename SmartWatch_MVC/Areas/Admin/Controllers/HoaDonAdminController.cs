using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;
using System.Drawing.Printing;
using X.PagedList;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/hoadonadmin")]
    public class HoaDonAdminController : Controller
    {
        QLBanDongHoContext db = new QLBanDongHoContext();
       
        // hoa đơn
        [Route("DanhMucHoaDon")]
        public IActionResult DanhMucHoaDon(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
           var  hdb = db.THoaDonBans.AsNoTracking().OrderBy(x => x.MaHoaDon).ToPagedList(pageNumber, pageSize);
            return View(hdb);
        }
        [Route("ChiTietHoaDon")]
        [HttpGet]
        public IActionResult ChiTietHoaDon(int maHoaDon)
        {
            THoaDonBan x = db.THoaDonBans.Find(maHoaDon);
            HoaDonViewModel a = new HoaDonViewModel
            {
             hoaDonBan= x,
             TTKhachHang =db.TKhachHangs.Find(x.MaKhachHang),
             ListCTHD=(   from cthd in db.TChiTietHdbs
            join danhMuc in db.TDanhMucSps on cthd.MaSp equals danhMuc.MaSp
            where cthd.MaHoaDon == maHoaDon
            select new ChiTietSanPhamViewModel
            {
                chiTietHdb = cthd,
                danhMucSp = danhMuc
             }
            ).ToList(),

            };

            return View(a);
        }
      
     

    }
}
