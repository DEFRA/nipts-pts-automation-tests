@Regression
Feature: PostcodeAddress

Update and verify Postcode Address on Pets application Portal

@CrossBrowser
Scenario: Enter postcode and select address on Pets 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded
	When  enter your full name '<fullname>'
	And   click on continue
	Then  verify next page '<nextPage3>' is loaded
	When  enter your postcode '<postcode>'
	And   select address
	Then  verify next page '<nextPage4>' is loaded
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | nextPage2 | nextPage3   | nextPage4    | nextPage5 | fullname     | postcode |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | manylion chi | Beth yw   | ch cod post | ch cyfeiriad?| Beth yw   | TestFullName | SE1 7PB  |

Scenario: Verify error message for invalid postcode
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	When  enter your full name '<fullname>'
	And   click on continue
	When  enter your postcode '<postcode>'
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                                        | fullname     | postcode | errorMessage                        |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName |          | Rhowch god post                     |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName | SE10 1EE | Rhowch god post yng Nghymru         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName | SE1 7PBABCDEFGHIJKLMNOP  |Rhowch god post llawn yn y fformat cywir   |

	Scenario: Change postcode on what is your address page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	When  enter your full name '<fullname>'
	And   click on continue
	When  enter your postcode '<postcode>'
	Then  verify next page '<nextPage1>' is loaded
	When  click on change postcode
	Then  verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | fullname     | postcode | nextPage1    | nextPage2    |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName | SE10 0BP | ch cyfeiriad | ch cod post  |
