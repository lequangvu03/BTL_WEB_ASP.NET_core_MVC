using Microsoft.AspNetCore.Mvc;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.Models.Authentication;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLBanDongHoContext db = new QLBanDongHoContext();
        [Route("")]
        [Route("Index")]

        [Authentication]
        public IActionResult Index()
        {
            // doanh thu tháng hiện tại
            var lstHd = db.THoaDonBans.Where(hd => hd.NgayHoaDon.Value.Month == DateTime.Now.Month).ToList();
            decimal totalMonthly = lstHd.Sum(hd => hd.TongTienHd.Value);
            ViewBag.TotalMonthly = totalMonthly;

            var lst = db.THoaDonBans.Where(hd => hd.NgayHoaDon.Value.Month == DateTime.Now.Month -1 ).ToList(); // lây hoa đơn tháng trước
            decimal total = lst.Sum(hd => hd.TongTienHd.Value); // tổng tiền hóa đơn tháng trước
            decimal tang, giam;   
            if( totalMonthly >= total) 
            {
                tang = (totalMonthly - total) * 100 / totalMonthly;
                ViewData["GiaTri"] = tang.ToString();
                ViewData["TrangThai"] = "Increased by ";
            }
            else
            {
                giam = (total - totalMonthly) * 100 / total;
                ViewData["GiaTri"] = giam.ToString();
                ViewData["TrangThai"] = "Decreased by ";
            }
            //hóa đơn theo tháng hiện tại
            int countHd = lstHd.Count();
            int count = lst.Count();
            ViewBag.SoLuongHD = countHd;
            double sl;
            if (countHd >= count)
            {
                 sl = ((countHd - count) * 100 / countHd);
                
                ViewData["ChechLechHD"] = sl.ToString();
                ViewData["TrangThaiHD"] = "Increased by ";
            }
            else
            {
                sl= ((count - countHd) * 100 / count);
                ViewData["ChenhLechHD"] = sl.ToString();
                ViewData["TrangThaiHD"] = "Decreased by ";
            }

            //Khách hàng tháng hiện tại
            // Dữ liệu cho biểu đồ cột: doanh thu theo tháng 
            var monthlySalesData = db.THoaDonBans
                .Where(hd => hd.NgayHoaDon.Value.Year == DateTime.Now.Year)
                .GroupBy(hd => hd.NgayHoaDon.Value.Month)
                .Select(group => new { Month = group.Key, Total = group.Sum(hd => hd.TongTienHd) })
                .OrderBy(item => item.Month)
                .ToList();

            ViewBag.MonthlySalesData = monthlySalesData;

            //dữ liệu cho biểu đồ hình tròn : khách hàng theo tháng
            var CustomersMonthlyData = db.THoaDonBans
           .Where(hd => hd.NgayHoaDon.Value.Year == DateTime.Now.Year)
           .GroupBy(hd => hd.NgayHoaDon.Value.Month)
           .Select(group => new { Month = group.Key, CustomerCount = group.Select(hd => hd.MaKhachHang).Distinct().Count() })
           .ToList();

            ViewBag.CustomersMonthlyData = CustomersMonthlyData;

            return View();
        }




    }
}
