@Validations @APGBRegression 
Feature: AP Pets WAF rule validation

Validating invalid characters

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Verify getting expected page on invalid characters
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then verify next page '<nextPage>' is loaded
	And click browser back
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | nextPage                                           |
	| '-'      | No                       | You cannot access this page or perform this action | 
