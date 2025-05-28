@CPRegression
Feature: CPOutageScreens

Verify CP Outage pages

Scenario Outline: Verify CP 403 Outage page
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then verify heading '<Heading1>' on page
	And verify heading '<Heading2>' on page
	And verify text '<text1>' on page

	Examples:
	| Heading1                                           | Heading2                             | OutageLink                   | text1                                      | 
	| You cannot access this page or perform this action | Check a pet travelling from GB to NI | go back to the previous page | Contact your team leader with any queries. | 

Scenario Outline: Verify CP 404 Outage page
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When I force to load the 404 error page
	Then verify heading '<Heading1>' on page
	And verify heading '<Heading2>' on page
	And verify text '<text1>' on page
	And verify text '<text2>' on page
	And verify text '<text3>' on page
	And verify Account and SignOut links not visible on page

	Examples:
	| Heading1       | Heading2                             | text1                                              | text2                                                               | text3                                                                                     |
	| Page not found | Check a pet travelling from GB to NI | If you typed the web address, check it is correct. | If you pasted the web address, check you copied the entire address. | If the web address is correct or you selected a link or button, contact your team leader. |