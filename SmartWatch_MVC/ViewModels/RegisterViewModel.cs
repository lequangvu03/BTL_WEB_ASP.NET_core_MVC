using System.ComponentModel.DataAnnotations;

namespace SmartWatch_MVC.Models
{
    public class RegisterViewModel
    {
    //    [Required(ErrorMessage = "Mã khách hàng là trường bắt buộc.")]
        public int MaKhachHang { get; set; } 

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc.")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        public string Password { get; set; } = null!;

    //   [Required(ErrorMessage = "Loại người dùng là trường bắt buộc.")]
        public int? LoaiUser { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là trường bắt buộc.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Tên khách hàng là trường bắt buộc.")]
        public string? TenKhachHang { get; set; }

        [Required(ErrorMessage = "Ngày sinh là trường bắt buộc.")]
        public DateTime? NgaySinh { get; set; }

        [Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
        public string? SoDienThoai { get; set; }

        [Required(ErrorMessage = "Địa chỉ là trường bắt buộc.")]
        public string? DiaChi { get; set; }

      //  [Required(ErrorMessage = "Loại khách hàng là trường bắt buộc.")]
        public byte? LoaiKhachHang { get; set; }

      //  [Required(ErrorMessage = "Ảnh đại diện là trường bắt buộc.")]
        public string? AnhDaiDien { get; set; }

     //   [Required(ErrorMessage = "Ghi chú là trường bắt buộc.")]
        public string? GhiChu { get; set; }
    }
}
