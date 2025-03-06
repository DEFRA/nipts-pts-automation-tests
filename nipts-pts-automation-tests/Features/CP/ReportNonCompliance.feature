@CPRegression
Feature: Report Non Compliance

As a PTS port checker I want ot Check application Report non compliance page

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Approved
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Approved' on Report non-compliance page
	And I Verify PTD number on Report non-compliance page
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message 'Select the type of passenger' in Report non-compliance page

Examples:
	| Transportation | FerryRoute                    | 
	| Ferry          | Birkenhead to Belfast (Stena) |

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Pending
	When I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Pending'
	And click on continue
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Pending' on Report non-compliance page
	And I Verify Application Reference number on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             | 
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number | 

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Revoked
	When Revoke an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Cancelled' on Report non-compliance page

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number |

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Unsuccessful
	When Reject an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Unsuccessful' on Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    |ApplicationRadio             |
	| Ferry          | Birkenhead to Belfast (Stena) |Search by application number | 


Scenario: Verify error messages for microchip number field on Report Non- Compliance page
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And  select Michrochip does not match the PTD checkbox
	And  I click '<PassengerType>' in Passenger details
	And  I click on GB outcome
	And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
	When click on Save outcome
	Then I should see an error message '<ErrorMsg>' in Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType | MichrochipNumber | ErrorMsg                            |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |                  | Enter the 15-digit microchip number |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |   11233          |  Enter the 15-digit microchip number, using only numbers                                   |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |   123@           |  Enter the 15-digit microchip number, using only numbers                                   |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |   wwqw           |  Enter the 15-digit microchip number, using only numbers                                   |

Scenario: Verify hint text and GB,SPS outcome error messages on Report Non- Compliance page
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And  verify hint text 'Any relevant comments' for Other reason
	#And  verify hint text 'For GB staff to fill in' for GB outcome
	#And  verify hint text 'For NI staff to fill in' for NI outcome
	When click on Save outcome
	Then I should see an error message 'Select at least one GB outcome' in Report non-compliance page
	#When I click 'Allowed to travel under Windsor Framework' on SPS outcome
	#And  click on Save outcome
	#Then I should see an error message 'You cannot select an SPS outcome' in Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType | MichrochipNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |                  |
	