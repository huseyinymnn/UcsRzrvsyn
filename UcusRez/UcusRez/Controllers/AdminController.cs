using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

namespace UcusRez.Controllers
{
    [Authorize(Roles ="Admin")]
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
		{
			
			var ucak = new Ucak()
			{
				UcakID = ekleUcak.UcakID,
				UcakCapacity = ekleUcak.UcakCapacity,
			};

			await _dbucus.Ucaks.AddAsync(ucak);
			await _dbucus.SaveChangesAsync();
			ViewBag.correct = "Uçak ekleme işlemi başarılı!";
			return View("Ucak");

		}

		[HttpGet]
		public async Task<IActionResult> UcakListele()
		{
			var ucaklar = await _dbucus.Ucaks.ToListAsync();
			return View(ucaklar);
		}

		[HttpGet]
        public IActionResult Ucus()
        {
            return View();
        }
		

        [HttpPost]
		public async Task<IActionResult> Ucus(Ucus ekleUcus, int ucakID, int guzergahID)
		{
            var ucakYokMu = _dbucus.Ucaks.Any(x => x.UcakID == ucakID);
			var guzergahYokMu = _dbucus.Guzergahs.Any(x => x.GuzergahID == guzergahID);
            if (!ucakYokMu || !guzergahYokMu)
            {
                ViewBag.error = "Kayıtlı uçak veya güzergah bulunamadı!";
                return View();
            }

        

            var ucus = new Ucus() 
            {
              UcusID=ekleUcus.UcusID,
              UcakID=ekleUcus.UcakID,
              GuzergahID=ekleUcus.GuzergahID,
            };

            await _dbucus.Ucuss.AddAsync(ucus);
            await _dbucus.SaveChangesAsync();
            ViewBag.correct = "Uçuş ekleme işlemi başarılı!";
            return View("Ucus");

		}
		[HttpGet]
		public async Task<IActionResult> UcusListele()
        {
            var ucuss=await _dbucus.Ucuss.ToListAsync();
            return View(ucuss);
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

        [HttpGet]
        public async Task<IActionResult> Kullanicilar()
        {   
            var kullanicilar=await _dbucus.Kayits.ToListAsync();
            return View(kullanicilar);
        }

    }
}
