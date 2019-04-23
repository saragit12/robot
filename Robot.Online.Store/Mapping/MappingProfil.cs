using AutoMapper;
using Robot.Online.Store.Dto;

namespace Robot.Online.Store.Mapping
{
    public class MappingProfil : Profile
    {
        public MappingProfil()
        {
            CreateMap<Models.Robot, RobotDto>();
            CreateMap<RobotDto, Models.Robot>().ForMember(r => r.Id, id => id.Ignore());
        }
    }
}
