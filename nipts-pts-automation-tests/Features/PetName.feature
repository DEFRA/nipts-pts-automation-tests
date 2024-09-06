@Regression
Feature: PetName

Pet name page in Pets application Portal

Scenario: Enter Pet name in WELSH and verify next page in the application
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
	When  Select breed of your pet '<PetBreed>'
	Then   click on continue
	And   click on continue
	And  verify next page '<nextPage1>' is loaded
	When  Enter name of your pet '<PetName>'
	Then   click on continue
	And  verify next page '<nextPage2>' is loaded


	Examples: 
	| logininfo | nextPage										  | nextPage1   | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2                    | PetName | 
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan| Yes             | rhyw eich anifail anwes      | toto    |


Scenario: Verify WELSH error message when no option is selected on enter pet name page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And  click on Welsh language
	Then verify next page '<nextPage>' is loaded
	When click on Apply for a document
	And  select 'Ydyn' on Personal Details page
	When click on continue
	Then I selected the '<MicrochipOption>' option
	And  provided microchip number as <MicrochipNumber>
	And  click on continue
	Then I have provided date of PETS microchipped
	When click on continue
	Then I have selected an option as '<Pet>' for pet
	And  click on continue
	When Select breed of your pet '<PetBreed>'
	Then click on continue
	And  click on continue
	And  verify next page '<nextPage1>' is loaded
	When Enter name of your pet '<PetName>'
	And click on continue
	Then  verify error message '<ErrorMessage>' on enter pet name
	

Examples: 
	| logininfo | nextPage                                        | nextPage1   | Pet | MicrochipNumber | PetBreed  | MicrochipOption | nextPage2               | PetName | ErrorMessage   |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw enw | Ci  | 676789876543321 | Ci Affgan | Yes             | rhyw eich anifail anwes |         | Rhowch enw eich anifail anwes |



Scenario: Verify language footer when WELSH language is selected on enter pet name
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then verify next page '<nextPage>' is loaded
	When click on Apply for a document
	And  select 'Yes' on Personal Details page
	When click on continue
	Then I selected the '<MicrochipOption>' option
	And  provided microchip number as <MicrochipNumber>
	And  click on continue
	Then I have provided date of PETS microchipped
	When click on continue
	Then I have selected an option as '<Pet>' for pet
	And  click on continue
	When Select breed of your pet '<PetBreed>'
	Then click on continue
	And  click on continue
	Then verify next page '<nextPage1>' is loaded
	And  verify displayed language at page footer '<FooterLang1>'
	When click on Welsh language
	Then verify displayed language at page footer '<FooterLang2>'

Examples: 
	| logininfo | nextPage                      | nextPage1  | Pet | MicrochipNumber | PetBreed  | MicrochipOption  | FooterLang2 | FooterLang1 |
	| test      | Lifelong pet travel documents |  name      | Dog | 676789876543321 | Pug       | Yes              |  English    | Cymraeg     |
