using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot.Online.Store.Persistence
{
    public class RobotDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RobotDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RobotDbContext>>()))
            {
                // Look for any Robot.
                if (context.Robots.Any())
                {
                    return;   // Data was already seeded
                }

                context.Robots.AddRange(
                    new Models.Robot
                    {
                        Id = 1,
                        Name = "Wall-E",
                        Description = "Wall-E description robot",
                        IsAvailable = true
                    },
                    new Models.Robot
                    {
                        Id = 2,
                        Name = "Sojourner",
                        Description = "Sojourner description robot",
                        IsAvailable = false
                    },
                    new Models.Robot
                    {
                        Id = 3,
                        Name = "ASIMO",
                        Description = "ASIMO description robot",
                        IsAvailable = true
                    },
                    new Models.Robot
                    {
                        Id = 4,
                        Name = "Astro Boy",
                        Description = "Astro Boy description robot",
                        IsAvailable = false
                    },
                    new Models.Robot
                    {
                        Id = 5,
                        Name = "Optimus Prime (Transformers)",
                        Description = "Optimus Prime (Transformers) description robot",
                        IsAvailable = true
                    },
                    new Models.Robot
                    {
                        Id = 6,
                        Name = "The Energizer Bunny",
                        Description = "The Energizer Bunny description robot",
                        IsAvailable = false
                    }) ;

                context.SaveChanges();
            }
        }
    }
}
