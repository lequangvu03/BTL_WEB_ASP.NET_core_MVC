using Microsoft.AspNetCore.Mvc;
using SmartWatch_MVC.Models;
using SmartWatch_MVC.ViewModels;

using System.Diagnostics;
using System.Linq;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    
  
    [Route ("Access")]
    public class AccessController : Controller
    {
        QLBanDongHoContext db = new QLBanDongHoContext ();


        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            var userName = HttpContext.Session.GetString("Username");
            if (userName == null)
            {
                // Thực hiện xử lý khi giá trị không tồn tại trong phiên
                return View();
            }
            else
            {
            return RedirectToAction("Index","User");
            }
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(TUser user)
        {
           
            if(HttpContext.Session.GetString("Username") == null )
            {
                var check = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (check != null)
                {
                        HttpContext.Session.SetString("Username", check.Username.ToString());
                    if(check.LoaiUser == 1)
                    {
                        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                    }
                    else {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    TempData["Error"] = "Incorrect Username or Password";
                }
            }
            
            return View();
        }

 
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login","Access");
        }
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }
        [Route("Signup")]
        [HttpPost]
        public IActionResult Signup(RegisterViewModel user)
        {
           
                
                var check = db.TUsers.FirstOrDefault(x => x.Username == user.Username);
                if (check == null)
                {
              
                    TKhachHang cus = new TKhachHang(user.MaKhachHang,user.Username,user.TenKhachHang,user.NgaySinh,user.SoDienThoai,user.DiaChi,
                    user.LoaiKhachHang,user.AnhDaiDien,user.GhiChu);
                    TUser us = new TUser(user.Username,user.Password,2); 
                    db.TUsers.Add(us);
                    db.SaveChanges();
                    db.TKhachHangs.Add(cus);
                    db.SaveChanges();
                    
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "User already exists";
                    return View();
                }
            
          
        }
    }
}
