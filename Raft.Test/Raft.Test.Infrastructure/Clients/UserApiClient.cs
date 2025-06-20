using Microsoft.Extensions.Options;
using Raft.Test.Infrastructure.Configuration;
using Raft.Test.Infrastructure.Exceptions;
using Raft.Test.Infrastructure.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Net;

namespace Raft.Test.Infrastructure.Clients {
	public class UserApiClient
	{
		private readonly HttpClient _httpClient;

		public UserApiClient(HttpClient httpClient, IOptions<ReqResApiOptions> options)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
		}

		public async Task<ApiUserResponse> GetUsersAsync(int page)
		{
			var response = await _httpClient.GetAsync($"/api/users?page={page}");

			if (!response.IsSuccessStatusCode)
				throw new ExternalApiException("Failed to fetch users", response.StatusCode);

			var result = await response.Content.ReadFromJsonAsync<ApiUserResponse>();
			return result ?? new ApiUserResponse();
		}
		public async Task<ApiUserDto?> GetUserByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"/api/users/{id}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null; // Or throw a custom NotFound exception if you prefer

			if (!response.IsSuccessStatusCode)
				throw new ExternalApiException("Failed to fetch user", response.StatusCode);

			var wrapper = await response.Content.ReadFromJsonAsync<ApiUserResponseUserById>();
			return wrapper?.Data;
		}

	}
}
