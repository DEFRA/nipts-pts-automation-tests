﻿Feature: CP Signin and Sign out

As a PTS port checker I want ot login and logout from Checker Portal Application


#Background: 
#	Given I navigate to the port checker application
#	And I click signin button on port checker application
#	Then I should redirected to the Sign in using Government Gateway page
	
@CPRegression
Scenario: SignOut
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then click on signout button on CP and verify the signout message

@CrossBrowserCP
Scenario: CPE2ECrossBrowser
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
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
	And I click search by '<ApplicationRadio>' radio button
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
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger      | SPSOutcome | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 926C36    | Ferry foot passenger | Allowed    | Search by PTD number |

#Scenario: API check
#	When Create an application via backend

Scenario: Verify links on accessibility statement on sign in page
	Given I navigate to the port checker application
	Then I click on accessibility statement link
	When I have provided the password for prototype research page
	Then verify next page 'Accessibility statement for Check a pet travelling from GB to NI' is loaded
	Then verify the link on the accessibility statement page '<Accesibility Link 1>'
	Then verify the link on the accessibility statement page '<Accesibility Link 2>'
	Then verify the link on the accessibility statement page '<Accesibility Link 3>'
	Then verify the link on the accessibility statement page '<Accesibility Link 4>'
	Then verify the link on the accessibility statement page '<Accesibility Link 5>'
	Then verify the link on the accessibility statement page '<Accesibility Link 6>'
	
	 

Examples: 
     | Accesibility Link 1    | Accesibility Link 2								   | Accesibility Link 3						 | Accesibility Link 4									   | Accesibility Link 5			       | Accesibility Link 6     | 
     | AbilityNet			  |  contact the Equality Advisory and Support Service |  Equalities Commission for Northern Ireland | Public Sector Bodies (Websites and Mobile Applications) |  Web Content Accessibility Guidelines | NIPetTravel@apha.gov.uk | 

	