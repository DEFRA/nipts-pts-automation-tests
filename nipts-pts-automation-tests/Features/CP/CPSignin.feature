@CPRegression
Feature: CP Signin and Sign out

As a PTS port checker I want ot login and logout from Checker Portal Application


Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	

Scenario: SignIn
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario: SignOut
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then click on signout button on CP and verify the signout message