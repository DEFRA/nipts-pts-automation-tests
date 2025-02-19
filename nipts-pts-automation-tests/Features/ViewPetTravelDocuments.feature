@Regression
Feature: ViewPetTravelDocuments

Verify Pet travel documents in WELSH

Scenario: View Pet travel documents in WELSH
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
	Then  I have selected an option as '<Pet>' for pets
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
    Then  enter the pet date of birth
	And click on continue
	And  verify next page '<nextPage6>' is loaded
	Then Select pet color as '<color>'
	And click on continue
	And  verify next page '<nextPage7>' is loaded
	Then select Pets significant features '<featureOption>'
	And click on continue
	And  verify next page '<nextPage8>' is loaded
	And confirm the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then click on Apply for another lifelong pet travel document link
	And  verify next page 'ch manylion chi' is loaded
	Then verify displayed language at page footer '<FooterLang1>'
	And  click on English language
	Then verify displayed language at page footer '<FooterLang2>'
	
		
	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3       | PetSex | nextPage4    | nextPage5					    | nextPage6			       | color | nextPage7                     | featureOption | nextPage8              | nextPage10                    | FooterLang1 | FooterLang2 | nextPage9	 |
	| test2     | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | sex is your pet | Gwryw  | Beth yw rhyw | dyddiad geni eich anifail anwes | Beth yw prif liw eich ci | Du    | unrhyw nodweddion arwyddocaol | Nac oes       | Gwiriwch eich atebion  | Lifelong pet travel documents | English     | Cymraeg     | manylion chi |