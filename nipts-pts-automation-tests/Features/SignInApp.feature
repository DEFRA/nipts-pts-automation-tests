@Regression
Feature: SignInApp

Sign in to Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

Scenario: Navigate to Pets Application Portal Page
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| nextPage                        |
	| This is for testing use only    |