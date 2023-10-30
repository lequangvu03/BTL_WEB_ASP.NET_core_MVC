using Microsoft.AspNetCore.Mvc;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/baocaoadmin")]
    public class BaoCaoAdminController : Controller
    {
        [Route("DoanhThu")]
        public IActionResult DoanhThu()
        {

            return View();
        }

        [HttpGet]
        //get admin/ 
        public JsonResult GetRevenueDataByMonth()
        {
            // Lấy dữ liệu doanh thu từ cơ sở dữ liệu hoặc bất kỳ nguồn dữ liệu nào khác
            var labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            var data = new[] { 100, 150, 120, 200, 180, 250 };

            return Json(new { Labels = labels, Data = data });
        }
    }
}
