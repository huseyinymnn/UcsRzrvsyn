using Microsoft.AspNetCore.Mvc;
using UcusRez.Models;

namespace UcusRez.Controllers
{
	public class KullaniciController : Controller
	{
		private readonly DbUcus _dbucus;

		public KullaniciController(DbUcus _dbucus)
		{
			this._dbucus = _dbucus;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(Kayit ekleKayit)
		{
			var kontrol = _dbucus.Kayits.Where(x => x.KayitMail == ekleKayit.KayitMail && x.KayitPassword == ekleKayit.KayitPassword).FirstOrDefault();

			if (kontrol!=null) {

				
                HttpContext.Session.SetString("username", kontrol.KayitName + " " + kontrol.KayitSurname);
                var isim = HttpContext.Session.GetString("username");
                ViewBag.username = isim;
                return RedirectToAction("Hosgeldin", "Anasayfa");
            }
            


            ViewBag.error = "Kullanıcı bulunamadı!";
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task <IActionResult> Register(Kayit ekleKayit, string KayitMail)
		{
			var MailVarsa = _dbucus.Kayits.Any(x => x.KayitMail == KayitMail);
			if (MailVarsa) {

				ViewBag.error = "Email adresi kayıtlı!";
				return View();
			}

			if (ekleKayit.KayitPassword != ekleKayit.ConfKayitPassword) {

				ViewBag.error = "Şifreler eşleşmedi!";
				return View();
			}

			var kullanici = new Kayit()
			{ 
				KayitID=ekleKayit.KayitID,
				KayitName=ekleKayit.KayitName,
				KayitSurname=ekleKayit.KayitSurname,
				KayitMail=ekleKayit.KayitMail,
				KayitPassword=ekleKayit.KayitPassword,
				ConfKayitPassword=ekleKayit.ConfKayitPassword,
			};

			await _dbucus.Kayits.AddAsync(kullanici);
			await _dbucus.SaveChangesAsync();
			ViewBag.correct = "Kayıt işlemi başarı ile gerçekleşti!Giriş yapabilirsiniz.";

			return View("Register");
		}
	}
}
