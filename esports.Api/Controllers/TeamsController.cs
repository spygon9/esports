using esports.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esports.Api.Controllers
{
    [ApiController]
    [Route("/api/teams")]
    public class TeamsController: ControllerBase
    {
        private readonly DataContext dataContext;

        public TeamsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Teams.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var team = await dataContext.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Team team)
        {
            dataContext.Teams.Add(team);
            await dataContext.SaveChangesAsync();
            return Ok(team);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Team team)
        {
            dataContext.Teams.Update(team);
            await dataContext.SaveChangesAsync();
            return Ok(team);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Teams.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
