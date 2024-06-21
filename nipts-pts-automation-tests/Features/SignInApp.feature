@Regression
Feature: SignInApp

Sign in to Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

Scenario: Navigate  and Sign In to Pets Application Portal Page
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'

	Examples: 
	| nextPage                         | logininfo |
	| Sign in using Government Gateway | test2     |


Scenario: Verify Sign Out is displayed in WELSH language
	Then  verify next page '<nextPage>' is loaded
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language
	Then  verify sign out link in displayed in selected language '<SignOutLinkText>'
	
	Examples: 
	| nextPage                         | logininfo | SignOutLinkText |
	| Sign in using Government Gateway | test2     |    Allgofnodi   |