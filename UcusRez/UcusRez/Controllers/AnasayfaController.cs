using UcusRez.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using UcusRez.Services;

namespace UcusRez.Controllers
{
	public class AnasayfaController : Controller
	{
        private LanguageService _localization;
        private readonly DbUcus _dbucus;

        public AnasayfaController(DbUcus _dbucus, LanguageService localization)
        {
            _localization = localization;
            this._dbucus = _dbucus;
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Index()
		{
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
		}
        //[Authorize(Roles ="Ui")]
        [HttpGet]
        public IActionResult Hosgeldin()
		{
            var isim = HttpContext.Session.GetString("username");
			ViewBag.username = isim;
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Hosgeldin(Bilet biletEkle, string YolcuPasaport, string KalkisSehri, string VarisSehri, int KoltukNumarasi)
        {
            var isim = HttpContext.Session.GetString("username");
            ViewBag.username = isim;
            var pasaportKontrol = _dbucus.Bilets.Any(x => x.YolcuPasaport == YolcuPasaport);
            var kalkisKontrol = _dbucus.Bilets.Any(x => x.KalkisSehri == KalkisSehri);
            var varisKontrol = _dbucus.Bilets.Any(x => x.VarisSehri == VarisSehri);
            var koltukKontrol = _dbucus.Bilets.Any(x => x.KoltukNumarasi == KoltukNumarasi);
            if (pasaportKontrol && kalkisKontrol && varisKontrol)
            {
                ViewBag.error = "Bu pasaport numarası için bu güzergahta zaten bir rezervasyon oluşturulmuştur!";
                return View();
            }

            if (kalkisKontrol && varisKontrol && koltukKontrol)
            {
                ViewBag.error = "Koltuk Dolu!";
                return View();
            }

            var bilet = new Bilet()
            {
                BiletId = biletEkle.BiletId,
                YolcuAd = biletEkle.YolcuAd,
                YolcuSoyad = biletEkle.YolcuSoyad,
                YolcuCinsiyet = biletEkle.YolcuCinsiyet,
                YolcuPasaport = biletEkle.YolcuPasaport,
                YolcuDogumTarihi = biletEkle.YolcuDogumTarihi,
                YolcuMail = biletEkle.YolcuMail,
                KalkisSehri = biletEkle.KalkisSehri,
                VarisSehri = biletEkle.VarisSehri,
                KalkisTarihi = biletEkle.KalkisTarihi,
                KoltukNumarasi = biletEkle.KoltukNumarasi,
            };

            await _dbucus.Bilets.AddAsync(bilet);
            await _dbucus.SaveChangesAsync();
            ViewBag.correct = "Rezervasyon başarıyla oluşturuldu!";
            return View("Hosgeldin");
        }
    }
}
