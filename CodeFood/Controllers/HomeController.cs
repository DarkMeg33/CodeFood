using Microsoft.AspNetCore.Mvc;

namespace CodeFood.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
