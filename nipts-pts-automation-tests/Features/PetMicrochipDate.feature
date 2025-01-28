@Regression
Feature: PetMicrochipDate

Validate Microchip Date page in Pets application Portal

Scenario: Enter valid microchip date and verify next page in the application
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  enter microchip date as '<MicrochipDay>', '<MicrochipMonth>', '<MicrochipYear>'
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1                               | MicrochipNumber | MicrochipDay | MicrochipMonth | MicrochipYear | MicrochipOption | nextPage2                         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             | 2024          | Yes             | r rhain yw eich anifail anwes chi |

	Scenario: Validate error messages on microchip date
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  enter microchip date as '<MicrochipDay>', '<MicrochipMonth>', '<MicrochipYear>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets


	Examples: 
	| logininfo | nextPage                                        | nextPage1                               | MicrochipNumber | MicrochipDay | MicrochipMonth | MicrochipYear | MicrochipOption | errorMessage                       |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 |              |                |               | Yes             | Rhowch ddyddiad yn y fformat cywir |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 |              | 03             | 2024          | Yes             | Rhowch ddyddiad yn y fformat cywir |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             |               | Yes             | Rhowch ddyddiad yn y fformat cywir |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 36           | 02             | 2023          | Yes             | Rhowch ddyddiad yn y fformat cywir |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 03           | 30             |               | Yes             | Rhowch ddyddiad yn y fformat cywir |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             | 2027          | Yes             | Rhowch ddyddiad sydd yn y gorffennol |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             | 1990          | Yes             | n llai na 34 mlynedd yn            |
