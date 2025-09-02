@APGBRegression
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Scenario: SignInAndSignOut
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	And  click on signout button and verify the signout message

Scenario: SignInAndSignOutUsingOneLogIn
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I select sign in method 'OneLogIn'
	Then verify next page '<nextpage1>' is loaded
	When I click on Sign In on OneLogIn page
	When I have provided the One Login credentials '<LoginEmailAddress>', '<LoginPassword>'
	Then I should redirected to Apply for a pet travel document page
	And  click on signout button and verify the signout message

Examples:
	| nextpage1                               | LoginEmailAddress                     | LoginPassword |
	| Create your GOV.UK One Login or sign in | pallavi.yewale+28Second@capgemini.com | Test@12345    |
