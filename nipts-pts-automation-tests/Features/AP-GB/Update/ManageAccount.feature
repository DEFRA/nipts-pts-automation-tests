@ChangeDetails @APGBRegression 
Feature: ManageAccount

Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

Scenario: Change Phone Number in Manage account
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I enter updated Phone number
	And I click Continue
	And I click on Back button
	And I go back to Pets application
	When I click Create a new pet travel document button
	Then I verify the updated Phone number

Scenario: Change Name in Manage account
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I enter updated First Name
	And I enter updated Last Name
	And I click Continue
	And I click on Back button
	And I go back to Pets application
	When I click Create a new pet travel document button
	Then I verify the updated Pet Owner Name
	And I should navigate to Manage account
	And I click on Manage your account
	And I click on Update Details link
	And I click on Change Personal Information link
	And I revert the Pet Owner Name to the Original Name

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
	And I go back to Pets application
	When I click Create a new pet travel document button
	Then I verify the updated Pet Owner Address
	
Examples:
	| postcode         |
	| CV1 4PY,RG1 3JN  |
