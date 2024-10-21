using Microsoft.AspNetCore.Mvc;
using se310_th2.Context;
using se310_th2.Models;

namespace se310_th2.Controllers;

public class AccessController : Controller
{
    private MyDbContext db = new MyDbContext();
    
    [HttpGet]
    public IActionResult LogIn()
    {
        if (HttpContext.Session.GetString("username") == null)
        {
            return View(); // haven't logged in
        }
        
        // already logged in
        if (HttpContext.Session.GetString("userType") == "admin")
        {
            return RedirectToAction("Index", "AdminHome");
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult LogIn(TUser user)
    {
        if (HttpContext.Session.GetString("username") != null) // already logged in
        {
            return View();
        }
                
        var u = db.TUsers.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
        if (u == null) // login info is incorrect
        {
            return View();
        }
        
        HttpContext.Session.SetString("username", user.Username);
        
        if (u.LoaiUser == 1)
        {
            HttpContext.Session.SetString("userType", "admin");
            return RedirectToAction("Index", "AdminHome");
        }
        
        HttpContext.Session.SetString("userType", "customer");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        HttpContext.Session.Remove("username");
        return RedirectToAction("LogIn", "Access");
    }
}