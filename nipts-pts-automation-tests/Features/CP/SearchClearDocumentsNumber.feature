@CPRegression
Feature: Search Clear Documents Number

As a PTS port checker I want ot Clear documents number from Find a document search box


Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

	
Scenario Outline: Port checker Clear documents number from PTD search box
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click clear search button
	And I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 12345     |

	Scenario Outline: Port checker Clear documents number from Application reference search box
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click clear search button
	Then I click search by '<ApplicationRadio>' radio button
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio			  |
	| Ferry          | Birkenhead to Belfast (Stena) | QRWD9DZ	       | Search by application number |

Scenario Outline: Port checker Clear documents number from Microchip search box
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click clear search button
	Then I click search by '<ApplicationRadio>' radio button
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber	| ApplicationRadio		     |
	| Ferry          | Birkenhead to Belfast (Stena) | 123456089012340  | Search by microchip number |