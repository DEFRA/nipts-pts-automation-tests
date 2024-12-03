@Validations @APGBRegression 
Feature: Microchip Information Validations

Validating the negative scenarios for Microchip Information

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Verify microchipped date should not allows future date
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided future date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should see an error message "Enter a date that is in the past" in pets microchipped or last scanned page
	And I should not be redirected to Is your pet a dog, cat or ferret? page

Examples:
	| FullName |  Are your details correct | MicrochipOption | MicrochipNumber |
	| PetCat's |  Yes                      | Yes             | 123456789123485 |

Scenario Outline: Verify microchipped date should not allows older than 34 years
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided older than expected date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should not be redirected to Is your pet a dog, cat or ferret? page
	And I should see an error message "Enter a date that is less than 34 years ago" in pets microchipped or last scanned page

Examples:
	| FullName |  Are your details correct | MicrochipOption | MicrochipNumber |
	| PetCat's |  Yes                      | Yes             | 123456789123485 |

Scenario Outline: Verify microchipped page validations without selection and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	When I click Continue button from microchipped page
	Then I should see an error message '<ErrorMessage>' in microchipped page
	And I should not be redirected to When was your pet microchipped or last scanned? page
Examples:
	| FullName |  Are your details correct | MicrochipOption | MicrochipNumber | ErrorMessage                        |
	| Pet Dog  |  Yes                      |                 |                 | Select if your pet is microchipped |

Scenario Outline: Verify microchipped page validations and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And enter microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should see an error message '<ErrorMessage>' in microchipped page
	And I should not be redirected to When was your pet microchipped or last scanned? page
Examples:
	| FullName |  Are your details correct | MicrochipOption | MicrochipNumber | ErrorMessage                                 |
	| Pet Dog  |  Yes                      | Yes             |                 | Enter your pet’s 15-digit microchip number   |
	| Pet Dog  |  Yes                      | Yes             | abc123def456fgh |                                              |

Scenario Outline: Verify microchip number should not allows less or more than 15 digits
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And enter microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should not be redirected to When was your pet microchipped or last scanned? page
	And I should see an error message "Enter your pet’s 15-digit microchip number" in Is your pet microchipped page

Examples:
	| FullName |  Are your details correct | MicrochipOption | MicrochipNumber       |
	| PetDog's |  Yes                      | Yes             | 1234567891			 |
	| PetDog's |  Yes                      | Yes             | 1234567891234567      |

Scenario Outline: The date on the microchip should be a future date relative to the pets date of birth
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as '<Pet>' for pets
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided future date of birth from microchip scanned date
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to the What is the main colour of your '<Pet>' page
	And I should see an error message "Enter a date that is before the pet’s microchip date" in pets date of birth page

Examples:
	| FullName |  Are your details correct | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         |
	| PetDog's |  Yes                      | 02012345671 | Yes             | 123456789123458 | Dog | Dog     | Male   | Black         |
	| PetCat's |  Yes                      | 07440345672 | Yes             | 123456789654322 | Cat | Cat     | Female | Tortoiseshell |