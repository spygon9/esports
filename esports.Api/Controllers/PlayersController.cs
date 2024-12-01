using esports.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esports.Api.Controllers
{
    [ApiController]
    [Route("/api/players")]
    public class PlayersController: ControllerBase
    {
        private readonly DataContext dataContext;

        public PlayersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Players.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var player = await dataContext.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Player player)
        {
            dataContext.Players.Add(player);
            await dataContext.SaveChangesAsync();
            return Ok(player);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Player player)
        {
            dataContext.Players.Update(player);
            await dataContext.SaveChangesAsync();
            return Ok(player);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Players.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
