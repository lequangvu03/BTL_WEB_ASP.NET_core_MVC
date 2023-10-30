
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;


namespace SmartWatch_MVC.Controllers
{
    public class CartController : Controller
    {

        QLBanDongHoContext db = new QLBanDongHoContext();

        public ActionResult AddToCart(int? id)
        {
            TGioHang cart = db.TGioHangs.FirstOrDefault(p => p.MaSp == id);

            if (cart == null)
            {
                // Kiểm tra theo mã khách hàng </>
                TDanhMucSp product = db.TDanhMucSps.FirstOrDefault(p => p.MaSp == id);

                TGioHang cartItem = new TGioHang
                {
                    // Thay "YourCustomerId" bằng mã khách hàng thực tế
                    MaKhachHang = 10,
                    MaSp = product.MaSp,
                    SoLuong = 1,
                    GiaBan = product.GiaNhoNhat
                };

                db.TGioHangs.Add(cartItem);
            }
            else
            {
                cart.SoLuong += 1;
            }
            // Thêm vào database 
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult RemoveCartItem(int? id)
        {
            TGioHang cart = db.TGioHangs.FirstOrDefault(p => p.MaSp == id);

            if (cart != null)
            {
                db.Remove(cart);
            }
            else
            {
                ViewBag.Message = "Xóa sản phẩm khỏi giỏ hàng thất bại!";
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }



        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            var cart = db.TGioHangs.Include(item => item.MaSpNavigation).ToList();

            decimal tongGiaBan = 0;

            // Lặp qua danh sách sản phẩm trong giỏ hàng và cộng giá bán của từng sản phẩm vào tổng giá
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    tongGiaBan += Convert.ToDecimal(item.GiaBan * item.SoLuong);
                }
                ViewBag.TongGiaBan = tongGiaBan;
            }
            else
            {
                ViewBag.TongGiaBan = 0;
            }


            return View("Index", cart);
        }

        public ActionResult Pay()
        {


            if (true)
            {
                // Thanh toán thành công => xóa tất cả sản phẩm khỏi giỏ hàng
                List<TGioHang> cartItems = db.TGioHangs.ToList();

                db.TGioHangs.RemoveRange(cartItems);
            }
            else
            {
                // ...
            }

            return RedirectToAction("Index");
        }

        public ActionResult Up(int id)
        {
            TGioHang cart = db.TGioHangs.FirstOrDefault(p => p.MaSp == id);
            cart.SoLuong += 1;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Down(int id)
        {
            TGioHang cart = db.TGioHangs.FirstOrDefault(p => p.MaSp == id);
            cart.SoLuong -= 1;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
