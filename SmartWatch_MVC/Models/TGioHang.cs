using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TGioHang
{
    public int? MaKhachHang { get; set; }

    public int MaSp { get; set; }

    public int? SoLuong { get; set; }

    public decimal? GiaBan { get; set; }

    public virtual TKhachHang? MaKhachHangNavigation { get; set; }

    public virtual TDanhMucSp MaSpNavigation { get; set; } 
}
