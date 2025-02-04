@CPRegression
Feature: VerifyReferredToSPS

Validate Referred to SPS page

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
	When Approve an application via backend

Scenario Outline: Validate pagination on Referred to SPS page
	When I have selected '<Transportation>' radio option
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
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	Then I verify referred to SPS record count '10' on page
	When I click on page '2'
	Then I verify referred to SPS record count '1' on page
	When I click on page '1'
	Then I verify referred to SPS record count '10' on page

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS |
