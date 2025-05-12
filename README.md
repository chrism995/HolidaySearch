**HolidaySearch**
A .NET solution for searching and managing holiday packages.

**Project Overview**
HolidaySearch is a solution built with .NET 8.0 that provides functionality for searching and managing holiday packages. The core logic is contained in the HolidaySearch.Core project, with comprehensive unit tests in the HolidaySearch.Tests project.

**Prerequisites**
.NET 8.0 SDK
Visual Studio 2022 or later (recommended) or Visual Studio Code
Solution Structure
The solution contains the following projects:

**HolidaySearch.Core** - The main library containing the core functionality
**HolidaySearch.Tests** - The test project with NUnit tests
Getting Started
Clone the Repository

git clone https://github.com/yourusername/HolidaySearch.git
cd HolidaySearch

**Build the Solution**
- dotnet build
**Run the Tests**
- dotnet test
Testing
The test project uses:

NUnit 3.14.0 - Testing framework
Moq 4.20.72 - Mocking framework
NUnit3TestAdapter 4.5.0 - Adapter for running NUnit tests in Visual Studio
coverlet.collector 6.0.0 - Code coverage tool

**Dependencies**
.NET 8.0
NUnit 3.14.0 (Test project)
Moq 4.20.72 (Test project)
NUnit.Analyzers 3.9.0 (Test project)
Microsoft.NET.Test.Sdk 17.8.0 (Test project)
