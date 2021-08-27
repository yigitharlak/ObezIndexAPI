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
    public class TaniController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public TaniController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Tani
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tani>>> GetTani()
        {
            return await _context.Tani.ToListAsync();
        }

        // GET: api/Tani/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tani>> GetTani(int id)
        {
            var tani = await _context.Tani.FindAsync(id);

            if (tani == null)
            {
                return NotFound();
            }

            return tani;
        }

        // PUT: api/Tani/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTani(int id, Tani tani)
        {
            if (id != tani.DgnId)
            {
                return BadRequest();
            }

            _context.Entry(tani).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaniExists(id))
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

        // POST: api/Tani
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tani>> PostTani(Tani tani)
        {
            _context.Tani.Add(tani);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTani", new { id = tani.DgnId }, tani);
        }

        // DELETE: api/Tani/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tani>> DeleteTani(int id)
        {
            var tani = await _context.Tani.FindAsync(id);
            if (tani == null)
            {
                return NotFound();
            }

            _context.Tani.Remove(tani);
            await _context.SaveChangesAsync();

            return tani;
        }

        private bool TaniExists(int id)
        {
            return _context.Tani.Any(e => e.DgnId == id);
        }
    }
}
