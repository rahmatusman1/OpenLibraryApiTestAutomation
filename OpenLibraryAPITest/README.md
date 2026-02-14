# Open Library API Automation Framework

# Framework Dependencies
.NET 8
Reqnroll (BDD)
RestSharp
FluentAssertions
NUnit


## Run
1. Open `ApiTests.sln` in Visual Studio.
2. Run from Test Explorer or CLI:
   ```bash
   dotnet test 
   ```

## Framework Design
- Features folder for test cases with steps using BDD Gherkin syntax
- Step Definitions folder for test binded to features and the attributes use `using Reqnroll
- FluentAssertions for readable assertions
- Response time measured using Stopwatch
- StoredImage Folders for Image comparison and validation
- Support folder stored reusable helpers
- Preferred config is `reqnroll.json` (schema included).
