@Regression
Feature: PetBreed

Pet breed page in Pets application Portal

Scenario: Select pet breed in WELSH and verify next page in the application
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
	Then  I have provided date of PETS microchipped
	And   click on continue
	Then  I have selected an option as '<Pet>' for pets
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2         | 
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?   | Ci  | 676789876543321 | Basenji  | Yes             | ch anifail anwes? |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi? | Cath| 676789876543321 | Cath Americanaidd blew cwta  | Yes             | ch anifail anwes? |


Scenario: Verify error messages for invalid input on pet breed in WELSH
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
	Then  I have provided date of PETS microchipped
	And   click on continue
	Then  I have selected an option as '<Pet>' for pets
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pet Breed page

	Examples: 
	| logininfo | nextPage                                        | nextPage1    | Pet | MicrochipNumber | PetBreed | MicrochipOption | errorMessage        |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?   | Ci  | 676789876543321 |          | Yes             | Dewiswch neu roi fr |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?   | Ci  | 676789876543321 | A£$%EFGHIJKLMNOPHDJHGDFJKGFDKJBVKJDFNBKJFDHGKJSDHFGKDJHFKJSDHFKJHDSKJFHDKJHKJDHFKDHGJGJHSDFVJSDHFJDBFJEDDIUFGEISEHFKSDNFSBDFJFGFGFGHGHDHBVCJXCVKJDFGVKD         | Yes  | Rhowch frid gan ddefnyddio 150 o gymeriadau neu lai |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi? | Cath| 676789876543321 |          | Yes             | Dewiswch neu roi fr |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi? | Cath| 676789876543321 | A£$%EFGHIJKLMNOPHDJHGDFJKGFDKJBVKJDFNBKJFDHGKJSDHFGKDJHFKJSDHFKJHDSKJFHDKJHKJDHFKDHGJGJHSDFVJSDHFJDBFJEDDIUFGEISEHFKSDNFSBDFJFGFGFGHGHDHBVCJXCVKJDFGVKD         | Yes  | Rhowch frid gan ddefnyddio 150 o gymeriadau neu lai |

Scenario: Verify select breed page not coming for Ferret in WELSH 
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
	Then  I have provided date of PETS microchipped
	And   click on continue
	Then  I have selected an option as '<Pet>' for pets
	And   click on continue
	And   verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | Pet     | MicrochipNumber | MicrochipOption | nextPage2         | 
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Ffured  | 676789876543321 | Yes             | ch anifail anwes? |
