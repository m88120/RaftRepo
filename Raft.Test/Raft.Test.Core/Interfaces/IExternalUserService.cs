using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raft.Test.Core
{
    public interface IExternalUserService
    {
		Task<User?> GetUserByIdAsync(int id);
		Task<List<User>> GetAllUsersAsync();
	}
}
