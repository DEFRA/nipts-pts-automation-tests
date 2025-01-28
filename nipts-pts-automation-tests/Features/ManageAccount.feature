@Regression
Feature: ManageAccount

Manage Account page in Pets application Portal
	

Scenario: Navigate to Manage account on Pets Application Portal Page
    Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage1>' is loaded
	And   I should navigate to Manage account
	And  verify next page '<nextPage2>' is loaded
	And  I click on Manage your account
	And  verify next page '<nextPage3>' is loaded

	Examples: 
	| nextPage                         | logininfo | nextPage2		  | nextPage3		  | nextPage1					                	 |
	| Sign in using Government Gateway | test      | ch cyfrif Defra  | Your Defra account| Dogfennau teithio gydol oes i anifeiliaid anwes  |


Scenario: View Pets travel documents from Manage your accounts page
    Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage1>' is loaded
	And   I should navigate to Manage account
	And   verify next page '<nextPage2>' is loaded
	And   click on View your pet travel documents or apply new one
	And   verify next page '<nextPage1>' is loaded

Examples: 
	| nextPage                         | logininfo | nextPage1                                      | nextPage2       |
	| Sign in using Government Gateway | test      | Dogfennau teithio gydol oes i anifeiliaid anwes| ch cyfrif Defra |