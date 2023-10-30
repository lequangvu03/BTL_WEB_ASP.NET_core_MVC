using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TKhachHang
{
    public int MaKhanhHang { get; set; }

    public string? Username { get; set; }

    public string? TenKhachHang { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public byte? LoaiKhachHang { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<TGioHang> TGioHangs { get; set; } = new List<TGioHang>();

    public virtual ICollection<THoaDonBan> THoaDonBans { get; set; } = new List<THoaDonBan>();

    public virtual TUser? UsernameNavigation { get; set; }

	public TKhachHang() { }
	public TKhachHang(
		 int maKhanhHang,
		 string? username,
		 string? tenKhachHang,
		 DateTime? ngaySinh,
		 string? soDienThoai,
		 string? diaChi,
		 byte? loaiKhachHang,
		 string? anhDaiDien,
		 string? ghiChu)
	{
		MaKhanhHang = maKhanhHang;
		Username = username;
		TenKhachHang = tenKhachHang;
		NgaySinh = ngaySinh;
		SoDienThoai = soDienThoai;
		DiaChi = diaChi;
		LoaiKhachHang = loaiKhachHang;
		AnhDaiDien = anhDaiDien;
		GhiChu = ghiChu;
	}
}
