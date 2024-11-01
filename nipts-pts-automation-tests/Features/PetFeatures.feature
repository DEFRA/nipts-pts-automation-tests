@Regression
Feature: PetFeatures

Pet Features page in Pets application Portal

Scenario: Enter valid significant feature and verify next page in the application
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
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	Then  select Pets significant features '<featureOption>'
	And   enter Pets significant features '<feature>'
	And   click on continue
	And   verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | featureOption | feature    | nextPage2             |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Oes           | Shiny hair | Gwiriwch eich atebion |

Scenario: Select no option on significant feature and verify next page in the application
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
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	Then  select Pets significant features '<featureOption>'
	And   click on continue
	And   verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | featureOption | nextPage2             |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Nac oes       | Gwiriwch eich atebion |

Scenario: Validate error messages for not selecting any option on significant feature page
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
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | features | errorMessage                                                       |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Oes      | Dwedwch a oes gan eich anifail anwes unrhyw nodweddion arwyddocaol |

	Scenario: Validate error messages for not entering feature details on significant feature page
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
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	Then  select Pets significant features '<featureOption>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | featureOption | errorMessage                                       |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Oes      | Disgrifiwch nodwedd arwyddocaol eich anifail anwes |



	Scenario: Validate error messages for more than 300 chars on significant feature page
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
	When  click on continue
	Then  I have selected an option as '<Pet>' for pet
	And   click on continue
	When  Select breed of your pet '<PetBreed>'
	Then  click on continue
	When  Enter name of your pet '<PetName>'
	Then  click on continue
	When  Select Pet Sex option '<PetSex>'
	Then  click on continue 
    Then  enter the pet date of birth
	And   click on continue
	Then  Select pet color as '<color>'
	And   click on continue
	And   verify next page '<nextPage1>' is loaded
	Then  select Pets significant features '<featureOption>'
	And   enter Pets significant features '<feature>'
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | featureOption | feature | errorMessage                                                                                |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Oes           | ABCDEFGHIJKLMNOPHDJHGDFJKGFDKJBVKJDFNBKJFDHGKJSDHFGKDJHFKJSDHFKJHDSKJFHDKJHKJDHFKDHGJGJHSDFVJSDHFJDBFJEDDIUFGEISEHFKSDNFSBDFJFGFGFGHGHDHBVCJXCVKJDFGVKDFDGFVJHMDBFVJDFBVDFBVJHDFBVJDFBVJDFBVKJJHDFVJHDFVFDVDFVFDVFDVDFVDFVDFVDFNVKJDFBVJHDFJVHBDFJHJHDFVJHDFBVJHDDFGFDHGFHGJHJGHFTYTRYRDGDFGERTEERGRDFGDFGFDH        | Disgrifiwch nodwedd arwyddocaol eich anifail anwes, gan ddefnyddio 300 o gymeriadau neu lai |


