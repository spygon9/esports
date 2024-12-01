using esports.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esports.Api.Controllers
{
    [ApiController]
    [Route("/api/matches")]
    public class MatchesController: ControllerBase
    {
        private readonly DataContext dataContext;

        public MatchesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Matches.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var match = await dataContext.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Match match)
        {
            dataContext.Matches.Add(match);
            await dataContext.SaveChangesAsync();
            return Ok(match);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Match match)
        {
            dataContext.Matches.Update(match);
            await dataContext.SaveChangesAsync();
            return Ok(match);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Matches.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
