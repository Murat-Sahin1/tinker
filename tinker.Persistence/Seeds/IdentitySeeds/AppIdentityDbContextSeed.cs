using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using tinker.Domain.Entities;
using tinker.Domain.Entities.Identity;

namespace tinker.Persistence.Seeds.IdentitySeeds
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address 
                    { 
                        FirstName = "Bob",
                        LastName = "Bobba",
                        Title = "Home",
                        City = "Los Angeles",
                        Description = "5th Avenue 10th Street, Jupiter",
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
