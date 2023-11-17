using System.Diagnostics;
using Loginwithcookes.Context;
using Microsoft.AspNetCore.Mvc;
using Loginwithcookes.Models;
using Loginwithcookes.Models.entity;

namespace Loginwithcookes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _myContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public HomeController(ILogger<HomeController> logger, MyContext myContext, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _myContext = myContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        var usercheker = _myContext.user.Where(x => x.usename == user.usename && x.password == user.password);
        if (usercheker.Count() > 0)
        {
             SetAuthenticationCookie(user.usename);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Invalid username or password";
        return View();
    
    }
    private void SetAuthenticationCookie(string username)
    {
        var options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1), // مدت زمان انقضاء کوکی (مثال: یک روز)
            HttpOnly = true
        };

        _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthenticationCookie", username, options);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}