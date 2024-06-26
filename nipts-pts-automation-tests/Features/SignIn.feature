@Regression
Feature: SignIn

Sign in to Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

Scenario: Navigate  and Sign In to Pets Application Portal Page
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'

	Examples: 
	| nextPage                         | logininfo |
	| Sign in using Government Gateway | test      |


Scenario: Verify Sign Out functionality for WELSH language
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language
	Then  verify sign out link in displayed in selected language '<SignOutLinkText>'
	Then  verify displayed language at page footer '<DisplayedLang>'
	When  click on English language
	Then  verify sign out link in displayed in selected language '<SignOutLinkText2>'
	Then  verify displayed language at page footer '<DisplayedLang2>'
	When  click on Welsh language
	When  click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded

	Examples: 
	| nextPage                         | logininfo | SignOutLinkText | DisplayedLang | SignOutLinkText2 | DisplayedLang2 | nextPage1    |
	| Sign in using Government Gateway | test      | Allgofnodi      | English       | Sign Out         | Cymraeg        | gywir        |