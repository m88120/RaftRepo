using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Xunit;
using Raft.Test.Infrastructure.Clients;
using Raft.Test.Infrastructure.Configuration;
using Raft.Test.Infrastructure.Models;
using Raft.Test.Infrastructure.Services;
using Raft.Test.Tests;
using Raft.Test.Tests.TestData;



namespace Raft.Test.Tests
{

	public class ExternalUserServiceTests
	{
		private readonly ReqResApiOptions _options;

		public ExternalUserServiceTests()
		{
			_options = new ReqResApiOptions
			{
				BaseUrl = "https://reqres.in/api"
			};
		}

		[Fact]
		public async Task GetAllUsersAsync_ReturnsExpectedCount()
		{
			// Arrange
			var handler = new FakeHttpMessageHandler(UserApiResponseMocks.GetUsersJson(), HttpStatusCode.OK);
			var httpClient = new HttpClient(handler) { BaseAddress = new System.Uri(_options.BaseUrl) };

			var userApiClient = new UserApiClient(httpClient, Options.Create(_options));
			var service = new ExternalUserService(userApiClient);

			// Act
			var result = await service.GetAllUsersAsync();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(2, result.Count);
		}

		[Fact]
		public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
		{
			// Arrange
			var userId = 1;
			var handler = new FakeHttpMessageHandler(UserApiResponseMocks.GetUserByIdJson(userId), HttpStatusCode.OK);
			var httpClient = new HttpClient(handler) { BaseAddress = new System.Uri(_options.BaseUrl) };

			var userApiClient = new UserApiClient(httpClient, Options.Create(_options));
			var service = new ExternalUserService(userApiClient);

			// Act
			var result = await service.GetUserByIdAsync(userId);

			// Assert
			Assert.NotNull(result);
			Assert.Equal("George", result.FirstName);
			Assert.Equal("Bluth", result.LastName);
		}
	}
}


