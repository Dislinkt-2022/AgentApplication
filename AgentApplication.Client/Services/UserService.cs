using AgentApplication.Client.Model.DTO;
using AgentApplication.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace AgentApplication.Client.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("apiClient");
        }

        public async Task<bool> SignInAsync(SignInDTO signInDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Users/SignIn", signInDTO);
                if (!response.IsSuccessStatusCode)
                    return false;

                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Users/Register", registerDTO);
                if (!response.IsSuccessStatusCode)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
