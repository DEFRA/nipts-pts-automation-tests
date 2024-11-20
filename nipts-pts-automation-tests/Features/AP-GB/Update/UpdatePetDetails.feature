@ChangeDetails @APGBRegression 
Feature: Update Pet Details

Modify the Pet details before submitting the application

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Modify PETS Name By Registered User with details correct - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for Ferret 'Name' from Pet details section
	And I have modified the pet name as '<UpdatedName>'
	When I click on continue button from What is your pet's name page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | UpdatedName | Gender | Color     | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | NewFerret   | Female | Chocolate | No                    |

Scenario Outline: Modify Species of the pet By Registered User with details correct
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
	And I have clicked the change option for the 'Species' from Pet details section
	And I have modified the species type as '<UpdatedSpecies>'
	When I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of colour '<UpdatedColor>' and breed <UpdatedBreedIndex>
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page

Examples:
	| FullName |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | UpdatedSpecies | UpdatedColor   | UpdatedBreedIndex |
	| PetDog   |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cat | Cat     | Female | White | Yes                   | Dog            | Gold or yellow | 3                 |
	| PetCat   |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Dog | Dog     | Female | Red   | Yes                   | Cat            | White          | 3                 |

Scenario Outline: Modify breed of the pet By Registered User with details correct
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
	And I have clicked the change option for the 'Breed' from Pet details section
	And I have modified the pets breed with the index value of '<UpdatedBreedIndex>'
	When I click continue button from What breed is your dog page till reaching declaration page
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page

Examples:
	| FullName |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | UpdatedBreedIndex |
	| PetCat   |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cat | Cat     | Female | White | Yes                   | 3                 |
	| PetDog   |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Dog | Dog     | Female | Red   | Yes                   | 3                 |

Scenario Outline: Modify PETS Sex By Registered User with details correct - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>' 
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for Ferret 'Sex' from Pet details section
	And I have modified the pets sex as '<UpdatedSex>'
	When I click on continue button from What sex is your pet page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | UpdatedSex | Color    | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Male   | Female     | Cinnamon | No                    |

Scenario Outline: Modify PETS date of birth By Registered User with details correct - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for Ferret 'Date of birth' from Pet details section
	And I have modified the pets date of birth by adding '-5' days
	When I click on continue button from What is your pet's date of birth page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | UpdatedSex | Color     | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Male   | Female     | Champagne | No                    |

Scenario Outline: Modify PETS colour By Registered User with details correct - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option
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
	And I have clicked the change option for Ferret 'Colour' from Pet details section
	And I have modified the pets colour as '<UpdatedColor>'
	When I click on continue button from What is the main colour of your pet page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | UpdatedColor | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Male   | Sable | Silver       | No                    |

Scenario Outline: Modify PETS significant features By Registered User with details correct - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for Ferret 'Significant features' from Pet details section
	And I have modified the pets significant feature as '<UpdatedSignificantFeatures>'
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures | UpdatedSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Male   | Black | No                    | Yes                        |

Scenario Outline: Modify PETS colour By Registered User with details correct
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for the 'Colour' from Pet details section
	And I have modified the pets colour as '<UpdatedColor>'
	When I click on continue button from What is the main colour of your pet page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | UpdatedColor | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Dog    | Dog     | Male   | Black | Red          | No                    |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat    | Cat     | Male   | Black | Ginger       | No                    |
	
Scenario Outline: Modify PETS date of birth By Registered User with details correct
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for the 'Date of birth' from Pet details section
	And I have modified the pets date of birth by adding '-5' days
	When I click on continue button from What is your pet's date of birth page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | UpdatedSex | Color     | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Dog    | Dog     | Male   | Female     | Black     | No                    |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat    | Cat     | Female | Male       | Black     | No                    |

Scenario Outline: Modify PETS Sex By Registered User with details correct
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>' 
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for the 'Sex' from Pet details section
	And I have modified the pets sex as '<UpdatedSex>'
	When I click on continue button from What sex is your pet page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | UpdatedSex | Color    | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Dog    | Dog     | Male   | Female     | Black    | No                    |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat    | Cat     | Female | Male       | Black    | No                    |

Scenario Outline: Modify PETS Name By Registered User with details correct
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for the 'Name' from Pet details section
	And I have modified the pet name as '<UpdatedName>'
	When I click on continue button from What is your pet's name page till reaching declaration page
	Then I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | UpdatedName | Gender | Color     | IsSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Dog    | Dog     | NewDog      | Female | Red       | No                    |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat    | Cat     | NewCat      | Male   | Black     | No                    |

Scenario Outline: Modify PETS significant features By Registered User with details correct
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
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
	And I have clicked the change option for the 'Significant features' from Pet details section
	And I have modified the pets significant feature as '<UpdatedSignificantFeatures>'
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have verified pet details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page

Examples:
	| FullName       |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures | UpdatedSignificantFeatures |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Dog    | Dog     | Male   | Black | No                    | Yes                        |
	| PET-Owner-Name |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat    | Cat     | Male   | Black | Yes                   | No                         |

Scenario Outline: Modify Species of the pet By Registered User with details correct - Ferret
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
	And I have clicked the change option for Ferret 'Species' from Pet details section
	And I have modified the species type as '<UpdatedSpecies>'
	When I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of colour '<UpdatedColor>' and breed <UpdatedBreedIndex>
	Then I have verified microchip details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
Examples:
	| FullName  |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color     | IsSignificantFeatures | UpdatedSpecies | UpdatedColor   | UpdatedBreedIndex |
	| PetFerret |  Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ferret | Ferret  | Female | Chocolate | Yes                   | Dog            | Gold or yellow | 3                 |
