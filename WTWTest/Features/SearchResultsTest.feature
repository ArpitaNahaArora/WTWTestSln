Feature: Test Search and Refine Functionality
	In order to validate search functionality of the website
	As a QA
	I want to search a string, sort, refine and output the results in HTML report

Background: Precondition - Open the WTW home page
	Given I have navigated to the WTW Home Page
	And I have accepted all cookies

@searchText @sortByDate @filter
Scenario: Search a string and sort and filter the results 
	Given I validate I am on the Global site 'GB | EN' 
	When I search for the word 'test' using the search box
	Then I should navigate to the result page
	And the results should be sorted by 'Date'
	And I filter the search by 'Transportation and Logistics'
	And the titles of all the result articles are displayed in output