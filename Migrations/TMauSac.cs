using System;
using System.Collections.Generic;

namespace se310_th2.Migrations;

public partial class TMauSac
{
    public string MaMauSac { get; set; } = null!;

    public string? TenMauSac { get; set; }

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
