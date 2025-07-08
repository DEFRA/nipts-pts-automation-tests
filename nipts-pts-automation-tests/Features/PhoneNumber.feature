@Regression
Feature: PhoneNumber

Update and verify Phone Number on Pets application Portal

Scenario: Enter Telephone Number on Pets 
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
	When  enter phone number '<phoneNumber>'
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded

	Examples: 
	| logininfo | nextPage                      | nextPage1    | nextPage2| nextPage3    | nextPage4  | nextPage5             | fullname     | postcode | phoneNumber |
	| test      | Lifelong pet travel documents | manylion chi | Beth yw  | ch cod post? | ch rhif ff | Oes microsglodyn wedi | TestFullName | SE1 7PB  | 07456789442  |
	| test      | Lifelong pet travel documents | manylion chi | Beth yw  | ch cod post? | ch rhif ff | Oes microsglodyn wedi | TestFullName | SE1 7PB  | +44 7000000000  |
	| test      | Lifelong pet travel documents | manylion chi | Beth yw  | ch cod post? | ch rhif ff | Oes microsglodyn wedi | TestFullName | SE1 7PB  | 0               |
	| test      | Lifelong pet travel documents | manylion chi | Beth yw  | ch cod post? | ch rhif ff | Oes microsglodyn wedi | TestFullName | SE1 7PB  | 12345678912345678912  |

Scenario: Verify error message for invalid contact Telephone Number
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
	And   select address
	And   click on continue
	And   enter phone number '<phoneNumber>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                      | fullname     | postcode | phoneNumber | errorMessage                        |
	| test      | Lifelong pet travel documents | TestFullName | SE1 7PB  | 07456789**  |  fel 01632 960 001 neu 07700 900 982 |
	| test      | Lifelong pet travel documents | TestFullName | SE1 7PB  |             | Rhowch eich rhif ff                 |
	| test      | Lifelong pet travel documents | TestFullName | SE1 7PB  | 0745678976435847687465  |  fel 01632 960 001 neu 07700 900 982 |

	
	Scenario: Verify English and Welsh Version of Telephone Number page on Pets 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded
	When  enter your full name '<fullname>'
	And   click on continue
	When  enter your postcode '<postcode>'
	And   select address
	And   click on continue
	Then  verify next page '<nextPage3>' is loaded
	When  enter phone number '<phoneNumber>'
	And   click on continue
	Then  verify next page '<nextPage4>' is loaded
	When  click on back
	Then  verify next page '<nextPage2>' is loaded
	When  click on English language 
	Then  verify next page '<nextPage6>' is loaded
	When  enter phone number '<phoneNumber>'
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded

	Examples: 
	| logininfo | nextPage1    | nextPage2  | nextPage3  | nextPage4             | nextPage5                 | nextPage6                  | fullname     | postcode | phoneNumber  |
	| test      | manylion chi | Beth yw    | ch rhif ff | Oes microsglodyn wedi | Is your pet microchipped? | What is your phone number? | TestFullName | SE1 7PB  | 07456789442  |


