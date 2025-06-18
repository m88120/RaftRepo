# ReqRes Integration (.NET)
This solution demonstrates a clean architecture component that interacts with the public [ReqRes API](https://reqres.in), fetching and transforming user data

##  Project Structure

Raft.Test

  -  Raft.Test.Console/           # Entry point for running the application
  -  Raft.Test.Infrastructure/    # HttpClient, DTOs, Mappers, Services
  -  Raft.Test.Tests/             # Unit tests using xUnit + Moq
  -  appsettings.json             # Configuration file

## .NET SDK Compatibility Issue
  -  Verify .NET SDK is installed
 -  Run: dotnet --version
 -  Installed SDKs:
 -  8.0.101
 -  8.0.411

-  Update global.json to use an installed SDK version
{
  "sdk": {
    "version": "8.0.204"
  }
}
###  Prerequisites

 [.NET SDK 8.0+](https://dotnet.microsoft.com/enus/download)
 IDE: Visual Studio
###  Build the Project

bash
dotnet build


###  Run Tests

bash
dotnet test


###  Run Console Demo

bash
dotnet run project Raft.Test.Console


This fetches:

  -  All users from page 1
  -  A single user by ID



##  Configuration

appsettings.json is used to configure the ReqRes API base URL:

json
{
  "ReqResApi": {
    "BaseUrl": "https://reqres.in/api"
  }
}


Make sure this file exists in your root directory or the directory where the Console app is executed.



###  Dependency Injection

 -  All services are registered using Microsoft.Extensions.DependencyInjection.
 -  AddExternalUserIntegration() sets up HttpClient with the base URL.

###  Error Handling

 -  Custom exception ExternalApiException is thrown for nonsuccess status codes.
 -  Graceful handling of 404s and null deserialization results.

###  Testing Strategy

FakeHttpMessageHandler is used to mock HttpClient behavior.
  Test coverage for both:
  -  GetAllUsersAsync
  -  GetUserByIdAsync
