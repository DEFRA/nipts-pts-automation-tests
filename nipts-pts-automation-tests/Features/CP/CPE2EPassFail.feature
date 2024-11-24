@CPRegression
Feature: CP E2E Pass Fail

As a PTS port checker I want ot Change Route Checking Details from all pages

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario Outline: PTS port checker Pass application by PTD number - status in Approved
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I navigate to Find a document page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | E6361B    |

Scenario Outline: PTS port checker Fail application by PTD number - status in Awaiting verification
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber | 
	| Ferry          | Birkenhead to Belfast (Stena) | 63C668    |

Scenario Outline: PTS port checker Pass application by Reference number - status in Approved
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I navigate to Find a document page
	
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio             | 
	| Ferry          | Birkenhead to Belfast (Stena) | H0GLMCI3		   | Search by application number | 

Scenario Outline: PTS port checker Fail application by Reference number - status in Awaiting verification
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio             | 
	| Ferry          | Birkenhead to Belfast (Stena) | QRWD9DZA		   | Search by application number |


Scenario Outline: PTS port checker Pass application by Microchip number - status in Approved
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I navigate to Find a document page
	
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio           | 
	| Ferry          | Birkenhead to Belfast (Stena) | 123456789012345 | Search by microchip number | 

Scenario Outline: PTS port checker Fail application by Microchip number - status in Awaiting verification
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio           | 
	| Ferry          | Birkenhead to Belfast (Stena) | 091024125322600 | Search by microchip number | 