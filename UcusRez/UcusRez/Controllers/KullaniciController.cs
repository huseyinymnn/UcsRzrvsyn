using Microsoft.AspNetCore.Mvc;

namespace UcusRez.Controllers
{
	public class KullaniciController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}
	}
}
