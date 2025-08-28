Feature: CP Signin and Sign out

As a PTS port checker I want ot login and logout from Checker Portal Application

@CPRegression
Scenario: SignOut
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I verify the header text 'Check a pet travelling from GB to NI'
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
	And I select Refer to SPS radio button
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
	When I click on Update referral outcome
	Then verify next page '<nextPage2>' is loaded
	And I click '<SPSOutcome>' on SPS outcome
	And I enter details of outcome '<DetailsOfOutCome>'
	And I click on Save on update referral
	Then I should navigate to Welcome page
	And I verify submiited message
    And I verify submiited message image
	And I verify the header text 'Check a pet travelling from GB to NI'
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger      | SPSOutcome | ApplicationRadio     | nextPage2               | DetailsOfOutCome     |
	| Ferry          | Birkenhead to Belfast (Stena) | 05A888    | Ferry foot passenger | Allowed    | Search by PTD number | Update referral outcome | Test outcome details |

#Scenario: API check
#	When Create an application via backend

@CPRegression
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

@CPRegression
Scenario: Verify sign in functionality on accessibility statement
	Given I navigate to the port checker application
	When I click on accessibility statement link
	And I have provided the password for prototype research page
	Then verify next page 'Accessibility statement for Check a pet travelling from GB to NI' is loaded
	And I click on Back button in Pets Application
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the CP credentials and signin
	Then verify next page 'What route are you checking' is loaded
	And I click on Back button in Pets Application
	Then click browser back
	And  click browser back
	When I click on accessibility statement link
	Then verify next page 'Accessibility statement for Check a pet travelling from GB to NI' is loaded

Examples: 
 | nextpage1														| nextpage2						 |
 | Accessibility statement for Check a pet travelling from GB to NI | What route are you checking    |

@CPRegression
Scenario: Verify Scan link on footer
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	And I verify scan link from footer
	Then click on signout button on CP and verify the signout message

Examples:
	| Transportation | FerryRoute                    |
	| Ferry          | Birkenhead to Belfast (Stena) |