@Regression
Feature: PetColour

Pet Color page in Pets application Portal

Scenario: Select pet color in WELSH and verify next page in the application
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
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then Select pet color as '<color>'
	And click on continue
	And  verify next page '<nextPage6>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1  | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | nextPage6                       |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi? | Ci  | 676789876543321 | Basenji  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Du    | unrhyw nodweddion arwyddocaol   |

	@RunOnly
Scenario: Verify WELSH error message when no color is selected on pet color page
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
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify error message '<errorMsg>' on pet color page


	Examples: 
	| logininfo | nextPage                                        | nextPage1		    | Pet    | MicrochipNumber | PetBreed | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | nextPage6                     | errorMsg                    |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?		    | Ci     | 676789876543321 | Basenji  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich |       | unrhyw nodweddion arwyddocaol | Dewiswch brif liw eich ci   |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi?		| Cath   | 676789876543321 | Birman   | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich |       | unrhyw nodweddion arwyddocaol | Dewiswch brif liw eich cath |
	
	
	@RunOnly
Scenario: Verify WELSH error message for invalid input in Other color option
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
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then  Select pet color as '<color>'
	And   Enter text in Other color '<OtherColorText>' option
	And   click on continue
	And   verify error message '<errorMsg>' on pet color page


	Examples: 
	| logininfo | nextPage                                        | nextPage1         | Pet   | MicrochipNumber | PetBreed | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | nextPage6                     | errorMsg									 | OtherColorText |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?        | Ci    | 676789876543321 | Basenji  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | Disgrifiwch liw eich ci		  			 |                |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi?        | Ci    | 676789876543321 | Basenji  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | gan ddefnyddio 150 o gymeriadau neu lai    |I am entering more thant one hundred and fifty characters in the pet color field. Error message should be displayed for exceeding the character limit  .                |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi       | Cath  | 676789876543321 | Birman   | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | Disgrifiwch liw eich cath					 |                |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch cath chi       | Cath  | 676789876543321 | Birman   | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | gan ddefnyddio 150 o gymeriadau neu lai    |I am entering more thant one hundred and fifty characters in the pet color field. Error message should be displayed for exceeding the character limit  .                |

	@RunOnly
	Scenario: Verify WELSH error message for invalid input in Other color option for ferret
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
	Then  verify next page '<nextPage2>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then  Select pet color as '<color>'
	And   Enter text in Other color '<OtherColorText>' option
	And   click on continue
	And   verify error message '<errorMsg>' on pet color page


	Examples: 
	| logininfo | nextPage                                        | nextPage1         | Pet   | MicrochipNumber | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | nextPage6                     | errorMsg									 | OtherColorText |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes? | Ffured| 676789876543321 | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | Disgrifiwch liw eich ffured  			 |                |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes? | Ffured| 676789876543321 | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Arall | unrhyw nodweddion arwyddocaol | gan ddefnyddio 150 o gymeriadau neu lai    |I am entering more thant one hundred and fifty characters in the pet color field. Error message should be displayed for exceeding the character limit  .                |

	@RunOnly
Scenario: Verify WELSH error message when no color is selected on pet color page for ferret
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
	Then  verify next page '<nextPage2>' is loaded
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify error message '<errorMsg>' on pet color page


	Examples: 
	| logininfo | nextPage                                        | nextPage1         | Pet    | MicrochipNumber  | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | nextPage6                     | errorMsg                      |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes? | Ffured | 676789876543321  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich |       | unrhyw nodweddion arwyddocaol | Dewiswch brif liw eich ffured |
	

Scenario: Verify language footer when WELSH language is selected on select pet color page
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
	When  Enter name of your pet '<PetName>'
	Then  click on continue 
	And   verify next page '<nextPage3>' is loaded
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
	Then  verify next page '<nextPage4>' is loaded
	Then  enter the pet date of birth
	And   click on continue
	Then  verify next page '<nextPage5>' is loaded
	Then verify displayed language at page footer '<FooterLang1>'
	And  click on English language
	Then verify displayed language at page footer '<FooterLang2>'


	Examples: 
	| logininfo | nextPage                                        | nextPage1  | Pet | MicrochipNumber | PetBreed | MicrochipOption | nextPage2         | nextPage3               | PetSex | nextPage4         | nextPage5     | color | FooterLang1  | FooterLang2 |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch ci chi? | Ci  | 676789876543321 | Basenji  | Yes             | ch anifail anwes? | rhyw eich anifail anwes | Gwryw  | dyddiad geni eich | prif liw eich | Du    | English      |    Cymraeg  |

