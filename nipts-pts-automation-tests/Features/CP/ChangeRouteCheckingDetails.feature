@CPRegression
Feature: Change Route Checking Details

As a PTS port checker I want ot Change Route Checking Details from all pages

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario Outline: Port checker Change Route Checking Details from Welcome page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	And I click change link from headers
	And I should redirected to port route checke page

Examples:
	| Transportation | FerryRoute				|
	| Ferry  	     | Cairnryan to Larne (P&O) |

Scenario Outline: Port checker Change Route Checking Details from Search page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click change link from headers
	And I should redirected to port route checke page

Examples:
	| Transportation | FerryRoute				|
	| Ferry  	     | Cairnryan to Larne (P&O) |

Scenario Outline: Port checker Change Route Checking Details from Search results page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I click change link from headers
	And I should redirected to port route checke page

Examples:
	| Transportation | FerryRoute                    | MicrochipNumber	| ApplicationRadio		     |
	| Ferry          | Birkenhead to Belfast (Stena) | 123456789012345  | Search by microchip number |

Scenario Outline: Port checker navigate to Welcome page by clicking footer home icon
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	And I click search button from footer
	Then I navigate to Find a document page
	When I click footer home icon
	Then I should navigate to Welcome page

Examples:
	| Transportation | FerryRoute				|
	| Ferry  	     | Cairnryan to Larne (P&O) |