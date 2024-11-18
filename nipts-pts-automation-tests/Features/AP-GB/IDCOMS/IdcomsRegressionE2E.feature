@Idcoms @APGBRegression 
Feature: Idcoms Regression E2E

Create a PETS travel document for the travel from Great Britain to Northern Ireland

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Verify if a Caseworker can change the status of the case from Open to Pending
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	Then the status is 'Open'
	When I mark the application to 'Pending'
	Then the status is 'Pending'

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | Yes                   |
	| PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | Tortoiseshell | No                    |

Scenario Outline: Verify if a Caseworker can change the status of the case from Open to Pending and add notes to the case - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	When I add notes as 'Notes Title' and 'Notes Body'
	Then I dont see Duplicate Microchip Notification
	Then the status is 'Open'
	When I mark the application to 'Pending'
	Then the status is 'Pending'
	And I cannot edit the field 'Town'

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |


Scenario Outline: Verify the email subject for Rejection email
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	And I Fail the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then I verify the copy of the 'REJECTION' Email in Timeline

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Verify the email subject for revoked email
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	And I Pass the Microchip check
	And I go back
	And I 'Authorise' the application
	And I assign the application to myself
	And I 'Revoke' the application with reason 'Pet Deceased'
	Then I verify the copy of the 'REVOCATION' Email in Timeline

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Verify the email subject for approved email
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to 'Shukla Vishal' another user
	And I assign the application to myself
	And I Pass the Microchip check
	And I go back
	And I 'Authorise' the application
	Then I verify the copy of the 'APPROVED' Email in Timeline

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Verify the email subject of the confirmation email
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	Then I verify the copy of the 'CONFIRMATION' Email in Timeline

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Verify if a Caseworker flags an existing case for further investigation
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	And I marked the case as Pending
	And I switched to PETS Application
	And I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Verify the message banner at the top of the application page - duplicate MC number
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And enter microchip number as <MicrochipNumber>
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	Then I do see Duplicate Microchip Notification

Examples:
	| FullName |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| PetCat's |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | White | No                    |

Scenario Outline: Verify if the caseworker can add notes to the case
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
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
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to 'Vishal Shukla' another user
	And I assign the application to myself
	When I add notes as 'Notes Title' and 'Notes Body'

Examples:
	| FullName |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| PetCat's |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | White | No                    |
	| PetDog's |  No                       | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | No                   |


Scenario Outline: Verify the error message when the caseworker Authorises an application with a duplicate MC number
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And enter microchip number as <MicrochipNumber>
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox
	And I have ticked the I agree to Defra's privacy policy checkbox
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	Then I do see Duplicate Microchip Notification
	When I Pass the Microchip check
	And I go back
	Then I See an error 'Another Authorised application exists with this microchip number' when Authorising the application

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |
