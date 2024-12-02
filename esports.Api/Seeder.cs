
using esports.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace esports.Api
{
    public class Seeder
    {
        private readonly DataContext dataContext;

        public Seeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckTeamsAsync();
            await CheckUsersAsync();
        }

        private async Task CheckTeamsAsync()
        {
            if (!dataContext.Teams.Any())
            {
                dataContext.Teams.Add(new Team { TeamName = "T1" });
                dataContext.Teams.Add(new Team { TeamName = "GenG" });
                dataContext.Teams.Add(new Team { TeamName = "FlyQuest" });
                dataContext.Teams.Add(new Team { TeamName = "Rainbow7" });
            }
        }

        private async Task CheckUsersAsync()
        {
            if(!dataContext.Users.Any())
            {
                var team = await dataContext.Teams.FirstOrDefaultAsync(x => x.TeamName == "T1");
                if (team != null)
                {
                    dataContext.Users.Add(new User { Username = "Faker", Team = team });
                    dataContext.Users.Add(new User { Username = "Oner", Team = team });
                    dataContext.Users.Add(new User { Username = "Zeus", Team = team });
                    dataContext.Users.Add(new User { Username = "Gumayusi", Team = team });
                    dataContext.Users.Add(new User { Username = "Keria", Team = team });
                }
            }
        }
    }
}
