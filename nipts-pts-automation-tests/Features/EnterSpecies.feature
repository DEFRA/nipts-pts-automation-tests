@Regression
Feature: Enter Species

Sign in to Pets application Portal

Background: 
	Given that I navigate to the Pets application portal

Scenario: Select species on Pets Application Portal Page in the WELSH language
	Then  verify next page '<nextPage>' is loaded
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage1>' is loaded
	When  click on Apply for a document
	And   select 'Yes' on Personal Details page
	When  click on continue english
	Then  verify next page '<nextPage2>' is loaded
	And   I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When  click on continue english
	Then  verify next page '<nextPage3>' is loaded
	And   I have provided date of PETS microchipped
	When  click on continue english
	Then  verify next page '<nextPage4>' is loaded
	Then  click on Welsh language
	When  click on continue
	Then  verify error message '<errorMessage>' on Enter Species page
	Then  verify displayed language at page footer '<DisplayedLang2>'
	And   I have selected an option as '<Pet>' for pet
	When  click on continue
	Then  verify next page '<nextPage5>' is loaded

	Examples: 
	| nextPage                         | logininfo | nextPage1                     | nextPage2                 | MicrochipOption | MicrochipNumber | nextPage3                                       | nextPage4                         | errorMessage        | DisplayedLang2 | Pet | nextPage5               |
	| Sign in using Government Gateway | test2     | Lifelong pet travel documents | Is your pet microchipped? | Yes             | 767876543212332 | When was your pet microchipped or last scanned? | Is your pet a dog, cat or ferret? | Dwedwch a ydych chi | English        | Dog | What breed is your dog? |