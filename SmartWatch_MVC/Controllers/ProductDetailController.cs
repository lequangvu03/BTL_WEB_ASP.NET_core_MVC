using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;
using X.PagedList;

namespace SmartWatch_MVC.Controllers
{
    public class ProductDetailController : Controller
    {
        QLBanDongHoContext db = new QLBanDongHoContext();

        public IActionResult Details(int id, int? page)
        {
            int pageSize = 2;
            int pageNumber = page == null || page < -1 ? 1 : page.Value;

            var product = db.TDanhMucSps.SingleOrDefault(p => p.MaSp == id);
            var relevantProducts = db.TDanhMucSps.AsNoTracking().Where(p => p.MaLoai == product.MaLoai && p.MaSp != id).OrderBy(p => p.TenSp).ToList();
            ViewBag.ProductID = id;

            var category = db.TLoaiSps
                .Join(
                    db.TDanhMucSps,
                    loaiSp => loaiSp.MaLoai,
                    danhMuc => danhMuc.MaLoai,
                    (loaiSp, danhMuc) => new { Loai = loaiSp.Loai, MaLoai = loaiSp.MaLoai })
                .Where(result => result.MaLoai == product.MaLoai)
                .Select(result => result.Loai)
                .FirstOrDefault();

            if (category != null)
            {
                ViewBag.Category = category;
            }

            PagedList<TDanhMucSp> relevantProductsWithPagination = new PagedList<TDanhMucSp>(relevantProducts, pageNumber, pageSize);
            ViewBag.RelevantProducts = relevantProductsWithPagination;


            var productImages = db.TAnhSps.Where(p => p.MaSp == id).ToList();
            var productDetail = new UserProductDetailViewModel
            {
                product = product,
                productImages = productImages
            };


            return PartialView("Index", productDetail);
        }
    }
}
