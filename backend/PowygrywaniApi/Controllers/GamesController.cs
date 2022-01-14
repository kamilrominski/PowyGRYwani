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
    public class GamesController : ControllerBase
    {
        private readonly ModelContext _context;

        public GamesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Getgames()
        {
            return await _context.games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET: api/Games/Studio/id
        [HttpGet("Studio/{id}")]
        public async Task<ActionResult<List<Game>>> GetGameByStudioId(int id)
        {
            var userList = _context.games.Where(x => x.Studio_id == id).ToList();

            if (userList.Count == 0)
            {
                return NotFound();
            }

            return userList;
        }

        // GET: api/Games/Series/id
        [HttpGet("Series/{id}")]
        public async Task<ActionResult<List<Game>>> GetGamesBySeriesId(int id)
        {
            var userList = _context.games.Where(x => x.Series_id == id).ToList();

            if(userList.Count == 0)
            {
                return NotFound();
            }
            return userList;
        }

        private bool GameExists(int id)
        {
            return _context.games.Any(e => e.Id == id);
        }
    }
}
