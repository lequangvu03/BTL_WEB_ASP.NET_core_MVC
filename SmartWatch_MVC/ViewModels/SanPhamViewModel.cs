using SmartWatch_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartWatch_MVC.ViewModels
{
    public class SanPhamViewModel
    {
     //  [Required(ErrorMessage = "Mã sản phẩm là trường bắt buộc.")]
        public int MaSp { get; set; } 

       [Required(ErrorMessage = "Tên sản phẩm là trường bắt buộc.")]
        public string? TenSp { get; set; }
        public string? MaChatLieu { get; set; }

    //    [Required(ErrorMessage = "Cân nặng là trường bắt buộc.")]
        public double? CanNang { get; set; }

   //     [Required(ErrorMessage = "Mã hãng sản xuất là trường bắt buộc.")]
        public string? MaHangSx { get; set; }

    //    [Required(ErrorMessage = "Mã nước sản xuất là trường bắt buộc.")]
        public string? MaNuocSx { get; set; } 
        public string? MaDacTinh { get; set; }

        public double? ThoiGianBaoHanh { get; set; }

    
        public string? GioiThieuSp { get; set; }

       // [Required(ErrorMessage = "Chiết khấu là trường bắt buộc.")]
        public double? ChietKhau { get; set; }

     //   [Required(ErrorMessage = "Mã loại là trường bắt buộc.")]
        public string? MaLoai { get; set; }

     //   [Required(ErrorMessage = "Mã đặc tính là trường bắt buộc.")]
        public string? MaDt { get; set; }

     //   [Required(ErrorMessage = "Ảnh đại diện là trường bắt buộc.")]
        public IFormFile? img { get; set; }
        public List<IFormFile>? Listimg { get; set; }
        public string? Nameimg { get; set; }

    //    [Required(ErrorMessage = "Giá nhỏ nhất là trường bắt buộc.")]
        public decimal? GiaNhoNhat { get; set; }

    //    [Required(ErrorMessage = "Giá lớn nhất là trường bắt buộc.")]
        public decimal? GiaLonNhat { get; set; }
        public SanPhamViewModel() { }
        public SanPhamViewModel(TDanhMucSp x)
        {
            MaSp = x.MaSp;
            TenSp = x.TenSp;
            MaChatLieu = x.MaChatLieu;
            CanNang = x.CanNang;
            MaHangSx = x.MaHangSx;
            MaNuocSx = x.MaNuocSx;
            MaDacTinh = x.MaDacTinh;       
            ThoiGianBaoHanh = x.ThoiGianBaoHanh;
            GioiThieuSp = x.GioiThieuSp;
            ChietKhau = x.ChietKhau;
            MaLoai = x.MaLoai;
            MaDt = x.MaDt;
            img = new FormFile(Stream.Null, 0, 0, "formFileName", x.AnhDaiDien);
            GiaNhoNhat = x.GiaNhoNhat;
            GiaLonNhat = x.GiaLonNhat;
        }
    }
}
