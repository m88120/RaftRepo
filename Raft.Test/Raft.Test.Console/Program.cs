using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Raft.Test.Infrastructure.Services;
using Raft.Test.Infrastructure.Extensions;
using Raft.Test.Infrastructure.Configuration;
using System;
using Raft.Test.Core;
using Microsoft.Extensions.Options;
using Raft.Test.Infrastructure.Clients;
using System.Net.Http;

var host = Host.CreateDefaultBuilder(args)
	.ConfigureAppConfiguration((context, config) =>
	{
		config.AddJsonFile("appsettings.json", optional: false);
	})
	.ConfigureServices((context, services) =>
	{
		services.Configure<ReqResApiOptions>(context.Configuration.GetSection("ReqResApi"));
		//services.AddHttpClientWithPolly<ExternalUserService>();
		services.AddScoped<IExternalUserService, ExternalUserService>();
		services.AddExternalUserIntegration();


	})
	.Build();

var userService = host.Services.GetRequiredService<IExternalUserService>();

Console.WriteLine("--- Fetching All Users ---");
var users = await userService.GetAllUsersAsync();
foreach (var user in users)
{
	Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}");
}

Console.WriteLine("--- Fetching Single User (ID = 2) ---");
var singleUser = await userService.GetUserByIdAsync(2);
Console.WriteLine($"{singleUser.Id}: {singleUser.FirstName} {singleUser.LastName}");
