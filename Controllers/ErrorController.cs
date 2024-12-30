using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}