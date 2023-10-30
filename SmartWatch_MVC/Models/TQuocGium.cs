using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TQuocGium
{
    public string MaNuoc { get; set; } = null!;

    public string? TenNuoc { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();

    public virtual ICollection<THangSx> THangSxes { get; set; } = new List<THangSx>();
}
