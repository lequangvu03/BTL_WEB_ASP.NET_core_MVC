
using System.ComponentModel.DataAnnotations;

namespace SmartWatch_MVC.Models;

public partial class TDanhMucSp
{
    public TDanhMucSp()
    {
        TChiTietHdbs = new HashSet<TChiTietHdb>();
    }

    public int MaSp { get; set; }
    public string? TenSp { get; set; }
    public string? MaChatLieu { get; set; }
    public double? CanNang { get; set; }
    public string? MaHangSx { get; set; }
    public string? MaNuocSx { get; set; }
    public string? MaDacTinh { get; set; }
    public double? ThoiGianBaoHanh { get; set; }
    public string? GioiThieuSp { get; set; }
    public double? ChietKhau { get; set; }
    public string? MaLoai { get; set; }
    public string? MaDt { get; set; }
    public string? AnhDaiDien { get; set; }
    public decimal? GiaNhoNhat { get; set; }
    public decimal? GiaLonNhat { get; set; }

    public virtual TChatLieu? MaChatLieuNavigation { get; set; }
    public virtual TLoaiDt? MaDtNavigation { get; set; }
    public virtual THangSx? MaHangSxNavigation { get; set; }
    public virtual TLoaiSp? MaLoaiNavigation { get; set; }
    public virtual TQuocGium? MaNuocSxNavigation { get; set; }
    public virtual TGioHang? TGioHang { get; set; }
    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; }
    public TDanhMucSp(
			int maSp,
			string? tenSp,
			string? maChatLieu,

			double? canNang,

			string? maHangSx,
			string? maNuocSx,
			string? maDacTinh,

			double? thoiGianBaoHanh,
			string? gioiThieuSp,
			double? chietKhau,
			string? maLoai,
			string? maDt,
			string? anhDaiDien,
			decimal? giaNhoNhat,
			decimal? giaLonNhat)
	{
		MaSp = maSp;
		TenSp = tenSp;
		MaChatLieu = maChatLieu;
		CanNang = canNang;
		MaHangSx = maHangSx;
		MaNuocSx = maNuocSx;
		MaDacTinh = maDacTinh;
		ThoiGianBaoHanh = thoiGianBaoHanh;
		GioiThieuSp = gioiThieuSp;
		ChietKhau = chietKhau;
		MaLoai = maLoai;
		MaDt = maDt;
		AnhDaiDien = anhDaiDien;
		GiaNhoNhat = giaNhoNhat;
		GiaLonNhat = giaLonNhat;
	}
}
