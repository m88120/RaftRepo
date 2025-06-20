using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Raft.Test.Core;
using Raft.Test.Infrastructure.Clients;
using Raft.Test.Infrastructure.Configuration;
using Raft.Test.Infrastructure.Services;
using System;
using System.Net.Http;

namespace Raft.Test.Infrastructure.Extensions
{
	public static class HttpClientBuilderExtensions
	{
		public static IServiceCollection AddExternalUserIntegration(this IServiceCollection services)
		{
			services.Configure<ReqResApiOptions>(
				options => options.BaseUrl = "https://reqres.in"); // Or use IConfiguration binding

			services.AddHttpClient<UserApiClient>()
				.SetHandlerLifetime(TimeSpan.FromMinutes(5))
				.AddPolicyHandler(GetRetryPolicy());

			services.AddScoped<IExternalUserService, ExternalUserService>();

			return services;
		}

		private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
		{
			return HttpPolicyExtensions
				.HandleTransientHttpError()
				.WaitAndRetryAsync(
					retryCount: 3,
					sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt))
				);
		}
	}
}

