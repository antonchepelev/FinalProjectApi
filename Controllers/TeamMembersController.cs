using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectApi.Models;

[Route("api/[controller]")]
[ApiController]
public class TeamMembersController : ControllerBase
{
    private readonly FinalProjectApiContext _context;
    public TeamMembersController(FinalProjectApiContext context)
    {
        _context = context;
    }

    // GET: api/TeamMembers  or  api/TeamMembers/5
    [HttpGet]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMember(int? id)
    {
        if (id is null || id == 0)
        {
            return await _context.TeamMember
                .OrderBy(t => t.Id)
                .Take(5)
                .ToListAsync();
        }

        var teamMember = await _context.TeamMember.FindAsync(id);

        if (teamMember is null)
        {
            return NotFound();
        }

        return new List<TeamMember> { teamMember };
    }

    // PUT: api/TeamMember/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeamMember(int? id, TeamMember teammember)
    {
        if (id != teammember.Id)
        {
            return BadRequest();
        }

        _context.Entry(teammember).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TeamMemberExists(id))
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

    // POST: api/TeamMember
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teammember)
    {
        _context.TeamMember.Add(teammember);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTeamMember", new { id = teammember.Id }, teammember);
    }

    // DELETE: api/TeamMember/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamMember(int? id)
    {
        var teammember = await _context.TeamMember.FindAsync(id);
        if (teammember == null)
        {
            return NotFound();
        }

        _context.TeamMember.Remove(teammember);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TeamMemberExists(int? id)
    {
        return _context.TeamMember.Any(e => e.Id == id);
    }
}
