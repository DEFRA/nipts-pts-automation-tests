@Regression
Feature: FullName

Update and verify Full Name on Pets application Portal

Scenario: Enter Full Name on Pets 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded
	When  enter your full name '<fullname>'
	And   click on continue
	Then  verify next page '<nextPage3>' is loaded

	Examples: 
	| logininfo | nextPage                      | nextPage1    | nextPage2 | nextPage3   | fullname     | 
	| test      | Lifelong pet travel documents | manylion chi | Beth yw   | ch cod post | TestFullName |

Scenario: Verify error message for invalid full Name
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	When  enter your full name '<fullname>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                      | fullname     | errorMessage                        |
	| test      | Lifelong pet travel documents |              | Rhowch eich enw llawn               |

