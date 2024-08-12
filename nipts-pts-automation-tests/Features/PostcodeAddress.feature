@Regression
Feature: PostcodeAddress

Update and verify Postcode Address on Pets application Portal

@CrossBrowser
Scenario: Enter postcode and select address on Pets 
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
	When  enter your postcode '<postcode>'
	And   select address
	And   click on continue
	Then  verify next page '<nextPage4>' is loaded

	Examples: 
	| logininfo | nextPage                      | nextPage1    | nextPage2 | nextPage3   | nextPage4 | fullname     | postcode |
	| test      | Lifelong pet travel documents | manylion chi | Beth yw   | ch cod post |           | TestFullName | SE1 7PB  |

Scenario: Verify error message for invalid postcode
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Welsh language 
	And   click on Apply for a document
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	When  enter your full name '<fullname>'
	And   click on continue
	When  enter your postcode '<postcode>'
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                      | fullname     | postcode | errorMessage                        |
	| test      | Lifelong pet travel documents | TestFullName |          | Rhowch god post                     |
	| test      | Lifelong pet travel documents | TestFullName | SE10 1EE |    |
	| test      | Lifelong pet travel documents | TestFullName | SE1 7PBABCDEFGHIJKLMNOP  |   |

