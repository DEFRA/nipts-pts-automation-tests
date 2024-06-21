@Regression
Feature: PersonalDetails

Personal Details page in Pets application Portal

Scenario: Verify Personal Details page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	Then  verify Personal Details for user '<logininfo>'


	Examples: 
	| logininfo | nextPage                      | nextPage1    |
	| test      | Lifelong pet travel documents | manylion chi |

	Scenario: Verify Personal Details page in Welsh and English version
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  click on Welsh language 
	Then  verify next page '<nextPage2>' is loaded
	When  click on English language 
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                      | nextPage1                 | nextPage2    |
	| test      | Lifelong pet travel documents | Are your details correct? | manylion chi |


	Scenario: Verify Error message on not selecting option before continue on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	When  click on Welsh language 
	When  click on continue
	Then  verify error message '<errorMessage>' on Personal Details page


	Examples: 
	| logininfo | nextPage                      | errorMessage                   |
	| test      | Lifelong pet travel documents | Dwedwch a yw eich manylion chi |

	Scenario: Verify next page after selecting Yes on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	When  click on Welsh language 
	And   select 'Ydyn' on Personal Details page
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                      | nextPage1                 |
	| test      | Lifelong pet travel documents | Is your pet microchipped? |

	
	Scenario: Verify next page after selecting No on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	When  click on Welsh language 
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                      | nextPage1               |
	| test      | Lifelong pet travel documents | What is your full name? |


	Scenario: Verify back link on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   click on Welsh language 
	And   click on back
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                      | nextPage1                     |
	| test      | Lifelong pet travel documents | Lifelong pet travel documents |