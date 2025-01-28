@Regression
Feature: PetMicrochipNumber

Validate Microchip Number page in Pets application Portal

Scenario: Enter valid microchip Number and verify next page in the application
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


	Examples: 
	| logininfo | nextPage                                        | nextPage1                               | MicrochipNumber | MicrochipOption | 
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | ch anifail anwes gael microsglodyn wedi | 676789876543321 | Oes             |

Scenario: Validate microchip Number error message with no option
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  I selected the '<MicrochipOption>' option
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded


	Examples: 
	| logininfo | nextPage                                        | MicrochipOption | nextPage1             | nextPage2                                                        |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Nac oes         | Oes microsglodyn wedi | Trefnwch osod microsglodyn ar eich anifail anwes cyn gwneud cais |

Scenario: Verify error messages on invalid microchip number
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	And   click on continue
	Then  verify error message '<errorMessage>' on Pets


	Examples: 
	| logininfo | nextPage                                        | nextPage1             | MicrochipNumber        | MicrochipOption | errorMessage                                         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes microsglodyn wedi |                        | Yes             | Rhowch rif microsglodyn 15 digid eich anifail anwes  |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes microsglodyn wedi | ABCDEFGHIJKLMNOPHDJHGDFJKGFDKJBVKJDFNBKJFDHGKJSDHFGKDJHFKJSDHFKJHDSKJFHDKJHKJDHFKDHGJGJHSDFVJSDHFJDBFJEDDIUFGEISEHFKSDNFSBDFJFGFGFGHGHDHBVCJXCVKJDFGVKDFDGFVJHMDBFVJDFBVDFBVJHDFBVJDFBVJDFBVKJJHDFVJHDFVFDVDFVFDVFDVDFVDFVDFVDFNVKJDFBVJHDFJVHBDFJHJHDFVJHDFBVJHDDFGFDHGFHGJHJGHFTYTRYRDGDFGERTEERGRDFGDFGFDHFGHFGH | Yes             | Rhowch rif 15 digid, gan ddefnyddio rhifau yn unig   |

Scenario: Verify WAF error message on microchip number
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1             | MicrochipNumber        | MicrochipOption | nextPage2                                         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes microsglodyn wedi | '-'                    | Yes             | You cannot access this page or perform this action|

Scenario: Verify error messages for not selecting any option on microchip number
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on Welsh language 
	Then  verify next page '<nextPage>' is loaded
	When  click on Apply for a document
	And   select 'Ydyn' on Personal Details page
	And   click on continue
	Then  verify next page '<nextPage1>' is loaded
	When  I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	And   click on continue
	Then  verify next page '<nextPage2>' is loaded


	Examples: 
	| logininfo | nextPage                                        | nextPage1             | MicrochipNumber        | MicrochipOption | nextPage2                                         |
	| test      | Dogfennau teithio gydol oes i anifeiliaid anwes | Oes microsglodyn wedi | '-'                    | Yes             | You cannot access this page or perform this action|
