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
    public class TedaviController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public TedaviController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Tedavi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tedavi>>> GetTedavi()
        {
            return await _context.Tedavi.ToListAsync();
        }

        // GET: api/Tedavi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tedavi>> GetTedavi(int id)
        {
            var tedavi = await _context.Tedavi.FindAsync(id);

            if (tedavi == null)
            {
                return NotFound();
            }

            return tedavi;
        }

        // PUT: api/Tedavi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTedavi(int id, Tedavi tedavi)
        {
            if (id != tedavi.TmtId)
            {
                return BadRequest();
            }

            _context.Entry(tedavi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TedaviExists(id))
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

        // POST: api/Tedavi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tedavi>> PostTedavi(Tedavi tedavi)
        {
            _context.Tedavi.Add(tedavi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTedavi", new { id = tedavi.TmtId }, tedavi);
        }

        // DELETE: api/Tedavi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tedavi>> DeleteTedavi(int id)
        {
            var tedavi = await _context.Tedavi.FindAsync(id);
            if (tedavi == null)
            {
                return NotFound();
            }

            _context.Tedavi.Remove(tedavi);
            await _context.SaveChangesAsync();

            return tedavi;
        }

        private bool TedaviExists(int id)
        {
            return _context.Tedavi.Any(e => e.TmtId == id);
        }
    }
}
