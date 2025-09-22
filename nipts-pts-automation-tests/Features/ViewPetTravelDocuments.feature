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
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | sex is your pet | Gwryw  | Beth yw rhyw | dyddiad geni eich anifail anwes | Beth yw prif liw eich ci | Du    | unrhyw nodweddion arwyddocaol | Nac oes       | Gwiriwch eich atebion  | Lifelong pet travel documents | English     | Cymraeg     | manylion chi |


	
	Scenario: View Pet travel documents in WELSH for Approved PTD
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
	Then  I have selected an option as '<Pet>' for pets
	And   click on continue english
	And   verify next page '<nextPage1>' is loaded
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue english
	And   click on continue english
	And   verify next page '<nextPage2>' is loaded
	Then  I provided the Pets name as '<PetName>'
	Then  click on continue english
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	Then  select Pets significant features '<featureOption>'
	And   click on continue
	And   I have ticked the I agree to the declaration checkbox
	When  I click Accept and Send button from Declaration page
	Then  I can see the unique application reference number
	When  Approve an application via backend
	When  I have clicked the View all your lifelong pet travel documents link
	Then  I should redirected to Apply for a pet travel document page 
	And   I should see the application in 'Approved' status
	When  click on Welsh language
	When  I have clicked the View hyperlink from home page
	Then  verify Place of Issuance text is present 'man cyhoeddi' on Approved PTD
	Then  verify WELSH heading text 'i dyroddi' on Summary page 
	Then  verify WELSH text for PTD Number 'Rhif y ddogfen deithio i anifail anwes' and PTD Number on approved PTD
	Then  verify WELSH heading text 'Gwybodaeth am y microsglodyn' on Summary page 
	Then  verify WELSH summary of Approved PTD field name 'Rhif y microsglodyn' and field value '676789876543321'
	Then  verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on approved PTD
	Then  verify WELSH summary of Approved PTD field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	Then  verify WELSH heading text 'Awdurdod dyroddi' on Summary page 
	Then  verify WELSH summary of Approved PTD field name 'Enw a chyfeiriad yr awdurdod cymwys' and field value 'Asiantaeth Iechyd Anifeiliaid a Phlanhigion'
	Then  verify WELSH heading text 'Manylion yr anifail anwes' on Summary page 
	Then  verify WELSH summary of Approved PTD field name 'Enw' and field value 'toto'
	Then  verify WELSH summary of Approved PTD field name 'Rhywogaeth' and field value 'Ci'
	Then  verify WELSH summary of Approved PTD field name 'Brid' and field value 'Pug'
	Then  verify WELSH summary of Approved PTD field name 'Rhyw' and field value 'Gwryw'
	Then  verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on approved PTD
	Then  verify WELSH summary of Approved PTD field name 'Lliw' and field value 'Black'
	Then  verify WELSH summary of Approved PTD field name 'Nodweddion arwyddocaol' and field value 'Nac oes'
	Then  verify WELSH heading text 'Manylion perchennog yr anifail anwes' on Summary page 
	Then  verify WELSH format of PTD number on search results page

	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | PetSex | color | featureOption | FooterLang1 | FooterLang2 |
	| test      | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | Male   | Black | No            | English     | Cymraeg     |

	Scenario: View Pet travel documents in WELSH for Pending Application
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue 
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
	When  I provided the Pets name as '<PetName>'
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
	Then  I verify application submitted page title '<nextpage5>'
	And   I can see the unique application reference number
	When  click on View all lifelong pet travel document link
	Then  verify next page '<nextPage>' is loaded
	And   I should see the application in 'Yn aros' status
	When  I have clicked the View hyperlink from home page
	Then  verify WELSH heading text 'Cais' on Summary page 
	Then  verify WELSH text for Reference Number 'Rhif cyfeirnod' and Reference Number on pending application
	Then  verify WELSH summary of Pending Appl for field name 'Statws' and field value 'Yn aros'
	Then  verify WELSH heading text 'Gwybodaeth am y microsglodyn' on Summary page 
	Then  verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on Pending Appl
	Then  verify WELSH summary of Approved PTD field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	Then  verify WELSH heading text 'Manylion yr anifail anwes' on Summary page 
	Then  verify WELSH summary of Pending Appl for field name 'Rhif y microsglodyn' and field value '676789876543321'
	Then  verify WELSH summary of Pending Appl for field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	Then  verify WELSH summary of Pending Appl for field name 'Enw' and field value 'Testtoto'
	Then  verify WELSH summary of Pending Appl for field name 'Rhywogaeth' and field value 'Dog'
	Then  verify WELSH summary of Pending Appl for field name 'Brid' and field value 'Basenji'
	Then  verify WELSH summary of Pending Appl for field name 'Rhyw' and field value 'Male'
	Then  verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on Pending Appl
	Then  verify WELSH summary of Pending Appl for field name 'Lliw' and field value 'Black'
	Then  verify WELSH summary of Pending Appl for field name 'Nodweddion arwyddocaol' and field value 'No'
	Then  verify WELSH heading text 'Manylion perchennog yr anifail anwes' on Summary page 

	Examples: 
	| logininfo | nextPage          | nextPage1       | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3     | PetSex | nextPage4  | color | featureOption  | FooterLang1 | FooterLang2 | nextpage5 | fullname | postcode | phoneNumber  |
	| test      | Dogfennau teithio | ch manylion chi | Ci  | 676789876543321 | Basenji  | Yes             | Beth yw   | Testtoto| ch cyfeiriad? | Gwryw  | ch rhif ff | Du    | Nac oes        | English     | Cymraeg     | Cais wedi | New User | CV31 2EE | 07833861122  |
