@Regression
Feature: ViewSubmissionConfirmation

Verify Submission Confirmation Page in WELSH

Scenario: View Submission confirmation page in WELSH
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
	And  verify next page '<nextPage9>' is loaded
	And I verify the link '<Link1>' on page
	Then click on Apply for another lifelong pet travel document link
	And  verify next page 'manylion chi' is loaded
	Then verify displayed language at page footer '<FooterLang1>'
	And  click on English language
	Then verify displayed language at page footer '<FooterLang2>'
	
		
	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3       | PetSex | nextPage4    | nextPage5                       | nextPage6                | color | nextPage7                     | featureOption | nextPage8                                      | nextPage10                    | FooterLang1 | FooterLang2 | nextPage9 | Link1            |
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | sex is your pet | Gwryw  | Beth yw rhyw | dyddiad geni eich anifail anwes | Beth yw prif liw eich ci | Du    | unrhyw nodweddion arwyddocaol | Nac oes       | Gwiriwch eich atebion a llofnodwch y datganiad | Lifelong pet travel documents | English     | Cymraeg     | Cais wedi | Rhowch eich barn |


	Scenario: Verify Change your details page in WELSH when postcode is not from England, scotland or Wales
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  click on continue 
	And   enter your full name '<fullname>'
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded
	When  enter your postcode '<postcode>'
	Then  verify total address found on select address page
	When  select address
	Then  verify next page '<nextPage3>' is loaded
	And   click on continue
	Then  verify next page '<nextPage4>' is loaded
	When  enter phone number '<phoneNumber>'
	And   click on continue
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue
	Then  I have provided date of PETS microchipped
	When  click on continue 
	Then  I have selected an option as '<Pet>' for pets
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue	
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    And   enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	Then  select Pets significant features '<featureOption>'
	And   click on continue
	And   confirm the declaration checkbox
	Then  click Accept and Send button from Declaration page
	And   verify next page '<nextPage5>' is loaded
	Then  click on Apply for another lifelong pet travel document link
	And   verify next page 'Newid eich manylion' is loaded
	And   verify displayed language at page footer '<FooterLang1>'
	And   click on English language
	Then   verify displayed language at page footer '<FooterLang2>'
	
		
	Examples: 
	| logininfo | nextPage          | nextPage1           | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3     | PetSex | nextPage4  | color  | featureOption  | FooterLang1 | FooterLang2 | nextPage5 | fullname | postcode | phoneNumber  |
	| test3     | Dogfennau teithio | Newid eich manylion | Ci  | 676789876543321 | Basenji  | Yes             | Beth yw   | toto    | ch cyfeiriad? | Gwryw  | ch rhif ff | Du     | Nac oes        | English     | Cymraeg     | Cais wedi | New User | CV31 2EE | 07833861122  |