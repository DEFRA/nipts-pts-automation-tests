@CPRegression
Feature: Pets WAF rule validation

Validate WAF rule validation page

Scenario Outline: Verify validation page for WAF rule
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	Then I provide the invalid FlightNumber in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to the '<nextPage>' is loaded

Examples:
	| Transportation | nextPage                                           |
	| Flight         | You cannot access this page or perform this action |
