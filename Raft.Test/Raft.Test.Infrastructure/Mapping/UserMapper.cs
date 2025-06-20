using Raft.Test.Core;
using Raft.Test.Infrastructure.Models;

namespace Raft.Test.Infrastructure.Mapping { 
	public class UserMapper {
		public static User ToDomainUser(ApiUserDto dto) => new User
		{
			Id = dto.Id,
			FirstName = dto.First_Name,
			LastName = dto.Last_Name,
			Email = dto.Email,
			AvatarUrl = dto.Avatar
		};

		public static User Map(ApiUserDto dto) => new User
		{
			Id = dto.Id,
			FirstName = dto.First_Name,
			LastName = dto.Last_Name,
			Email = dto.Email,
			AvatarUrl = dto.Avatar
		};
	}
}
