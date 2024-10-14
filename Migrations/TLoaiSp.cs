using System;
using System.Collections.Generic;

namespace se310_th2.Migrations;

public partial class TLoaiSp
{
    public string MaLoai { get; set; } = null!;

    public string? Loai { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
