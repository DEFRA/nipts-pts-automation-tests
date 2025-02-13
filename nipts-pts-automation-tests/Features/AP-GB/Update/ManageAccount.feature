@APGBRegression 
Feature: ManageAccount

Background: 
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page

Scenario: Change Phone Number in Manage account
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I enter updated Phone number
	And I click Continue
	And I click on Back button
	When that I navigate to the DEFRA application
	And I click Create a new pet travel document button
	Then I verify the updated Phone number
	And click on signout button and verify the signout message on pets

Scenario: Change Name in Manage account
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I enter updated First Name
	And I enter updated Last Name
	And I click Continue
	And I click on Back button
	When that I navigate to the DEFRA application
	And I click Create a new pet travel document button
	Then I verify the updated Pet Owner Name
	And I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I revert the Pet Owner Name to the Original Name
	And click on signout button and verify the signout message on pets

@ignore
Scenario Outline: Change Address in Manage account
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Address link
	And I click on Search for my address by UK Postcode link
	And I enter the valid <postcode> Postcode
	And I click find address button
	And I select the address
	And I click Continue
	And I click on Back button
	When that I navigate to the DEFRA application
	And I click Create a new pet travel document button
	Then I verify the updated Pet Owner Address
	And click on signout button and verify the signout message on pets
	
Examples:
	| postcode         |
	| CV1 4PY,RG1 3JN  |
