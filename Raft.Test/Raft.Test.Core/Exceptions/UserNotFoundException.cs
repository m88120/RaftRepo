﻿using System;

namespace Raft.Test.Core
{
    public class UserNotFoundException : Exception
	{
		public UserNotFoundException(Guid userId)
			: base($"User with ID {userId} was not found.") { }

	}
}
