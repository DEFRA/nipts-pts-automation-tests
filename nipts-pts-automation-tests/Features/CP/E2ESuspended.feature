@CPRegression
Feature: E2ESuspended

As a PTS port checker I want ot check E2E Suspended journey for GB to NI

Scenario Outline: Check Pending application status for Suspensed application user
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo 'test4'
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
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
	Then I should redirected to the What breed is your '<Pet>' page
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
	And I should see the application on pets in 'Pending' status
	And click on signout button and verify the signout message on pets
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
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
	And I should see the application status in 'Pending'
	And I should see the application subtitle 'Your application summary'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                   | ApplicationRadio             | 
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Loch Ryan to Belfast (Stena) | Search by application number |

Scenario Outline: Check Unsuccessful application status for Suspensed application user
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo 'test4'
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
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
	Then I should redirected to the What breed is your '<Pet>' page
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
	And I should see the application on pets in 'Pending' status
	When Reject an application via backend
	And click on signout button and verify the signout message on pets
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
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
	And I should see the application status in 'Unsuccessful'
	And I should see the application subtitle 'Your application summary'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                   | ApplicationRadio             | 
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Loch Ryan to Belfast (Stena) | Search by application number |


Scenario Outline: Check Approved application status for Suspensed application user
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo 'test4'
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
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
	Then I should redirected to the What breed is your '<Pet>' page
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
	And I should see the application on pets in 'Pending' status
	When Approve an application via backend
	And I should see the application in 'Approved' status
	And click on signout button and verify the signout message on pets
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                   | ApplicationRadio     | ApplicationRadio1            |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Loch Ryan to Belfast (Stena) | Search by PTD number | Search by application number |


Scenario Outline: Check Revoked application status for Suspensed application user
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo 'test4'
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
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
	Then I should redirected to the What breed is your '<Pet>' page
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
	And I should see the application on pets in 'Pending' status
	When Approve an application via backend
	And I should see the application in 'Approved' status
	When Revoke Approved application via backend
	And click on signout button and verify the signout message on pets
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                   | ApplicationRadio     | ApplicationRadio1            |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Loch Ryan to Belfast (Stena) | Search by PTD number | Search by application number |

Scenario Outline: Create application via backend and check status while Suspensed 
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
	And Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	Then I should see the application status in 'Approved'
	When Suspend an Authorised application via backend
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Suspended'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
    And I verify continue button not displayed on search result page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Suspended'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
    And I verify continue button not displayed on search result page
	And Approve suspended application via backend
	And I click search button from footer
	Then I navigate to Find a document page
	When I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	And I click search button
	Then I should see the application status in 'Approved'
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Reference number of the application
	When I click search button
	And I should see the application status in 'Approved'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     | ApplicationRadio1            |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number | Search by application number |

Scenario Outline: Check Cat offline application status while Suspensed
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an offline application via backend for 'Cat'
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	And I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	When Suspend an Authorised application via backend
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Suspended'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
    And I verify continue button not displayed on search result page
	And Approve suspended application with PTDNumber via backend
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	Then I should see the application status in 'Approved'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Check Ferret offline application status while Suspensed
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an offline application via backend for 'Ferret'
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	And I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	When Suspend an Authorised application via backend
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Suspended'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
    And I verify continue button not displayed on search result page
	And Approve suspended application with PTDNumber via backend
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	Then I should see the application status in 'Approved'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |
