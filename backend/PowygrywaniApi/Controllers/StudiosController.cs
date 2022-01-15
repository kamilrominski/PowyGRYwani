using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowygrywaniApi.Model;

namespace PowygrywaniApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly ModelContext _context;

        public StudiosController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Studios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> Getstudios()
        {
            return await _context.studios.ToListAsync();
        }

        // GET: api/Studios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            var studio = await _context.studios.FindAsync(id);

            if (studio == null)
            {
                return NotFound();
            }

            studio.Games = _context.games.Where(g => g.Studio_id.Equals(studio.Id)).ToList();

            return studio;
        }

        // PUT: api/Studios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudio(int id, Studio studio)
        {
            if (id != studio.Id)
            {
                return BadRequest();
            }

            _context.Entry(studio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(id))
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

        // POST: api/Studios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studio>> PostStudio(Studio studio)
        {
            _context.studios.Add(studio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudio", new { id = studio.Id }, studio);
        }

        // DELETE: api/Studios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudio(int id)
        {
            var studio = await _context.studios.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }

            _context.studios.Remove(studio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudioExists(int id)
        {
            return _context.studios.Any(e => e.Id == id);
        }
    }
}
