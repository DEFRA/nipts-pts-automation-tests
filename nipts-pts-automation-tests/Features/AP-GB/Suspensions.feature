@APGBRegression 

Feature: Suspensions

Create a PETS travel document for the suspended user

Scenario Outline: Verify application status for suspended state in the PTD table
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When  sign in with valid credentials with logininfo '<logininfo>'
	And I click Create a new pet travel document button
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
	Then I should redirected to the What breed is your '<Pet>' page
	And I have provided freetext breed as '<Breed>'
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
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
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page
	When Approve an application via backend
	Then I click on Back button in Pets Application
	And I should see the application on pets in 'Approved' status
	When Suspend an Authorised application via backend
	When I have clicked the View hyperlink from home page
	Then I click on Back button in Pets Application
	Then I should see the application on pets in 'Suspended' status
	When I have clicked the View hyperlink from home page
	Then I have verified microchip details in summary page
	And I have verified pet details in summary page
	And Approve suspended application with PTDNumber via backend
	And I click on Back button in Pets Application
	Then I should see the application on pets in 'Approved' status
	And click on signout button and verify the signout message on pets

Examples:
	| logininfo | FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| test5     | PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | White | No                    |
	

Scenario Outline: Verify warning message and apply button for suspended user on homepage
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When  sign in with valid credentials with logininfo '<logininfo>'
	And I click Create a new pet travel document button
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
	Then I should redirected to the What breed is your '<Pet>' page
	And I have provided freetext breed as '<Breed>'
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
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
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page
	When Approve an application via backend
	Then I click on Back button in Pets Application
	And I should see the application on pets in 'Approved' status
	When Suspend an Authorised application via backend
	When I have clicked the View hyperlink from home page
	Then I click on Back button in Pets Application
	Then I should see the application on pets in 'Suspended' status
	Then I verify warning message 'You have been suspended from this scheme and cannot use your pet travel documents' on homepage for suspended user
	And verify Apply for a document button is not displayed for suspended user
	When I have clicked the View hyperlink from home page
	And Approve suspended application with PTDNumber via backend
	Then I click on Back button in Pets Application
	Then I should see the application on pets in 'Approved' status
	And click on signout button and verify the signout message on pets

Examples:
	| logininfo | FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| test5     | PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | White | No                    |


Scenario Outline: Verify suspended status, print & download links on suspended PTD
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When  sign in with valid credentials with logininfo '<logininfo>'
	And I click Create a new pet travel document button
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
	Then I should redirected to the What breed is your '<Pet>' page
	And I have provided freetext breed as '<Breed>'
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
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page
	When Approve an application via backend
	Then I click on Back button in Pets Application
	And I should see the application on pets in 'Approved' status
	When Suspend an Authorised application via backend
	When I have clicked the View hyperlink from home page
	Then verify status on the application summary as 'Status' 'Suspended'
	And verify Issuing Authority is not displayed on suspended user PTD
	And verify print and download links are not displayed on PTD
	And Approve suspended application with PTDNumber via backend
	And click on signout button and verify the signout message on pets

Examples:
	| logininfo | FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| test5     | PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cat | Cat     | Female | White | No                    |
	

