using SmartWatch_MVC.Models;
namespace SmartWatch_MVC.ViewModels
{
    public class HoaDonViewModel
    {
        public THoaDonBan hoaDonBan { get; set; }        
        public TKhachHang TTKhachHang { get; set; }
        public List<ChiTietSanPhamViewModel> ListCTHD { get; set; }
    }

}
