@APGBRegression
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Background: 
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page

Scenario: SignInAndSignOut
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	And  click on signout button and verify the signout message

