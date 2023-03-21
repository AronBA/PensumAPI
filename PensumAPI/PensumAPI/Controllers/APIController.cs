#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PensumAPI.Data;
using PensumAPI.Models;

namespace PensumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public APIController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lektion>>> GetLektions()
        {
            return await _context.Lektions.ToListAsync();
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lektion>> GetLektion(int id)
        {
            var lektion = await _context.Lektions.FindAsync(id);

            if (lektion == null)
            {
                return NotFound();
            }

            return lektion;
        }

        // PUT: api/API/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLektion(int id, Lektion lektion)
        {
            if (id != lektion.Id)
            {
                return BadRequest();
            }

            _context.Entry(lektion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LektionExists(id))
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

        // POST: api/API
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lektion>> PostLektion(Lektion lektion)
        {
            _context.Lektions.Add(lektion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLektion", new { id = lektion.Id }, lektion);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLektion(int id)
        {
            var lektion = await _context.Lektions.FindAsync(id);
            if (lektion == null)
            {
                return NotFound();
            }

            _context.Lektions.Remove(lektion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LektionExists(int id)
        {
            return _context.Lektions.Any(e => e.Id == id);
        }
    }
}
