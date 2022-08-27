using AgentApplication.WebAPI.Entitites.DTO;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace AgentApplication.Tests.IntegrationTests
{//
    public class UsersApi
    {
        private readonly HttpClient _httpClient;

        public UsersApi()
        {
            var webAppFactory = new CustomWebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }
        /*
        [Fact]
        public async Task RegisterUser_ResponseOk()
        {
            var dto = new UserDTO
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "jhonsmith@gmai.com",
                Password = "strongpass",
                ConfirmPassword = "strongpass",
                UserName = "user"
            };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/Register", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RegisterUser_UnmatchedPawwrods_ResponseBadRequest()
        {
            // arrange
            var dto = new UserDTO
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "jhonsmith@gmai.com",
                Password = "strongpass",
                ConfirmPassword = "strongpas",
                UserName = "user"
            };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/Register", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task RegisterUser_UsernameTaken_ResponseBadRequest()
        {
            // arrange
            var dto = new UserDTO
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "jhonsmith@gmai.com",
                Password = "strongpass",
                ConfirmPassword = "strongpass",
                UserName = "admin"
            };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/Register", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SingInAdmin_ResponseOk()
        {
            // arrange
            var dto = new SignInDTO { UserName = "admin", Password = "adminpass" };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/SignIn", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task SingInAdmin_ResponseBadRequest()
        {
            // arrange
            var dto = new SignInDTO { UserName = "admin", Password = "pass" };

            // act
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/Users/SignIn", dto);


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SingInUser_ResponseOk()
        {
            // arrange
            var dto = new SignInDTO { UserName = "user", Password = "strongpass" };

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
        }*/
    }
}
