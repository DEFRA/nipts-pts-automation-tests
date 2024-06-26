@Regression
Feature: SignInCom

Sign in to Pets Compliance Portal

Background: 
	Given that I navigate to the Pets compliance portal

Scenario: Navigate to Pets Compliance Portal Page
	When  click on sign in button
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| nextPage           |
	| Current sailing    |