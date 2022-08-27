using AgentApplication.WebAPI.Entitites.DTO;
using AgentApplication.WebAPI.Entitites.Model;

namespace AgentApplication.WebAPI.Services.Interfaces
{
    public interface ITokenCreationService
    {
        public TokenDTO CreateToken(User user);
    }
}
