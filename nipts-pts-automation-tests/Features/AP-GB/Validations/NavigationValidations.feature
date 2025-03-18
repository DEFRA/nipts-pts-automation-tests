@APGBRegression 
Feature: NavigationValidations

Validate navigation on PETS travel document

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Validate navigation for PTD application
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
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as '<Pet>' for pets
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to the Check your answers and sign the declaration page
 
Examples:
	| FullName  | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures |
	| PetDog's  | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | Yes                   |

Scenario Outline: Validate Back links on PTD application
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
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	When I click on Back button
	Then I should navigate to the Does your pet have any significant features page
	When I click on Back button
	Then I should navigate to the What is the main colour of your '<Pet>' page
	When I click on Back button
	Then I should navigate to the Do you know your pet's date of birth page
	When I click on Back button
	Then I should navigate to the What sex is your pet page
	When I click on Back button
	Then I should navigate to the What is your pet's name page
	When I click on Back button
	Then I should navigate to What breed is your '<Pet>' page
	When I click on Back button
	Then I should navigate to the Is your pet a cat, dog or ferret page
	When I click on Back button
	Then I should navigate to When was your pet microchipped page
	When I click on Back button
	Then I should navigate to the Is your pet microchipped page
	When I click on Back button
	Then I should redirected to the Are your details correct page
	When I click on Back button
	Then I should redirected to Apply for a pet travel document page

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | Yes                   |
