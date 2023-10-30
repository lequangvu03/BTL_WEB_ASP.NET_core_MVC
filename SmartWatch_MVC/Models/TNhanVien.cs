using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TNhanVien
{
    public int MaNhanVien { get; set; }
    public string? Username { get; set; }

    public string? TenNhanVien { get; set; }

    public string GioiTinh { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<THoaDonBan> THoaDonBans { get; set; } = new List<THoaDonBan>();

    public virtual TUser? UsernameNavigation { get; set; }

	public TNhanVien(
		   int maNhanVien,
		   string? username,
		   string? tenNhanVien,
		   DateTime? ngaySinh,
		   string? soDienThoai,
		   string? diaChi,
		   string? chucVu,
		   string? anhDaiDien,
		   string? ghiChu,
		   string? gioiTinh)
	{
		MaNhanVien = maNhanVien;
		Username = username;
		TenNhanVien = tenNhanVien;
		NgaySinh = ngaySinh;
		SoDienThoai = soDienThoai;
		DiaChi = diaChi;
		ChucVu = chucVu;
		AnhDaiDien = anhDaiDien;
		GhiChu = ghiChu;
		GioiTinh = gioiTinh;
	}
}
