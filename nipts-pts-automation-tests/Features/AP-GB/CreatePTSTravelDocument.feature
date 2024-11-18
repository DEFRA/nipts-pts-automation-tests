@PETS @APGBRegression 
Feature: CreatePTSTravelDocument

Create a PETS travel document for the travel from Great Britain to Northern Ireland
Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	And sign in with valid credentials with logininfo
	
Scenario Outline: Create PETS Travel Document By Registered User for Dog and Cat
	Then I should navigate to Lifelong pet travel documents page
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
	Then I should navigate to What breed is your '<Pet>' page
	And I have selected from the dropdown as '<Breed>' for pet's and continue
	Then I should navigate to the What is your pet's name page
	And I have provided the Pets name as '<PetName>' and continue
	Then I should navigate to the What sex is your pet page
	When I have selected the radio button as '<Gender>' for sex option and continue
	Then I should navigate to the Do you know your pet's date of birth page
	When I have provided date of birth for pet and continue
	Then I should navigate to the What is the main colour of your '<Pet>' page
	When I have selected the radio button as '<PetColor>' for pet's and continue
	Then I should navigate to the Does your pet have any significant features page
	When I have selected '<IsSignificanteFeatures>' for significant features and continue
	Then I navigate to the Check your answers and sign the declaration page
	And I have ticked the checkbox I agree to the declaration
	When I click Send Application button in Declaration page
	Then I should redirect to the Application submitted page
	And I can see the application reference number


Examples:
	| PetsOwnerDetails | MicroChipNumberOn | MicroChipNumber | Pet | Breed        | PetName | Gender | PetColor | IsSignificanteFeatures |
	| Yes              | Yes               | 123456789123456 | Dog | Afghan Hound | The Dog | Male   | Black    | Yes                    |
	| Yes              | Yes               | 123456789123456 | Cat | Bengal       | The Cat | Female | White    | No                     |

Scenario Outline: Create PETS Travel Document By Registered User for Ferret
	Then I should navigate to Lifelong pet travel documents page
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
	And I have provided the Pets name as '<PetName>' and continue
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
	And I can see the application reference number

Examples:
	| PetsOwnerDetails | MicroChipNumberOn | MicroChipNumber | Pet    | PetName    | Gender | PetColor | IsSignificanteFeatures |
	| Yes              | Yes               | 123456789123456 | Ferret | The Ferret | Female | Other    | Yes                    |

