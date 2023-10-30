//using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;
using X.PagedList;

namespace SmartWatch_MVC.Controllers
{

    public class UserController : Controller
    {

        QLBanDongHoContext db = new QLBanDongHoContext();
        public async Task<IActionResult> Index(int? page)
        {
            int size = 4;
            int pageNumber = page ?? 1;
            var productList = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(productList, pageNumber, size);

            var types = db.TLoaiSps.ToList();
/*
            foreach (var type in db.TLoaiSps)
            {
                types.Add(new SelectListItem
                {
                    Text = type.Loai,
                    Value = type.MaLoai
                });
            }*/

            ViewBag.Types = types;
            return View(list);
        }
        public IActionResult FilterProductListByType(string? type, int? page, string? search)
        {
            int pageNumber = page.HasValue ? page.Value : 1; // Trang mặc định nếu không được xác định
            int pageSize = 4;
            List<TDanhMucSp> productList = null;
            ViewBag.Type = "All brand";

            if ((type == null || type.Equals("ALL")))
            {
                ViewBag.Type = "All brand";
                productList = db.TDanhMucSps.OrderBy(x => x.TenSp).ToList();
                IPagedList<TDanhMucSp> pagedProductList1 = productList.ToPagedList(pageNumber, pageSize);
                return PartialView("Fillpage", pagedProductList1);
            }
            else
            {
                if (type != null)
                {
                    var selectedType = db.TLoaiSps
                  .Where(t => t.MaLoai == type)
                  .Select(t => new SelectListItem
                  {
                      Text = t.Loai,
                      Value = t.MaLoai
                  })
                  .FirstOrDefault();
                    ViewBag.Type = selectedType.Text;
                    productList = db.TDanhMucSps.Where(p => p.MaLoai == type).OrderBy(x => x.TenSp).ToList();
                    IPagedList<TDanhMucSp> pagedProductList = productList.ToPagedList(pageNumber, pageSize);

                    return PartialView("Fillpage", pagedProductList);
                }
                else
                {
                    ViewBag.Type = "All brand";
                    productList = db.TDanhMucSps.OrderBy(x => x.TenSp).ToList();
                    IPagedList<TDanhMucSp> pagedProductList = productList.ToPagedList(pageNumber, pageSize);
                    return PartialView("Fillpage", pagedProductList);
                }

            }

        }
        public IActionResult SearchProductListByType(int? page, string? search)
        {
            int pageNumber = page.HasValue ? page.Value : 1; // Trang mặc định nếu không được xác định
            int pageSize = 4;
            List<TDanhMucSp> productList = null;
            ViewBag.Type = "All brand";
            if (search == null)
            {
                ViewBag.Type = "No brand";
                productList = null;
                IPagedList<TDanhMucSp> pagedProductList1 = productList.ToPagedList(pageNumber, pageSize);
                return PartialView("Fillpage", pagedProductList1);
            }
            else
            {
                ViewBag.Type = $"Search:  {search}";
                productList = db.TDanhMucSps.Where(p => p.TenSp.Contains(search)).OrderBy(x => x.TenSp).ToList();
                IPagedList<TDanhMucSp> pagedProductList = productList.ToPagedList(pageNumber, pageSize);
                return PartialView("Fillpage", pagedProductList);
            }

        }
        public IActionResult About()
        {
            return View();
        }
        [Route("products/details")]
        public IActionResult Details(int id, int? page)
        {
            int pageSize = 1;
            int pageNumber = page == null || page < -1 ? 1 : page.Value;

            var product = db.TDanhMucSps.SingleOrDefault(p => p.MaSp == id);
            var relevantProducts = db.TDanhMucSps.AsNoTracking().Where(p => p.MaLoai == product.MaLoai && p.MaSp != id).OrderBy(p => p.TenSp).ToList();
            ViewBag.ProductID = id;

            PagedList<TDanhMucSp> relevantProductsWithPagination = new PagedList<TDanhMucSp>(relevantProducts, pageNumber, pageSize);
            ViewBag.RelevantProducts = relevantProductsWithPagination;

            var productImages = db.TAnhSps.Where(p => p.MaSp == id).ToList();
            var productDetail = new UserProductDetailViewModel
            {
                product = product,
                productImages = productImages
            };


            return View("ProductDetail", productDetail);
        }

        /* [Route("User/Cart")]*/
        public IActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return View("Cart/Index");
            }

            var product = db.TDanhMucSps.FirstOrDefault(p => p.MaSp == id);

            return View("Cart/Index", product);
        }


    }
}
