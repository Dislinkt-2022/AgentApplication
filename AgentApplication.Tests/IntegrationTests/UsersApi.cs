using AgentApplication.WebAPI.Entitites.DTO;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace AgentApplication.Tests.IntegrationTests
{
    public class UsersApi
    {
        private readonly HttpClient _httpClient;

        public UsersApi()
        {
            var webAppFactory = new CustomWebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task SingInAdmin_ResponseOk()
        {
            // arrange
            await _httpClient.PostAsync(requestUri: "api/Users/RegisterAdmin", null);
            var dto = new SignInDTO { UserName = "admin", Password = "adminpass" };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/SignIn", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task SingInUser_ResponseBadRequest()
        {
            // arrange
            var dto = new SignInDTO { UserName = "user", Password = "wrongpass" };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/SignIn", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
