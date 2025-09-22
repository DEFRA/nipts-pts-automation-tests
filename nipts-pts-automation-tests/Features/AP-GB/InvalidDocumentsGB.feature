@Regression
Feature: InvalidDocumentsGB

Verify GB Invalid documents on Application Portal



Scenario Outline: Verify canceled status and PTD on Invalid documents page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When I click Apply for a document button
	Then I should navigate to the Pets Owner details correct page
	When I selected the radio button '<PetsOwnerDetails>' option and continue
	Then I should navigate to the Is your pet microchipped page
	And I selected the radio button '<MicroChipNumberOn>' option
	And provided microchip number as'<MicroChipNumber>' and continue
	Then I should navigate to When was your pet microchipped page
	When I have provided the date of PETS microchipped and continue
	Then I should navigate to the Is your pet a cat, dog or ferret page
	And I have selected radio button as '<Pet>' and continue
	Then I should navigate to the What is your pet's name page
	And  I provided the Pets name as '<PetName>'
	When  click on continue
	Then I should navigate to the What sex is your pet page
	When I have selected the radio button as '<Gender>' for sex option and continue
	Then I should navigate to the Do you know your pet's date of birth page
	When I have provided date of birth for pet and continue
	Then I should navigate to the What is the main colour of your '<Pet>' page
	When I have selected the radio button as '<PetColor>' for pet's
	Then I provided other color of the pet as "Unique Color"
	When I click on continue button from What is the main colour of your pet page
	Then I should navigate to the Does your pet have any significant features page
	When I have selected '<IsSignificanteFeatures>' for significant features and continue
	Then I navigate to the Check your answers and sign the declaration page
	And I have ticked the checkbox I agree to the declaration
	When I click Send Application button in Declaration page
	Then I should redirect to the Application submitted page
	And   I can see the unique application reference number
	When  I have clicked the View all your lifelong pet travel documents link
	Then   I should see the application on pets in 'Pending' status
	When  I have clicked the View hyperlink from home page
	Then  verify next page 'application summary' is loaded
	When  Approve an application via backend
	Then  I click on Back button in Pets Application
	And   I should see the application in 'Approved' status
	When  Revoke Approved application via backend
	Then  I should not see the application in the Dashboard
	When  click View Invalid documents link in WELSH
	Then  verify next page 'Invalid documents' is loaded
	Then  verify order of new application is displayed at the top of the page 
	Then  I should see the application in 'Cancelled' status 
	When  I have clicked the View hyperlink from invalid documents page
	Then  verify next page 'Lifelong pet travel document' is loaded
	And   verify status on the application summary as 'Status' 'Cancelled' on GB Invalid documents page
	And   verify print and download links are not displayed on PTD
	And   click on signout button and verify the signout message on pets

Examples:
	| logininfo | PetsOwnerDetails | MicroChipNumberOn | MicroChipNumber | Pet         | PetName         | Gender          | PetColor | IsSignificanteFeatures |
	| test5     | Yes              | Yes               | 123456789123456 | Ferret      | The Ferret      | Female          | Other    | Yes                    |

Scenario Outline: Verify unsuccessful status and PTD on Invalid documents page
Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When I click Apply for a document button
	Then I should navigate to the Pets Owner details correct page
	When I selected the radio button '<PetsOwnerDetails>' option and continue
	Then I should navigate to the Is your pet microchipped page
	And I selected the radio button '<MicroChipNumberOn>' option
	And provided microchip number as'<MicroChipNumber>' and continue
	Then I should navigate to When was your pet microchipped page
	When I have provided the date of PETS microchipped and continue
	Then I should navigate to the Is your pet a cat, dog or ferret page
	And I have selected radio button as '<Pet>' and continue
	Then I should navigate to the What is your pet's name page
	And  I provided the Pets name as '<PetName>'
	When  click on continue
	Then I should navigate to the What sex is your pet page
	When I have selected the radio button as '<Gender>' for sex option and continue
	Then I should navigate to the Do you know your pet's date of birth page
	When I have provided date of birth for pet and continue
	Then I should navigate to the What is the main colour of your '<Pet>' page
	When I have selected the radio button as '<PetColor>' for pet's
	Then I provided other color of the pet as "Unique Color"
	When I click on continue button from What is the main colour of your pet page
	Then I should navigate to the Does your pet have any significant features page
	When I have selected '<IsSignificanteFeatures>' for significant features and continue
	Then I navigate to the Check your answers and sign the declaration page
	And I have ticked the checkbox I agree to the declaration
	When I click Send Application button in Declaration page
	Then I should redirect to the Application submitted page
	And   I can see the unique application reference number
	When  I have clicked the View all your lifelong pet travel documents link
	Then   I should see the application on pets in 'Pending' status
	When  I have clicked the View hyperlink from home page
	Then  verify next page 'application summary' is loaded
	When  Reject an application via backend
	Then  I click on Back button in Pets Application
	When  click View Invalid documents link in WELSH
	Then  verify next page 'Invalid documents' is loaded
	Then  verify order of new application is displayed at the top of the page 
	Then  I should see the application in 'Unsuccessful' status 
	When  I have clicked the View hyperlink from invalid documents page
	Then  verify next page 'application summary' is loaded
	And   verify status on the application summary as 'Status' 'Unsuccessful' on GB Invalid documents page
	And   verify print and download links are not displayed on PTD
	And   click on signout button and verify the signout message on pets

Examples:
	| logininfo | PetsOwnerDetails | MicroChipNumberOn | MicroChipNumber | Pet         | PetName         | Gender          | PetColor | IsSignificanteFeatures |
	| test5     | Yes              | Yes               | 123456789123456 | Ferret      | The Ferret      | Female          | Other    | Yes                    |


	