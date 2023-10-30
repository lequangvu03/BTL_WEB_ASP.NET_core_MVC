using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class THoaDonBan
{
    public int MaHoaDon { get; set; } 

    public DateTime? NgayHoaDon { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaNhanVien { get; set; }

    public decimal? TongTienHd { get; set; }

    public double? GiamGiaHd { get; set; }

    public byte? PhuongThucThanhToan { get; set; }

    public string? MaSoThue { get; set; }

    public string? ThongTinThue { get; set; }

    public string? GhiChu { get; set; }

    public virtual TKhachHang? MaKhachHangNavigation { get; set; }

    public virtual TNhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; } = new List<TChiTietHdb>();
}
