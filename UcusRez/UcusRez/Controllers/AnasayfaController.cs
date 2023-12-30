﻿using Microsoft.AspNetCore.Mvc;

namespace UcusRez.Controllers
{
	public class AnasayfaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Hosgeldin()
		{
			var isim = HttpContext.Session.GetString("username");
			ViewBag.username = isim;
			return View();
		}
	}
}
