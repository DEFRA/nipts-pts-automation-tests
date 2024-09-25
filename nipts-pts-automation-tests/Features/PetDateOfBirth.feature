@Regression
Feature: PetDateOfBirth

Validate Pet Date of birth page in Pets application Portal


Scenario: Enter valid pet date of birth and validate next page in the application in WELSH
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
	When  enter microchip date as '<MicrochipDay>', '<MicrochipMonth>', '<MicrochipYear>'
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	And   verify next page '<nextPage2>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  enter pets date of birth as '<PetDOBDay>', '<PetDOBMonth>', '<PetDOBYear>'
	Then  click on continue
	And  verify next page '<nextPage4>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1   | Pet | MicrochipNumber | PetBreed  | MicrochipOption | nextPage2               | PetName | PetSex | nextPage3                       | PetDOBDay | PetDOBMonth | PetDOBYear | MicrochipDay | MicrochipMonth | MicrochipYear | nextPage4     |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes | 01        | 01          | 2020       | 01           | 03             | 2024          | prif liw eich |

	
	Scenario: Validate error messages on pet date of birth page
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
	When  enter microchip date as '<MicrochipDay>', '<MicrochipMonth>', '<MicrochipYear>'
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	And   verify next page '<nextPage2>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  enter pets date of birth as '<PetDOBDay>', '<PetDOBMonth>', '<PetDOBYear>'
	Then  click on continue
	And  verify error message '<errorMessage>' on Pets 


	Examples: 
	| logininfo | nextPage                                        | nextPage1   | Pet | MicrochipNumber | PetBreed  | MicrochipOption | nextPage2               | PetName | PetSex | nextPage3                       | PetDOBDay | PetDOBMonth | PetDOBYear | MicrochipDay | MicrochipMonth | MicrochipYear | errorMessage						  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |           |             |            | 01           | 03             | 2024          | Rhowch ddyddiad yn y fformat cywir  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |     01    |             |   2000     | 01           | 03             | 2024          | Rhowch ddyddiad yn y fformat cywir  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |           |  03         |   2000     | 01           | 03             | 2024          | Rhowch ddyddiad yn y fformat cywir  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |     01    |  03         |            | 01           | 03             | 2024          | Rhowch ddyddiad yn y fformat cywir  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |     02    |  03         |   2024     | 01           | 03             | 2024          | Rhowch ddyddiad sydd cyn rhif microsglodyn yr anifail anwes  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |     02    |  03         |   2025     | 01           | 03             | 2024          | Rhowch ddyddiad sydd yn y gorffennol  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes | toto    | Gwryw  | dyddiad geni eich anifail anwes |     02    |  03         |   1988     | 01           | 03             | 2024          | llai na 34 mlynedd yn|