using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new WebAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<WebAppContext>>()))
        {
            if (context == null || context.Character == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Character.Any())
            {
                return;   // DB has been seeded
            }

            context.Character.AddRange(
                new Character
                {
                    Id = 1,
                    LocationId = 0,
                    Name = "Rick",
                    Status = "Alive"
                },
                new Character
                {
                    Id = 2,
                    LocationId = 0,
                    Name = "Morty",
                    Status = "Alive"
                },
                new Character
                {
                    Id = 3,
                    LocationId = 1,
                    Name = "Prime Rick",
                    Status = "Dead"
                }

            );
            context.SaveChanges();
        }

        using (var context = new WebAppContext(
    serviceProvider.GetRequiredService<
        DbContextOptions<WebAppContext>>()))
        {
            if (context == null || context.Locations == null)
            {
                throw new ArgumentNullException("Null ");
            }

            // Look for any movies.
            if (context.Locations.Any())
            {
                return;   // DB has been seeded
            }

            context.Locations.AddRange(
                new Location
                {
                    Id = 0,
                    Name = "Earth"
                },
                new Location
                {
                    Id = 1,
                    Name = "Counter-Earth"
                }

            );
            context.SaveChanges();
        }

    }
}