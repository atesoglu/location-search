# Location Search API Proposal
This is a solution for processing large datasets of location data and dispatching events as notifications for every action taken in system.
It has APIs to be used publicly but the solution can offer authentication and token management in the future implementations.
It's extensible with the dispatcher mechanism that supports application events.

## Technologies
*  ASP.NET Core 5
*  Entity Framework Core 
*  FluentValidation
*  Serilog
*  xUnit, FluentAssertions, Bogus

## Getting Started
The easiest way to get started is to follow these instructions to get the project up and running:

### Prerequisites
You will need the following tools:
*  [JetBrains Rider](https://www.jetbrains.com/rider/) (version 2021.1.5 or later) or [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.10.4 or later)
*  [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

### Setup
Follow these steps to get your development environment set up:
1. Clone the repository  or unzip the archive file if you downloaded single file.
2. At the root directory, restore required packages by running:

```
dotnet restore
```

3. Next, build the solution by running:

```
dotnet build
```

4. Once the solution has been built, API can be started within the `\src\API` directory, by running:

```
dotnet run
```

6. Sample curl command can be used to test after running the API project:

```
    curl --location --request GET 'http://localhost:5000/health-checks'
```

Also, sample [Postman collection](Location-Search.postman_collection.json) is added to the solution.


## Overview
### Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application
This layer contains all application logic.
It is dependent on the domain layer (Domain) but has no dependencies on any other layer or project.
This layer defines interfaces that are implemented by outside layers.
For example; if the application need to access another service, a new interface would be added to application and an implementation would be created within the infrastructure.

### Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer.

### API
This layer is a web api application based on ASP.NET Core 5.
This layer depends on Infrastructure layer for concrete implementations and Application layer for contracts.