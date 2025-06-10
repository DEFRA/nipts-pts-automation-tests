@CPRegression
Feature: CPManageAccount

Verify CP Manage Account page

Scenario Outline: Verify CP Manage Account page
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When I click Accont on Home Page
	Then verify next page '<nextPage>' is loaded

	Examples:
	| nextPage           |
	| Your Defra account |


Scenario Outline: Verify standard user role on manage account page
	Given I navigate to the port checker application
	When I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When I click Accont on Home Page
	Then verify role '<role>' on manage account page
	Then verify next page '<nextPage>' is loaded

	Examples:
	| nextPage           | role          |
	| Your Defra account | Standard user |


Scenario Outline: Verify admin role on manage account page
	Given I navigate to the port checker application
	When I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'AdminUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When I click Accont on Home Page
	Then verify role '<role>' on manage account page
	Then verify next page '<nextPage>' is loaded

	Examples:
	| nextPage           | role  |
	| Your Defra account | Admin |
