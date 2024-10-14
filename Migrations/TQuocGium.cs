using System;
using System.Collections.Generic;

namespace se310_th2.Migrations;

public partial class TQuocGium
{
    public string MaNuoc { get; set; } = null!;

    public string? TenNuoc { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
