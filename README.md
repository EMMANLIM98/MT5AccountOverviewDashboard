# MT5 Account Overview Dashboard Task (ASP.NET MVC)

An ASP.Net MVC web application for viewing MT5 account overviews and trade details. Built with ASP.NET Core (.NET 9).



## Getting Started

## Project Structure

- `MT5AccountOverviewDashboardTask/`  
  Main ASP.Net MVC project.
- `MT5AccountOverviewDashboardTask.Tests/`  
  Unit and integration tests.

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later

### Build and Run

- Run these commands in terminal: 
	- dotnet build MT5AccountOverviewDashboardTask
	- dotnet run --project MT5AccountOverviewDashboardTask

- The app will be available at `https://localhost:5001` by default. Also check the terminal for what port it is running on.

### Running Tests

- dotnet test MT5AccountOverviewDashboardTask.Tests

## Dependencies

- ASP.NET MVC (.NET 9)
- Moq (4.20.72)
- xUnit (2.9.2)
- xunit.runner.visualstudio (3.1.4)

## Features
- Dashboard view showing account info and trades
- Mock API data from JSON files
- Clean architecture (MVC + Services)
- Error handling for empty/failed API
- Unit tests with xUnit

## Setup
1. Clone repo: (https://github.com/EMMANLIM98/MT5AccountOverviewDashboard)
2. Run `dotnet restore`
3. Run `dotnet run`
4. The app will be available at `https://localhost:5001` by default. Also check the terminal for what port it is running on.

## Assumptions
- Mock JSON simulates API responses
- AccountId is hardcoded (12345)
- No authentication implemented
- When implementing real API, replace mock service with actual HTTP calls, uncomment line 10 - 13 in Program.cs then comment line 7 and adjust the api endpoints accordingly.
