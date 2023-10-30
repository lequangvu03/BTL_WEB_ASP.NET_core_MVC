using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? LoaiUser { get; set; }

    public virtual ICollection<TKhachHang> TKhachHangs { get; set; } = new List<TKhachHang>();

    public virtual ICollection<TNhanVien> TNhanViens { get; set; } = new List<TNhanVien>();
	public TUser() { }
	public TUser(string username, string password, int? loaiUser)
	{
		Username = username;
		Password = password;
		LoaiUser = loaiUser;

	}

}
