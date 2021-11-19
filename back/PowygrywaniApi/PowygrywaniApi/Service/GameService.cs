using PowygrywaniApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PowygrywaniApi.Service;
public class GameService
{
    private readonly ModelContext _context;
    public async Task<ActionResult<Game>>GetGameById(long id)
    {
        var game = await _context.games.FindAsync(id);

        if (game == null)
        {
            return new NotFoundResult();
        }
        return game;
    }
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    { 
        return await _context.games.ToListAsync();
    }

    public async Task<IActionResult> PutGame(long id, Game game)
    {
        if (id != game.Id)
        {
            return new BadRequestResult();
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
                return new NotFoundResult();
            }
            else
            {
                throw;
            }
        }

        return new NoContentResult();
    }
    public async Task<ActionResult<Game>> PostGame(Game game)
    {
        try
        {
            _context.games.Add(game);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetGamesById",
                "GamesController",
                new { id = game.Id },
                game);
        }
        catch(Exception)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    public async Task<IActionResult> DeleteGameById(long id)
    {
        var game = await _context.games.FindAsync(id);
        if (game == null)
        {
            return new NotFoundResult();
        }

        _context.games.Remove(game);
        await _context.SaveChangesAsync();

        return new NoContentResult();
    }

    private bool GameExists(long id)
    {
        return _context.games.Any(e => e.Id == id);
    }
}

