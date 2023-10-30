using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models;

public partial class TChatLieu
{
    public string MaChatLieu { get; set; } = null!;

    public string? ChatLieu { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
