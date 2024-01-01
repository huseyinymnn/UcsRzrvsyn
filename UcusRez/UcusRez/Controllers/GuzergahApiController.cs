using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UcusRez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuzergahApiController : ControllerBase
    {
        private readonly DbUcus _dbUcus; // Replace YourDbContext with your actual DbContext type

        public GuzergahApiController(DbUcus context)
        {
            _dbUcus = context;
        }

        // GET: api/<AircraftApiController>
        [HttpGet]
        public IActionResult Get()
        {
            var guzergahlar = _dbUcus.Guzergahs.ToList();
            return Ok(guzergahlar);
        }

        // GET api/<AircraftApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var guzergah = _dbUcus.Guzergahs.Find(id);

            if (guzergah == null)
            {
                return NotFound();
            }

            return Ok(guzergah);
        }

        // POST api/<AircraftApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Guzergah guzergah)
        {
            if (ModelState.IsValid)
            {
                await _dbUcus.Guzergahs.AddAsync(guzergah);
                await _dbUcus.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = guzergah.GuzergahID }, guzergah);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<AircraftApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Guzergah guncellenmisGuzergah)
        {
            if (id != guncellenmisGuzergah.GuzergahID)
            {
                return BadRequest();
            }

            _dbUcus.Entry(guncellenmisGuzergah).State = EntityState.Modified;

            try
            {
                await _dbUcus.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuzergahVarMi(id))
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
            var guzergah = await _dbUcus.Guzergahs.FindAsync(id);

            if (guzergah == null)
            {
                return NotFound();
            }

            _dbUcus.Guzergahs.Remove(guzergah);
            await _dbUcus.SaveChangesAsync();

            return NoContent();
        }

        private bool GuzergahVarMi(int id)
        {
            return _dbUcus.Guzergahs.Any(e => e.GuzergahID == id);
        }
    }
}
