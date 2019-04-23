using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Robot.Online.Store.Persistence;
using AutoMapper;
using Robot.Online.Store.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Robot.Online.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly RobotDbContext context;
        private readonly IMapper mapper;

        public RobotsController(RobotDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Robots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RobotDto>>> GetRobots()
        {
            var robots = await context.Robots.ToListAsync();
            return mapper.Map<List<Models.Robot>, List<RobotDto>>(robots);
        }


        // POST: api/Robots
        [HttpPost]
        public async Task<ActionResult<RobotDto>> PostRobot(RobotDto robot)
        {
            /* 
             * With inMemoryDb EF can't set the right Id to the model when saving
             * so we load the lastest robot based on id order and i manually increment the id
             */

            var lastRobot = await context.Robots.OrderByDescending(r => r.Id).FirstOrDefaultAsync();
            var robotModel = mapper.Map<RobotDto, Models.Robot>(robot);

            robotModel.Id = (lastRobot.Id + 1);
            context.Robots.Add(robotModel);
            await context.SaveChangesAsync();

            return mapper.Map<Models.Robot, RobotDto>(robotModel);
        }

        // DELETE: api/Robots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RobotDto>> DeleteRobot(int id)
        {
            var robot = await context.Robots.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }

            context.Robots.Remove(robot);
            await context.SaveChangesAsync();

            return mapper.Map<Models.Robot, RobotDto>(robot);
        }
    }
}
