using System.Collections.Generic;

namespace Raft.Test.Infrastructure.Models
{
	public class ApiUserResponse
	{
		public int Page { get; set; }
		public int Per_Page { get; set; }
		public int Total { get; set; }
		public int Total_Pages { get; set; }
		public List<ApiUserDto> Data { get; set; } = new();
	}
	public class ApiUserResponseUserById
	{
		public ApiUserDto Data { get; set; }
	}
}
