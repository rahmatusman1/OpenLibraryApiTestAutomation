# Open Library API Automation Framework

# Framework Dependencies Used
.NET 8
Reqnroll (BDD)
RestSharp
FluentAssertions
NUnit


## Test SetUp 
1. Installed Visual Studio or Open existing if already installed.
2. Create a folder on your local 
3. Clone the code from the repository into your created local folder 
4. Go to the File directory 
5. Open `ApiTests.sln` in Visual Studio.

## Test Run
- Run from Test Explorer or CLI:
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
