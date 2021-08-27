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
    public class DoktorController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public DoktorController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Doktor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doktor>>> GetDoktor()
        {
            return await _context.Doktor.ToListAsync();
        }

        // GET: api/Doktor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doktor>> GetDoktor(int id)
        {
            var doktor = await _context.Doktor.FindAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            return doktor;
        }

        // PUT: api/Doktor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoktor(int id, Doktor doktor)
        {
            if (id != doktor.DocId)
            {
                return BadRequest();
            }

            _context.Entry(doktor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoktorExists(id))
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

        // POST: api/Doktor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doktor>> PostDoktor(Doktor doktor)
        {
            _context.Doktor.Add(doktor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoktor", new { id = doktor.DocId }, doktor);
        }

        // DELETE: api/Doktor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doktor>> DeleteDoktor(int id)
        {
            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            _context.Doktor.Remove(doktor);
            await _context.SaveChangesAsync();

            return doktor;
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktor.Any(e => e.DocId == id);
        }
    }
}
