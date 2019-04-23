using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot.Online.Store.Persistence
{
    public class RobotDbContext : DbContext
    {
        public RobotDbContext(DbContextOptions<RobotDbContext> options)
            :base(options)
        {
        }

        // With inMemoryDb EF can't set the right Id to the model when saving

        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    model.Entity<Models.Robot>()
        //        .Property(r => r.Id)
        //        .ValueGeneratedOnAdd();

        //    base.OnModelCreating(model);
        //}

        public DbSet<Models.Robot> Robots { get; set; }

    }
}
