using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObezIndexAPI.Models;

namespace ObezIndexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public HastaController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Hasta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hasta>>> GetHasta()
        {
            return await _context.Hasta.ToListAsync();
        }

        // GET: api/Hasta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hasta>> GetHasta(int id)
        {
            var hasta = await _context.Hasta.FindAsync(id);

            if (hasta == null)
            {
                return NotFound();
            }

            return hasta;
        }

        // PUT: api/Hasta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHasta(int id, Hasta hasta)
        {
            if (id != hasta.PatId)
            {
                return BadRequest();
            }

            _context.Entry(hasta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HastaExists(id))
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

        // POST: api/Hasta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hasta>> PostHasta(Hasta hasta)
        {
            _context.Hasta.Add(hasta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHasta", new { id = hasta.PatId }, hasta);
        }

        // DELETE: api/Hasta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hasta>> DeleteHasta(int id)
        {
            var hasta = await _context.Hasta.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }

            _context.Hasta.Remove(hasta);
            await _context.SaveChangesAsync();

            return hasta;
        }

        private bool HastaExists(int id)
        {
            return _context.Hasta.Any(e => e.PatId == id);
        }
    }
}
