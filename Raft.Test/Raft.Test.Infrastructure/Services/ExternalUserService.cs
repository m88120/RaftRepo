using Raft.Test.Core;
using Raft.Test.Infrastructure.Clients;
using Raft.Test.Infrastructure.Mapping;
using Raft.Test.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raft.Test.Infrastructure.Services
{
	public class ExternalUserService : IExternalUserService
	{
		private readonly UserApiClient _client;

		public ExternalUserService(UserApiClient client)
		{
			_client = client;
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			var users = new List<User>();
			int page = 1;
			ApiUserResponse response;

			do
			{
				response = await _client.GetUsersAsync(page);
				users.AddRange(response.Data.Select(UserMapper.ToDomainUser));
				page++;
			} while (page <= response.Total_Pages);

			return users;
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			var dto = await _client.GetUserByIdAsync(id);
			if (dto == null)
				throw new Exception("User not found");

			return UserMapper.Map(dto);
		}


	}
}
