﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcusRez.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UcusRez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcakApiController : ControllerBase
    {
        private readonly  DbUcus _dbUcus; // Replace YourDbContext with your actual DbContext type

        public UcakApiController(DbUcus context)
        {
            _dbUcus = context;
        }

        // GET: api/<AircraftApiController>
        [HttpGet]
        public IActionResult Get()
        {
            var ucaklar = _dbUcus.Ucaks.ToList();
            return Ok(ucaklar);
        }

        // GET api/<AircraftApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ucak = _dbUcus.Ucaks.Find(id);

            if (ucak == null)
            {
                return NotFound();
            }

            return Ok(ucak);
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
                if (!UcakVarMi(id))
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
            var ucak = await _dbUcus.Ucaks.FindAsync(id);

            if (ucak == null)
            {
                return NotFound();
            }

            _dbUcus.Ucaks.Remove(ucak);
            await _dbUcus.SaveChangesAsync();

            return NoContent();
        }

        private bool UcakVarMi(int id)
        {
            return _dbUcus.Ucaks.Any(e => e.UcakID == id);
        }
    }
}
