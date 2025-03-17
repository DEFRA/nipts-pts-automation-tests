@CPRegression
Feature: E2ESPSNegative

As a PTS port checker I want ot check E2E journey for SPS negative scenario

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend

Scenario Outline: Check SPS to GB PETS Travel Document details By PTD number - status in Approved
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	And I should see departure date and time is not matching with latest referred to SPS
Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | Search by PTD number |


Scenario Outline: Check SPS behaviour PETS Travel Document details By PTD number - status in Approved
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I provide the '<Flight number>' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	And I should see for Flights departure date and time is not matching with latest referred to SPS
Examples:
	| Transportation | Flight number | TypeOfPassenger | nextPage        | SPSOutcome  | ApplicationRadio     |
	| Flight         | AI 123        | Airline         | Referred to SPS | Not allowed | Search by PTD number |
