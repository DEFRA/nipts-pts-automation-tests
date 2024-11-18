@PETS @APGBRegression 
Feature: PetsOwnerAddress

Create a PETS travel document to provide address when PETS Owner details are incorrect

Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

Scenario Outline: Create PETS Travel Document By PostCode Address User
	Then I should navigate to Lifelong pet travel documents page
	When I click Apply for a document button
	Then I should navigate to the Pets Owner details correct page
	When I selected the radio button '<PetsOwnerDetails>' option and continue
	Then I should navigate to Pets Owner full name page
	When I provided '<PetsOwnerName>' and continue
	Then I should navigate to Pets Owner address postcode page
	When I provide Pets Owner '<PostCode>' and click find address
	Then I should navigate to Pets Owner address dropdown page
	When I select Pets Owner Address from dropdown and continue
	Then I should navigate to Pets Owner phone number page
	When I provide Pets Owner '<PhoneNumber>' and continue
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
	| PetsOwnerDetails | PetsOwnerName		| PostCode	| PhoneNumber	 | MicroChipNumberOn | MicroChipNumber | Pet | Breed        | PetName | Gender | PetColor | IsSignificanteFeatures |
	| No               | DEFRA PTS Service  | RM10 8DP	| 07401659856	 | Yes               | 123456789123456 | Dog | Afghan Hound | The Dog | Male   | Black    | Yes                    |

Scenario Outline: Create PETS Travel Document By Manually Address User
	Then I should navigate to Lifelong pet travel documents page
	When I click Apply for a document button
	Then I should navigate to the Pets Owner details correct page
	When I selected the radio button '<PetsOwnerDetails>' option and continue
	Then I should navigate to Pets Owner full name page
	When I provided '<PetsOwnerName>' and continue
	Then I should navigate to Pets Owner address postcode page
	When I I click on Enter the address manually link from postcode page
	Then I should navigate to Pets Owner manually address page
	When I fill in '<AddressLineOne>', '<AddressLineTwo>', '<TownOrCity>', '<County>', '<PostCode>'and continue
	Then I should navigate to Pets Owner phone number page
	When I provide Pets Owner '<PhoneNumber>' and continue
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
	| PetsOwnerDetails | PetsOwnerName     | AddressLineOne | AddressLineTwo | TownOrCity | County  | PostCode      |  PhoneNumber | MicroChipNumberOn | MicroChipNumber | Pet | Breed        | PetName | Gender | PetColor | IsSignificanteFeatures |
	| No               | DEFRA PTS Service | Flat-1			| 12 Reed Road	 | Dagenham   | Essex   | RM10 8DP      | 07401659856  | Yes               | 123456789123456 | Dog | Afghan Hound | The Dog | Male   | Black    | Yes                    |