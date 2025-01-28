@ChangeDetails @APGBRegression 
Feature: Update Pet Owner Details

Modify the Pet owner details before submitting the application

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Modify Name of the pet owner By Registered User with details correct
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
	And I have clicked the change option for the 'Name' from Pet owner details section
	And I have modified the pet owner name with the value of '<UpdatedFullName>'
	When I click continue button from pet owner name page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | UpdatedFullName | UpdatedPostCode |
	| PetCats's |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cat | Cat     | Female | White | Yes                   | NewPetCat       | CV1 4PY         |
	| PetDogs's |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Dog | Dog     | Male   | Red   | Yes                   | NewPetDog       | CV1 4PY         |

Scenario Outline: Modify Address of the pet owner By Registered User with details correct
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
	And I have clicked the change option for the 'Address' from Pet owner details section
	And I have modified the pet owner postcode and address with the value of '<UpdatedPostCode>' and phone number '<PhoneNumber>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 2 from address list
	When I click continue button from postcode search page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | UpdatedPostCode |
	| PetCats's |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cat | Cat     | Female | White | Yes                   | CV2 4NZ         |

Scenario Outline: Modify Phone number of the pet owner By Registered User with details correct
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
	And I have clicked the change option for the 'Phone number' from Pet owner details section
	And I have modified the pet owner phone number with the value of '<UpdatedPhoneNumber>'
	When I click continue button from What is your phone number page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | UpdatedPhoneNumber |
	| PetCats's |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cat | Cat     | Female | White | Yes                   | 02012345679        |
	| PetDogs's |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Dog | Dog     | Female | Red   | Yes                   | 02012345679        |

Scenario Outline: Modify Name of the pet owner By Registered User with details correct - Ferret
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
	And I have clicked the change option for the 'Name' from Pet owner details section
	And I have modified the pet owner name with the value of '<UpdatedFullName>'
	When I click continue button from pet owner name page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color     | IsSignificantFeatures | UpdatedFullName | UpdatedPostCode |
	| PetFerret |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ferret | Ferret  | Female | Chocolate | Yes                   | NewPetFerret    | CV1 4PY         |

Scenario Outline: Modify Phone number of the pet owner By Registered User with details correct - Ferret
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
	And I have clicked the change option for the 'Phone number' from Pet owner details section
	And I have modified the pet owner phone number with the value of '<UpdatedPhoneNumber>'
	When I click continue button from What is your phone number page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color     | IsSignificantFeatures | UpdatedPhoneNumber |
	| PetFerret |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ferret | Ferret  | Female | Chocolate | Yes                   | 02012345679        |