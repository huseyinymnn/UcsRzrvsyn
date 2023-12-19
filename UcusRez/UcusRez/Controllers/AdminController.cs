using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

namespace UcusRez.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbUcus _dbucus;

        public AdminController(DbUcus _dbucus)
        { 
            this._dbucus = _dbucus;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ucak()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Ucak(Ucak ekleUcak)
        {   //uçak ekleme işlemini gerçekleştiriyor
            var ucak = new Ucak()
            { 
                UcakID=ekleUcak.UcakID,
                UcakCapacity=ekleUcak.UcakCapacity,
            };

            await _dbucus.Ucaks.AddAsync(ucak);
            await _dbucus.AddRangeAsync();
            ViewBag.correct = "Uçak ekleme işlemi gerçekleştirildi!";

            return View("Ucak");
        }

        [HttpGet]
        public async Task<IActionResult> UcakListele()
        {
            //uçak listeleme işlemini gerçekleştiriyor.

            var ucaklar = await _dbucus.Ucaks.ToListAsync();
            return View(ucaklar);
        }

        public IActionResult Ucus()
        {
            return View();
        }

        public IActionResult UcusListele()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Guzergah()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Guzergah(Guzergah ekleGuzergah, string KalkisSehri, string VarisSehri)
		{
            var KalkisSehriVar=_dbucus.Guzergahs.Any(x=>x.KalkisSehri==KalkisSehri);
			var VarisSehriVar = _dbucus.Guzergahs.Any(x => x.VarisSehri == VarisSehri);
            if (KalkisSehriVar && VarisSehriVar)
            {
                ViewBag.error = "Güzergah daha önceden tanımlanmıştır!";
                return View();
            }

            var guzergah = new Guzergah()
			{
				 GuzergahID=ekleGuzergah.GuzergahID,
                 KalkisSehri=ekleGuzergah.KalkisSehri,
                 VarisSehri=ekleGuzergah.VarisSehri,
			};

            await _dbucus.Guzergahs.AddAsync(guzergah);
            await _dbucus.SaveChangesAsync();
            ViewBag.correct = "Güzergah ekleme işlemi gerçekleştirildi!";
			return View("Guzergah");
		}

        [HttpGet]
		public async Task<IActionResult> GuzergahListele()
        {   
            var guzergahlar=await _dbucus.Guzergahs.ToListAsync();
            return View(guzergahlar);
        }

        public IActionResult Rezervasyon()
        {
            return View();
        }

        public IActionResult Kullanicilar()
        {
            return View();
        }

    }
}
