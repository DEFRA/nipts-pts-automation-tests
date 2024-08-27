@Regression
Feature: PersonalDetails

Personal Details page in Pets application Portal

@CrossBrowser
Scenario: Verify Personal Details page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	And   click on Apply for a document
	Then  verify next page '<nextPage1>' is loaded
	Then  verify Personal Details for user '<logininfo>'


	Examples: 
	| logininfo | nextPage                                        | nextPage1    |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | manylion chi |

	Scenario: Verify Personal Details page in Welsh and English version
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	Then  verify next page '<nextPage2>' is loaded
	When  click on English language 
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1                 | nextPage2    |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Are your details correct? | manylion chi |


	Scenario: Verify Error message on not selecting option before continue on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	When  click on continue
	Then  verify error message '<errorMessage>' on Personal Details page


	Examples: 
	| logininfo | nextPage                                        | errorMessage                   |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Dwedwch a yw eich manylion chi |

	Scenario: Verify next page after selecting Yes on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1                 |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Is your pet microchipped? |

	
	Scenario: Verify next page after selecting No on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Nac ydyn' on Personal Details page
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1 |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Beth yw   |


	Scenario: Verify back link on Personal Details page 
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   click on back
	Then  verify next page '<nextPage1>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1                                       |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Dogfennau teithio gydol oes i anifeiliaid anwes |