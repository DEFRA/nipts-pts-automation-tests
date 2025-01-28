Feature: DatabaseUpdate

Delete data for Automation user

Background: 
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page

@DatabaseQuery
Scenario: Delete data for Automation user
	When Clear Database for user 'Test'
	Then click on signout button and verify the signout message on pets

