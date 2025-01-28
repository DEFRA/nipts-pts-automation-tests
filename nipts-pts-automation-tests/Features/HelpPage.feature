@Regression 
Feature: HelpPage

Verify Get HelpPage on Pets


Scenario Outline: Verify Get Help Page in WELSH
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  click on Get Help Welsh Link
	Then  verify next page '<nextPage2>' is loaded
	And   verify displayed language at page footer '<FooterLang1>'
	Then  click on English language
	And   verify displayed language at page footer '<FooterLang2>'


	Examples: 
	| logininfo | nextPage                      | nextPage1    | nextPage2              | FooterLang1 | FooterLang2 |
	| test      | Lifelong pet travel documents | manylion chi | Cael help i wneud cais | English     | Cymraeg     |


Scenario Outline: Verify Back link on Get Help Page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	And   click on Get Help Welsh Link
	Then  verify next page '<nextPage2>' is loaded
	When  click on back
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                      | nextPage2              | nextPage1    |
	| test      | Lifelong pet travel documents | Cael help i wneud cais | manylion chi |
