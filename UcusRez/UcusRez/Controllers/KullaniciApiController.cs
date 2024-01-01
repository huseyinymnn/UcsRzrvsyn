using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UcusRez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciApiController : ControllerBase
    {
        private readonly DbUcus _dbUcus; // Replace YourDbContext with your actual DbContext type

        public KullaniciApiController(DbUcus context)
        {
            _dbUcus = context;
        }

        // GET: api/<AircraftApiController>
        [HttpGet]
        public IActionResult Get()
        {
            var kullanicilar = _dbUcus.Kayits.ToList();
            return Ok(kullanicilar);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var kullanici = _dbUcus.Ucaks.Find(id);

            if (kullanici == null)
            {
                return NotFound();
            }

            return Ok(kullanici);
        }

        // POST api/<AircraftApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ucak ucak)
        {
            if (ModelState.IsValid)
            {
                await _dbUcus.Ucaks.AddAsync(ucak);
                await _dbUcus.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = ucak.UcakID }, ucak);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<AircraftApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ucak guncellenmisUcak)
        {
            if (id != guncellenmisUcak.UcakID)
            {
                return BadRequest();
            }

            _dbUcus.Entry(guncellenmisUcak).State = EntityState.Modified;

            try
            {
                await _dbUcus.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciVarMi(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<AircraftApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kullanici = await _dbUcus.Kayits.FindAsync(id);

            if (kullanici == null)
            {
                return NotFound();
            }

            _dbUcus.Kayits.Remove(kullanici);
            await _dbUcus.SaveChangesAsync();

            return NoContent();
        }

        private bool KullaniciVarMi(int id)
        {
            return _dbUcus.Kayits.Any(e => e.KayitID == id);
        }

    }
}
