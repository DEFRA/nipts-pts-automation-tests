@Regression
Feature: PetFeatures

Pet Features page in Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

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
	Then  enter Pets significant features '<features>'
	And   click on continue
	And   verify next page '<nextPage2>' is loaded

	Examples: 
	| logininfo | nextPage                                        | nextPage1                                                 | Pet | MicrochipNumber | PetBreed | MicrochipOption | PetName | PetSex | color | features | nextPage2                                   |
	| test2     | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol? | Dog | 676789876543321 | Pug      | Oes             | toto    | Gwryw  | Coch  | Nac oes  | Check your answers and sign the declaration |


