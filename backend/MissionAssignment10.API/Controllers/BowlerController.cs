using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionAssignment10.API.Models;
using MissionAssignment10.API.Data;

namespace MissionAssignment10.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BowlersController : ControllerBase
{
    private readonly BowlerDbContext _context;

    public BowlersController(BowlerDbContext context)
    {
        _context = context;
    }

[HttpGet]
public IActionResult GetBowlers()
{
    var bowlers = _context.Bowlers
        .Include(b => b.Team)
        .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
        .ToList();

    return Ok(bowlers);
}

}
