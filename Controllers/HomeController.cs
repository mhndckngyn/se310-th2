using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using se310_th2.Context;
using se310_th2.Models;
using se310_th2.Models.Authentication;
using se310_th2.ViewModels;
using X.PagedList;

namespace se310_th2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyDbContext db = new MyDbContext();
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authentication]
    public IActionResult Index(int? page)
    {
        const int pageSize = 12;
        var pageNumber = (int)(page is null or < 0 ? 1 : page);
        var products = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
        var pagedProducts = new PagedList<TDanhMucSp>(products, pageNumber, pageSize);
        return View(pagedProducts);
    }

    public IActionResult SanPhamTheoLoai(string maLoai, int? page)
    {
        const int pageSize = 8;
        var pageNumber = (int)(page is null or < 0 ? 1 : page);
        var products = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp);
        var pagedProducts = new PagedList<TDanhMucSp>(products, pageNumber, pageSize);
        ViewBag.maLoai = maLoai;
        return View(pagedProducts);
    }

    public IActionResult ChiTietSanPham(string maSp)
    {
        var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        ViewBag.anhSanPham = anhSanPham;
        return View(sanPham);
    }

    public IActionResult ChiTietSanPhamViewMdl(string maSp)
    {
        var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        var homeProductDetailViewModel = new HomeProductDetailViewModel { DanhMucSp = sanPham, AnhSps = anhSanPham };
        return View(homeProductDetailViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}