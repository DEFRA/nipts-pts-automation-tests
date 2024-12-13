@APGBRegression @SmokeTest @Common @PETS
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page

Scenario: SignIn
	Then sign in with valid credentials with logininfo

@CrossBrowser3
Scenario: SignOut
	Then sign in with valid credentials with logininfo
	And  click on signout button and verify the signout message

