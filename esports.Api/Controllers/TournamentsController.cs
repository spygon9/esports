using esports.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esports.Api.Controllers
{
    [ApiController]
    [Route("/api/tournaments")]
    public class TournamentsController: ControllerBase
    {
        private readonly DataContext dataContext;

        public TournamentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Tournaments.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var tournament = await dataContext.Tournaments.FirstOrDefaultAsync(x => x.Id == id);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Tournament tournament)
        {
            dataContext.Tournaments.Add(tournament);
            await dataContext.SaveChangesAsync();
            return Ok(tournament);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Tournament tournament)
        {
            dataContext.Tournaments.Update(tournament);
            await dataContext.SaveChangesAsync();
            return Ok(tournament);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Tournaments.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
