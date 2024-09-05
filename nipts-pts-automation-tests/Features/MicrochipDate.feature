@Regression
Feature: MicrochipDate

Microchip Date page in Pets application Portal

Scenario: Enter Microchip date in WELSH and verify next page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And  select 'Ydyn' on Personal Details page
	When  click on continue 
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	Then  I have provided date of PETS microchipped
	When  click on continue 
	Then  verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage          | MicrochipNumber | MicrochipOption | nextPage2     | nextPage1       |
	| test2     | Dogfennau teithio | 676789876543325 | Yes             | rhain yw eich | Pryd oedd y tro |


Scenario: Verify blank date error messages on Microchip date page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And  select 'Ydyn' on Personal Details page
	When  click on continue 
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  click on continue 
	Then  verify error message '<errorMsg>' on microchip date page
	

	Examples: 
	| logininfo | nextPage          | MicrochipNumber | MicrochipOption | nextPage2     | nextPage1       | errorMsg                                                     |
	| test2     | Dogfennau teithio | 676789876543325 | Yes             | rhain yw eich | Pryd oedd y tro | Rhowch ddyddiad yn y fformat cywir, er enghraifft 11 04 2021 |


Scenario: Verify past and future date error messages on Microchip date page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And  select 'Ydyn' on Personal Details page
	When  click on continue 
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	Then  enter older date in microchip date field
	When  click on continue 
	Then  verify error message '<errorMsg>' on microchip date page
	When  enter future date in microchip date field
	When  click on continue
	Then  verify error message '<errorMsg2>' on microchip date page

	Examples: 
	| logininfo | nextPage          | MicrochipNumber | MicrochipOption | nextPage2     | nextPage1       | errorMsg              | errorMsg2                            |
	| test2     | Dogfennau teithio | 676789876543325 | Yes             | rhain yw eich | Pryd oedd y tro | llai na 34 mlynedd yn | Rhowch ddyddiad sydd yn y gorffennol |


@ignore
Scenario: Verify error message when microchipd date is before pet date of birth
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	When  click on continue 
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue
	Then  I have provided date of PETS microchipped
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	And   click on back
	And   click on back
	And   click on back
	And   click on back
	And   click on back


	Examples: 
	| logininfo | nextPage          | MicrochipNumber | MicrochipOption | nextPage2     | nextPage1       | errorMsg              | Pet    | PetName | PetSex |
	| test2     | Dogfennau teithio | 676789876543325 | Yes             | rhain yw eich | Pryd oedd y tro | llai na 34 mlynedd yn | Ffured | Ferret  | Benyw  |

