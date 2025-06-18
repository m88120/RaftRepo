using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Raft.Test.Tests
{
		public class FakeHttpMessageHandler : HttpMessageHandler
		{
			private HttpResponseMessage _fakeResponse;

			public FakeHttpMessageHandler(string content = "", HttpStatusCode statusCode = HttpStatusCode.OK)
			{
				_fakeResponse = new HttpResponseMessage
				{
					StatusCode = statusCode,
					Content = new StringContent(content)
				};
			}

			public void SetHttpResponse(string content, HttpStatusCode statusCode)
			{
				_fakeResponse = new HttpResponseMessage
				{
					StatusCode = statusCode,
					Content = new StringContent(content)
				};
			}

			protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			{
				return Task.FromResult(_fakeResponse);
			}
		}
	

}
