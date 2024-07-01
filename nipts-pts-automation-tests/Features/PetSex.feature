@Regression
Feature: PetSex

Pet sex page in Pets application Portal

Scenario: Select pet sex in WELSH and verify next page in the application
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And  select 'Yes' on Personal Details page
	When  click on continue english
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue english
	Then  I have provided date of PETS microchipped
	When  click on continue english
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue english
	And  verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	Then   click on continue english
	And   click on continue english
	And  verify next page '<nextPage2>' is loaded
	When  Enter name of your pet '<PetName>'
	Then   click on continue english
	And  verify next page '<nextPage3>' is loaded
	When  click on Welsh language
	Then  verify next page '<nextPage4>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then   click on continue 
	And  verify next page '<nextPage5>' is loaded

	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3         | PetSex | nextPage4    | nextPage5     |
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | sex is your pet   | Gwryw  | Beth yw rhyw | date of birth |


Scenario: Verify WELSH error message when no option is selected on select pet sex page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Yes' on Personal Details page
	When  click on continue english
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue english
	Then  I have provided date of PETS microchipped
	When  click on continue english
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue english
	And  verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	And   click on continue english
	And   click on continue english
	Then  verify next page '<nextPage2>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue english
	And   verify next page '<nextPage3>' is loaded
	When  click on Welsh language
	Then  verify next page '<nextPage4>' is loaded
	Then  click on continue
	And   verify error message '<ErrorMessage>' on Select sex of pet page
	

	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3               | nextPage4    | ErrorMessage                 |
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | What sex is your pet?   | Beth yw rhyw |  anifail anwes yn wryw ynteu |


Scenario: Verify language footer when WELSH language is selected on select pet sex page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Yes' on Personal Details page
	And  click on continue english
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue english
	Then  I have provided date of PETS microchipped
	And   click on continue english
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue english
	Then  verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	And   click on continue english
	And   click on continue english
	Then  verify next page '<nextPage2>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue english
	And   verify next page '<nextPage3>' is loaded
	And   verify displayed language at page footer '<FooterLang1>'
	When  click on Welsh language
	Then  verify next page '<nextPage4>' is loaded
	And   verify displayed language at page footer '<FooterLang2>'

	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3             | nextPage4    | FooterLang1 | FooterLang2 |
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | What sex is your pet? | Beth yw rhyw |  Cymraeg    | English     |