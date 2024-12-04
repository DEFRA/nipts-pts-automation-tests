@CPRegression
Feature: Report Non Compliance

As a PTS port checker I want ot Check application and Route Details

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Approved
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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Approved' on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | E6361B    |

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Pending
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
	And I should see the application status in 'Pending'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Pending' on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio           | 
	| Ferry          | Birkenhead to Belfast (Stena) | 091024125322600 | Search by microchip number | 

	Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Revoked
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Revoked'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Revoked' on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 671CA5    |
	
Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Unsuccessful
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Unsuccessful' on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 990AB2    |

Scenario Outline: PTS port checker Complete check on Report non-compliance page and navigate next page
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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click '<TypeOfPassenger>' in Passenger details
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger |
	| Ferry          | Birkenhead to Belfast (Stena) | E6361B    | Foot passenger  |
	| Ferry          | Birkenhead to Belfast (Stena) | E6361B    | Vehicle         |