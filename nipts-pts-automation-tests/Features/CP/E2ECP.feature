@CPRegression
Feature: E2ECP

As a PTS port checker I want ot check pet travel document applications Status details

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Check PETS Travel Document details By PTD number - status in Approved
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Pass the Microchip check
	#And I go back
	#And I 'Authorise' the application
	#Then the status is changed to 'Authorised'
	#And I click on Back button in Pets Application
	#And I should see the application in 'Approved' status
	#When I have clicked the View hyperlink from home page
	#And I captured Application PTD number
	#And  click on signout button and verify the signout message
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I provided the PTD number of the application
	#When I click search button
	#And I should see the application status in 'Approved'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) |

Scenario Outline: Check PETS Travel Document details By Application number - status in Approved
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Pass the Microchip check
	#And I go back
	#And I 'Authorise' the application
	#Then the status is changed to 'Authorised'
	#And I click on Back button in Pets Application
	#And I should see the application in 'Approved' status
	#When I have clicked the View hyperlink from home page
	#And click on signout button and verify the signout message
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Reference number of the application
	#When I click search button
	#And I should see the application on pets status in 'Approved'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute               |  ApplicationRadio             |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Cairnryan to Larne (P&O) |  Search by application number |

Scenario Outline: Check PETS Travel Document details By Application number - status in Revoked
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	And click on signout button and verify the signout message
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Pass the Microchip check
	#And I go back
	#And I 'Authorise' the application
	#Then the status is changed to 'Authorised'
	#When I assign the application to myself
	#And I 'Revoke' the application with reason 'Owner Left GB'
	#Then the status is changed to 'Revoked'
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Reference number of the application
	#When I click search button
	#And I should see the application status in 'Revoked'

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute               |  ApplicationRadio             |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Cairnryan to Larne (P&O) |  Search by application number |

Scenario Outline: Check PETS Travel Document details By Application number - status in Unsuccessful
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	And click on signout button and verify the signout message
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Fail the Microchip check
	#And I go back
	#And I 'Reject' the application with reason 'Invalid Application'
	#Then the status is changed to 'Rejected'
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Reference number of the application
	#When I click search button
	#And I should see the application status in 'Unsuccessful'

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute               |  ApplicationRadio             |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Cairnryan to Larne (P&O) |  Search by application number |

Scenario Outline: Check PETS Travel Document details By Microchip number - status in Approved
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application on pets in 'AWAITING VERIFICATION' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Pass the Microchip check
	#And I go back
	#And I 'Authorise' the application
	#Then the status is changed to 'Authorised'
	#And I click on Back button in Pets Application
	#And I should see the application in 'Approved' status
	#When I have clicked the View hyperlink from home page
	#And click on signout button and verify the signout message
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Microchip number of the application
	#When I click search button
	#And I should see the application status in 'Approved'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio           |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Loch Ryan to Belfast (Stena)  | Search by microchip number |

Scenario Outline: Check PETS Travel Document details By Microchip number - status in Revoked
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	And click on signout button and verify the signout message
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Pass the Microchip check
	#And I go back
	#And I 'Authorise' the application
	#Then the status is changed to 'Authorised'
	#When I assign the application to myself
	#And I 'Revoke' the application with reason 'Owner Left GB'
	#Then the status is changed to 'Revoked'
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Microchip number of the application
	#When I click search button
	#And I should see the application status in 'Revoked'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio			  |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) | Search by microchip number |

	Scenario Outline: Check PETS Travel Document details By Microchip number - status in Unsuccessful
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	And click on signout button and verify the signout message
	#When I Login to Dynamics application
	#And I opens the application
	#And I assign the application to myself
	#And I Fail the Microchip check
	#And I go back
	#And I 'Reject' the application with reason 'Invalid Application'
	#Then the status is changed to 'Rejected'
	#When I navigate to the port checker application
	#And I click signin button on port checker application
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	#Then I should redirected to port route checke page
	#And I have selected '<Transportation>' radio option
	#And I select the '<FerryRoute>' radio option
	#And I have provided Scheduled departure time
	#When I click save and continue button from route checke page
	#Then I should navigate to Welcome page
	#When I click search button from footer
	#Then I navigate to Find a document page
	#And I click search by '<ApplicationRadio>' radio button
	#And I provided the Microchip number of the application
	#When I click search button
	#And I should see the application status in 'Unsuccessful'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio			  |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) | Search by microchip number |

@CPRegression
Scenario Outline: Check PETS Travel Document details By Reference number - status in AWAITING VERIFICATION
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	Then click on signout button and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for Landing page
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio			    |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) | Search by application number |

@CPRegression
Scenario Outline: Check PETS Travel Document details By Microchip number - status in AWAITING VERIFICATION
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option on pets
	And I provided microchip number as '<MicrochipNumber>' on pets
	When I click Continue button from microchipped page
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned page
	And I have provided date of PETS microchipped on pets
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
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	Then click on signout button and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for Landing page
	#Then I should redirected to the Sign in using Government Gateway page
	#When I have provided the CP credentials and signin
	#And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio			  |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) | Search by microchip number |