using Microsoft.AspNetCore.Mvc;

namespace se310_th2.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin")]
[Route("admin/homeadmin")]
public class AdminHomeController : Controller
{
    // GET
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}