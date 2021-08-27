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
    public class UzmanlikController : ControllerBase
    {
        private readonly ObezIndex1Context _context;

        public UzmanlikController(ObezIndex1Context context)
        {
            _context = context;
        }

        // GET: api/Uzmanlik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uzmanlik>>> GetUzmanlik()
        {
            return await _context.Uzmanlik.ToListAsync();
        }

        // GET: api/Uzmanlik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uzmanlik>> GetUzmanlik(int id)
        {
            var uzmanlik = await _context.Uzmanlik.FindAsync(id);

            if (uzmanlik == null)
            {
                return NotFound();
            }

            return uzmanlik;
        }

        // PUT: api/Uzmanlik/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUzmanlik(int id, Uzmanlik uzmanlik)
        {
            if (id != uzmanlik.ProId)
            {
                return BadRequest();
            }

            _context.Entry(uzmanlik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzmanlikExists(id))
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

        // POST: api/Uzmanlik
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Uzmanlik>> PostUzmanlik(Uzmanlik uzmanlik)
        {
            _context.Uzmanlik.Add(uzmanlik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUzmanlik", new { id = uzmanlik.ProId }, uzmanlik);
        }

        // DELETE: api/Uzmanlik/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Uzmanlik>> DeleteUzmanlik(int id)
        {
            var uzmanlik = await _context.Uzmanlik.FindAsync(id);
            if (uzmanlik == null)
            {
                return NotFound();
            }

            _context.Uzmanlik.Remove(uzmanlik);
            await _context.SaveChangesAsync();

            return uzmanlik;
        }

        private bool UzmanlikExists(int id)
        {
            return _context.Uzmanlik.Any(e => e.ProId == id);
        }
    }
}
