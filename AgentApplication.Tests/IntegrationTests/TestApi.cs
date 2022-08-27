using FluentAssertions;
using System.Net;

namespace AgentApplication.Tests.IntegrationTests
{
    public class TestApi
    {
        private readonly HttpClient _httpClient;

        public TestApi()
        {
            var webAppFactory = new CustomWebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetAllowAnonymousTest_StatusCode200()
        {
            // arrange

            // act
            var response = await _httpClient.GetAsync(requestUri: "api/Test/AllowAnonymous");


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAdmin_ResponseForbidden()
        {
            // arrange

            // act
            var response = await _httpClient.GetAsync(requestUri: "api/Test/Administrator");


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }


    }
}
