using Microsoft.AspNetCore.Mvc;

namespace UcusRez.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
