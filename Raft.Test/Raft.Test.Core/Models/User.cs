using System;

namespace Raft.Test.Core
{
    public class User
    {
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string AvatarUrl { get; set; } = string.Empty;
	}
}
