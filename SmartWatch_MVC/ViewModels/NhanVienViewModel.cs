using SmartWatch_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartWatch_MVC.ViewModels { 
    public class NhanVienViewModel
    {
     //   [Required(ErrorMessage = "Mã nhân viên là trường bắt buộc.")]
        public int MaNhanVien { get; set; } 

        [Required(ErrorMessage = "Tên đăng nhập là trường bắt buộc.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Tên nhân viên là trường bắt buộc.")]
        public string? TenNhanVien { get; set; }

        [Required(ErrorMessage = "Ngày sinh là trường bắt buộc.")]
        public DateTime? NgaySinh { get; set; }

       // [Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
        public string? SoDienThoai { get; set; }

        [Required(ErrorMessage = "Địa chỉ là trường bắt buộc.")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Chức vụ là trường bắt buộc.")]
        public string? ChucVu { get; set; }

        [Required(ErrorMessage = "Ảnh đại diện là trường bắt buộc.")]
        public IFormFile img { get; set; }

     //   [Required(ErrorMessage = "Ghi chú là trường bắt buộc.")]
        public string? GhiChu { get; set; }

        [Required(ErrorMessage = "Giới tính là trường bắt buộc.")]
        public string? GioiTinh { get; set; }

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc.")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        public string Password { get; set; } = null!;

        public NhanVienViewModel()
        {
        }
        public NhanVienViewModel(TNhanVien x)
        {
            this.MaNhanVien = x.MaNhanVien;
            this.Username = x.Username;
            this.ChucVu = x.ChucVu;
            this.TenNhanVien = x.TenNhanVien;
            this.NgaySinh = x.NgaySinh;
            this.SoDienThoai = x.SoDienThoai;
            this.DiaChi = x.DiaChi;
            this.img = new FormFile(Stream.Null, 0, 0, "formFileName", x.AnhDaiDien);
            this.GhiChu = x.GhiChu;
            this.GioiTinh = x.GioiTinh;
            this.Password = "";
        }

        public NhanVienViewModel(TNhanVien x,TUser y)
        {
            this.MaNhanVien = x.MaNhanVien;
            this.Username = x.Username;
            this.ChucVu = x.ChucVu;
            this.TenNhanVien=x.TenNhanVien;
            this.NgaySinh = x.NgaySinh;
            this.SoDienThoai = x.SoDienThoai;
            this.DiaChi = x.DiaChi;
            this.img = new FormFile(Stream.Null, 0, 0, "formFileName", x.AnhDaiDien);
            this.GhiChu = x.GhiChu;
            this.GioiTinh=x.GioiTinh;
            this.Password = y.Password;
        }
    }
}
