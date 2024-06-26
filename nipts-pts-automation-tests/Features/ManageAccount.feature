@Regression
Feature: ManageAccount

Sign in to Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

Scenario: Navigate to Manage account on Pets Application Portal Page
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage1>' is loaded
	Then  I should navigate to Manage account
	Then  verify next page '<nextPage2>' is loaded
	Then  I click on Manage your account
	Then  verify next page '<nextPage3>' is loaded

	Examples: 
	| nextPage                         | logininfo | nextPage2					| nextPage3			| nextPage1						 |
	| Sign in using Government Gateway | test      | Manage your Defra account  | Your Defra account| Lifelong pet travel documents  |


Scenario: View Pets travel documents from Manage your accounts page
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage1>' is loaded
	Then  I should navigate to Manage account
	Then  verify next page '<nextPage2>' is loaded
	Then  click on View your pet travel documents or apply new one
	Then  verify next page '<nextPage1>' is loaded

Examples: 
	| nextPage                         | logininfo | nextPage1                     | nextPage2                 |
	| Sign in using Government Gateway | test      | Lifelong pet travel documents | Manage your Defra account |