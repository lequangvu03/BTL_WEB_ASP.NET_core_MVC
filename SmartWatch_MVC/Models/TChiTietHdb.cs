using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TChiTietHdb
{
    public int MaHoaDon { get; set; } 
    public int MaSp { get; set; } 
    public int? SoLuongBan { get; set; }
    public decimal? DonGiaBan { get; set; }
    public double? GiamGia { get; set; }
    public string? GhiChu { get; set; }

    public virtual THoaDonBan MaHoaDonNavigation { get; set; } = null!;
    public virtual TDanhMucSp MaSpNavigation { get; set; } = null!;
}
