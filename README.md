# WTW Test #

Test the Search Functionality on the WTW Website

### Setup ###

* Framework - netcoreapp3.1
* Test Runner - NUnit
* Test Bindings - Specflow
* UI Automation Framework - Selennium
* Reporting Framework Library - Extent Report

**How To Setup**
* Build the solution from Visual Studio
* This will install all the required Nuget packages

### How to run all tests ###

* From Visual Studio - Run all tests from Test Explorer
* From console - dotnet test  WTWTest.sln

### How to run selected scenarios ###

* Selected tests can be run using Traits from Visual Studio
* From console - dotnet test  WTWTest.sln --filter TestCategory={TagName}

### Adding tests ###
The tests are written using Specflow and Selenium. Page Object Model is used and the and the step definitions are also organised by the pages. NUnit is used as Test Runner. 

### Test Execution and Reporting ###

* Test Execution produce HTML Reports saved in Solution Folder. 
* The HTML Report contains: 

| Tab Name	| Details										|
|:-------	|:----------------------------------------------|
| Dashboard	| Test Run Status								|
|			| Chrome Browser Version						|
|			| Test Start and End Time						|
| Tests		| Display Output (For the purpose of this test) |
|			| Output Screenshot								|

### How to navigate through Extent Reports ###

* Open the HTML report 'dashboard.html' from the reports folder at WTWTestSln/ResultsReport**.
* Navigate through the tabs on the left hand panel. 
* In the Tests tab, click on the feature name to drill down to the steps within the scenario. 
* This screen will also show the step logs, results output displayed just for the purpose of this test and the results screenshot.
* In case a step fails, this screen will show the error logs and the screenshot of the screen where the step failed.