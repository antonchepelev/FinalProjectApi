using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectApi.Models;

[Route("api/[controller]")]
[ApiController]
public class FavoriteGamesController : ControllerBase
{
    private readonly FinalProjectApiContext _context;

    public FavoriteGamesController(FinalProjectApiContext context)
    {
        _context = context;
    }

    // GET: api/FavoriteGames  or  api/FavoriteGames/5
    [HttpGet]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<FavoriteGame>>> GetFavoriteGame(int? id)
    {
        if (id is null || id == 0)
        {
            return await _context.FavoriteGame
                .OrderBy(g => g.Id)
                .Take(5)
                .ToListAsync();
        }

        var favoriteGame = await _context.FavoriteGame.FindAsync(id);

        if (favoriteGame is null)
        {
            return NotFound();
        }

        return new List<FavoriteGame> { favoriteGame };
    }

    // POST: api/FavoriteGames
    [HttpPost]
    public async Task<ActionResult<FavoriteGame>> PostFavoriteGame(FavoriteGame favoriteGame)
    {
        _context.FavoriteGame.Add(favoriteGame);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFavoriteGame", new { id = favoriteGame.Id }, favoriteGame);
    }

    // PUT: api/FavoriteGames/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFavoriteGame(int id, FavoriteGame favoriteGame)
    {
        if (id != favoriteGame.Id)
        {
            return BadRequest();
        }

        _context.Entry(favoriteGame).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FavoriteGameExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/FavoriteGames/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFavoriteGame(int id)
    {
        var favoriteGame = await _context.FavoriteGame.FindAsync(id);
        if (favoriteGame is null)
        {
            return NotFound();
        }

        _context.FavoriteGame.Remove(favoriteGame);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FavoriteGameExists(int id)
    {
        return _context.FavoriteGame.Any(e => e.Id == id);
    }
}
