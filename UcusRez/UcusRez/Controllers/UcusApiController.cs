using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UcusRez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcusApiController : ControllerBase
    {
        private readonly DbUcus _dbUcus; // Replace YourDbContext with your actual DbContext type

        public UcusApiController(DbUcus context)
        {
            _dbUcus = context;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var ucuslar = _dbUcus.Ucuss.ToList();
            return Ok(ucuslar);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ucus = _dbUcus.Ucuss.Find(id);

            if (ucus == null)
            {
                return NotFound();
            }

            return Ok(ucus);
        }

        // POST api/<AircraftApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ucus ucus)
        {
            if (ModelState.IsValid)
            {
                await _dbUcus.Ucuss.AddAsync(ucus);
                await _dbUcus.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = ucus.UcusID }, ucus);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<AircraftApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ucus guncellenmisUcus)
        {
            if (id != guncellenmisUcus.UcusID)
            {
                return BadRequest();
            }

            _dbUcus.Entry(guncellenmisUcus).State = EntityState.Modified;

            try
            {
                await _dbUcus.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UcusVarMi(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ucus = await _dbUcus.Ucuss.FindAsync(id);

            if (ucus == null)
            {
                return NotFound();
            }

            _dbUcus.Ucuss.Remove(ucus);
            await _dbUcus.SaveChangesAsync();

            return NoContent();
        }

        private bool UcusVarMi(int id)
        {
            return _dbUcus.Ucuss.Any(e => e.UcusID == id);
        }
    }
}
