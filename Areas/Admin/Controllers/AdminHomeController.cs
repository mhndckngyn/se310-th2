using Microsoft.AspNetCore.Mvc;
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
}