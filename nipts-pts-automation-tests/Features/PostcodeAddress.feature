@Regression
Feature: PostcodeAddress

Update and verify Postcode Address on Pets application Portal

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
	Then  verify total address found on select address page
	When  select address
	Then  verify next page '<nextPage4>' is loaded
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | nextPage2     | nextPage3   | nextPage4    | nextPage5 | fullname     | postcode |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | manylion chi | ch enw llawn? | ch cod post | ch cyfeiriad?| ch rhif ff| TestFullName | SE1 7PB  |

	
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
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName |          | Rhowch eich cod post                |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName | SE10 1EE | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | TestFullName | SE1 7PBABCDEFGHIJKLMNOP  |Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY   |

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

Scenario: Verify error message on select address page on Pets 
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
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | nextPage2     | nextPage3   | fullname     | postcode | errorMessage                             |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | manylion chi | ch enw llawn? | ch cod post | TestFullName | SE1 7PB  | Dewiswch eich cyfeiriad o blith y rhestr |

Scenario: Verify cannot find address link on select address page on Pets 
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
	And   click on I cannot find the address in the list
	Then  verify next page '<nextPage4>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | nextPage2     | nextPage3   | nextPage4    | fullname     | postcode |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | manylion chi | ch enw llawn? | ch cod post | ch cyfeiriad?| TestFullName | SE1 7PB  |
