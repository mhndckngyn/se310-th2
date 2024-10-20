using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using se310_th2.Context;
using se310_th2.Models;
using X.PagedList;

namespace se310_th2.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin")]
[Route("admin/homeadmin")]
public class AdminHomeController : Controller
{
    private MyDbContext db = new MyDbContext(); 
    // GET
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("danhmucsanpham")]
    public IActionResult DanhMucSanPham(int? page)
    {
        const int PAGE_SIZE = 16;
        int pageNumber = page is null or < 0 ? 1 : page.Value;
        var products = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
        PagedList<TDanhMucSp> pagedProducts = new PagedList<TDanhMucSp>(products, pageNumber, PAGE_SIZE);
        return View(pagedProducts);
    }

    [Route("themsanphammoi")]
    [HttpGet]
    public IActionResult ThemSanPhamMoi()
    {
        ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
        ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
        ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
        ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
        ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
        return View();
    }

    [Route("themsanphammoi")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
    {
        if (ModelState.IsValid)
        {
            db.TDanhMucSps.Add(sanPham);
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }
        return View(sanPham);
    } 
}