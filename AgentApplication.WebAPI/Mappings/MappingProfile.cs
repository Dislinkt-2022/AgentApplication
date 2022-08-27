using AgentApplication.WebAPI.Entitites.DTO;
using AgentApplication.WebAPI.Entitites.Model;
using AutoMapper;

namespace AgentApplication.WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
