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
    public class HastalikController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public HastalikController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Hastalik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hastalik>>> GetHastalik()
        {
            return await _context.Hastalik.ToListAsync();
        }

        // GET: api/Hastalik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hastalik>> GetHastalik(int id)
        {
            var hastalik = await _context.Hastalik.FindAsync(id);

            if (hastalik == null)
            {
                return NotFound();
            }

            return hastalik;
        }

        // PUT: api/Hastalik/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHastalik(int id, Hastalik hastalik)
        {
            if (id != hastalik.IllId)
            {
                return BadRequest();
            }

            _context.Entry(hastalik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HastalikExists(id))
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

        // POST: api/Hastalik
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hastalik>> PostHastalik(Hastalik hastalik)
        {
            _context.Hastalik.Add(hastalik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHastalik", new { id = hastalik.IllId }, hastalik);
        }

        // DELETE: api/Hastalik/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hastalik>> DeleteHastalik(int id)
        {
            var hastalik = await _context.Hastalik.FindAsync(id);
            if (hastalik == null)
            {
                return NotFound();
            }

            _context.Hastalik.Remove(hastalik);
            await _context.SaveChangesAsync();

            return hastalik;
        }

        private bool HastalikExists(int id)
        {
            return _context.Hastalik.Any(e => e.IllId == id);
        }
    }
}
