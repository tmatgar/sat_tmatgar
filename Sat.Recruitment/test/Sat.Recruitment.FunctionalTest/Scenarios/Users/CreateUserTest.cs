using FluentAssertions;
using Newtonsoft.Json;
using Sat.Recruitment.Application.Business.Users;
using Sat.Recruitment.Application.Business.Users.Responses;
using Sat.Recruitment.FunctionalTest.Extensions;
using Sat.Recruitment.FunctionalTest.Fixtures;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.FunctionalTest.Scenarios.Products
{
    [Collection(TestConstants.SatRecruitmentCollection)]
    public class CreateUserTest
    {
        private readonly HostFixture _host;

        public CreateUserTest(HostFixture host)
        {
            _host = host;
        }

        [Fact]
        public async Task ReturnCreated()
        {          
            var request = new CreateUserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };
           
            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(UrlBuilder.UsersUrl.PostCreateUserTestUrl, request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var data = await response.Content.ReadAsStringAsync();
            var createUserResponse = JsonConvert.DeserializeObject<CreateUserResponse>(data);
            Assert.True(createUserResponse.IsSuccess);
            Assert.Equal("User created", createUserResponse.Message);
        }

        [Fact]
        public async Task ReturnDuplicated()
        {
            var request = new CreateUserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(UrlBuilder.UsersUrl.PostCreateUserTestUrl, request);

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}