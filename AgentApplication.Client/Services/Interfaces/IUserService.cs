using AgentApplication.Client.Model.DTO;

namespace AgentApplication.Client.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> SignInAsync(SignInDTO signInDTO);
        public Task<bool> RegisterAsync(RegisterDTO registerDTO);
    }
}
