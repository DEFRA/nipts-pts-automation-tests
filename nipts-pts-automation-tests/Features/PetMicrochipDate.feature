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
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 |              |                |               | Yes             | Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 |              | 03             | 2024          | Yes             | Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             |               | Yes             | Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 36           | 02             | 2023          | Yes             | Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 03           | 30             |               | Yes             | Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             | 2027          | Yes             | Rhowch ddyddiad sydd yn y gorffennol |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | 01           | 03             | 1990          | Yes             | n llai na 34 mlynedd yn            |

Scenario: Verify error message if Pets Microchip date is before Pets date of birth
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And  select 'Yes' on Personal Details page
	When  click on continue english
	Then  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue english
	When  enter microchip date as '01', '01', '2024'
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
	When  enter pets date of birth as '01', '01', '2023'
	And click on continue
	Then  verify next page '<nextPage6>' is loaded
	Then Select pet color as '<color>'
	And click on continue
	And  verify next page '<nextPage7>' is loaded
	Then select Pets significant features '<featureOption>'
	And click on continue
	And  verify next page '<nextPage8>' is loaded
	When I have clicked the Welsh change option for the 'Dyddiad mewnblannu neu sganio' from Microchip information section
	And  enter microchip date as '01', '01', '2021'
	And click on continue
	Then verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                      | nextPage1              | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2 | PetName | nextPage3       | PetSex | nextPage4    | nextPage5                       | nextPage6                | color | nextPage7                     | featureOption | nextPage8                                      | nextPage10                    | FooterLang1 | FooterLang2 | nextPage9 | errorMessage            |
	| test2     | Lifelong pet travel documents | What breed is your dog | Dog | 676789876543321 | Pug      | Yes             | name      | toto    | sex is your pet | Gwryw  | Beth yw rhyw | dyddiad geni eich anifail anwes | Beth yw prif liw eich ci | Du    | unrhyw nodweddion arwyddocaol | Nac oes       | Gwiriwch eich atebion a llofnodwch y datganiad | Lifelong pet travel documents | English     | Cymraeg     | Cais wedi | Rhowch ddyddiad sydd ar |
