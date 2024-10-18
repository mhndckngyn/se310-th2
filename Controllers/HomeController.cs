using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using se310_th2.Context;
using se310_th2.Migrations;
using se310_th2.Models;
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

    public IActionResult Index(int? page)
    {
        const int PAGE_SIZE = 12;
        int pageNumber = (int)(page is null or < 0 ? 1 : page);
        var products = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
        PagedList<TDanhMucSp> pagedProducts = new PagedList<TDanhMucSp>(products, pageNumber, PAGE_SIZE);
        return View(pagedProducts);
    }

    public IActionResult SanPhamTheoLoai(string maLoai, int? page)
    {
        const int PAGE_SIZE = 8;
        int pageNumber = (int)(page is null or < 0 ? 1 : page);
        var products = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp);
        PagedList<TDanhMucSp> pagedProducts = new PagedList<TDanhMucSp>(products, pageNumber, PAGE_SIZE);
        ViewBag.maLoai = maLoai;
        return View(pagedProducts);
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