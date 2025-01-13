Feature: CP Signin and Sign out

As a PTS port checker I want ot login and logout from Checker Portal Application


Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	
@CPRegression
Scenario: SignOut
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then click on signout button on CP and verify the signout message

@RunOnly
Scenario: CPE2ECrossBrowser
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then click on signout button on CP and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	When I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time with SPS user
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	When I click on PTD '<PTDNumber>' of the application
	When I click on Conduct an SPS check
	Then I should see the application status in 'Approved'
	When I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger      | SPSOutcome |
	| Ferry          | Birkenhead to Belfast (Stena) | 7BDE08    | Ferry foot passenger | Allowed    |

#Scenario: Database check
#	When Clear Database for user 'Test'
