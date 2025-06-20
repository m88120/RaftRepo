using System;
using System.Net;

namespace Raft.Test.Infrastructure.Exceptions
{
	public class ExternalApiException : Exception
	{
		public HttpStatusCode StatusCode { get; }

		public ExternalApiException(string message, HttpStatusCode statusCode)
			: base(message)
		{
			StatusCode = statusCode;
		}
	}
}
