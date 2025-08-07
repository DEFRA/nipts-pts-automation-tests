Feature: InvalidDocuments

Verify Invalid documents on Application Portal



Scenario Outline: Verify canceled status and PTD on Invalid documents page in WELSH
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  I should redirected to Apply for a pet travel document page
	When  I click Create a new pet travel document button
	Then  I should redirected to the Are your details correct page
	Then  click on Welsh language
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue
	Then  I provided the full name of the pet keeper as '<FullName>'
	And   click on continue
	And   I provided the postcode '<PostCode>'
	When  I click Search button
	Then  I should see a list of address in dropdownlist
	And   I select the index 1 from address list
	And   click on continue
	Then  I provided the phone number '<PhoneNumber>'
	And   click on continue
	Then  I selected the '<MicrochipOption>' option
	And   I provided microchip number as '<MicrochipNumber>' on pets
	When  click on continue
	Then  verify next page '<nextpage>' is loaded
	And   I have provided date of PETS microchipped
	When  click on continue
	Then  verify next page '<nextpage1>' is loaded
	And   I have selected an option as '<Pet>' for pets
	When  click on continue
	Then  verify next page '<nextpage2>' is loaded
	And   Select breed of your pet '<PetBreed>'
	When  click on continue
	Then  verify next page '<nextpage3>' is loaded
	And   I provided the Pets name as '<PetName>'
	When  click on continue
	Then  verify next page '<nextpage4>' is loaded
	When  Select Pet Sex option '<Gender>'
	When  click on continue
	Then  verify next page '<nextpage5>' is loaded
	And   I have provided date of birth
	When  click on continue
	Then  verify next page '<nextpage6>' is loaded
	And   I have selected the option as '<Color>' for color
	When  click on continue
	Then  verify next page '<nextpage7>' is loaded
	And   select Pets significant features '<IsSignificantFeatures>'
	When  click on continue
	Then  verify next page '<nextpage8>' is loaded
	And   I have ticked the I agree to the declaration checkbox
	Then  click Accept and Send button from Declaration page
	Then  verify next page '<nextpage9>' is loaded
	And   I can see the unique application reference number
	When  click on View all lifelong pet travel document link
	Then  verify next page '<nextpage10>' is loaded
	And   I should see the application on pets in 'Yn aros' status
	When  I have clicked the View hyperlink from home page
	Then  verify next page 'Crynodeb o' is loaded
	When  Approve an application via backend
	Then  click on back
	And   I should see the application in 'cymeradwyo' status
	When  Revoke Approved application via backend
	Then   I should not see the application in the Dashboard
	When  click View Invalid documents link in WELSH
	Then  verify next page 'Dogfennau annilys' is loaded
	Then  verify order of new application is displayed at the top of the page 
	Then  I should see the application in 'canslo' status 
	When  I have clicked the View hyperlink from invalid documents page
	Then  verify next page 'Dogfen teithio' is loaded
	Then  verify status on the application summary as 'Statws' 'canslo' on Invalid documents page 
	And   verify print and download links are not displayed on PTD
	And   click on signout button and verify the signout message on pets

Examples:

	| logininfo | FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10              |
	| test5     | Updated Name | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Basenji  | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Verify unsuccessful status and PTD on Invalid documents page in WELSH
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  I should redirected to Apply for a pet travel document page
	When  I click Create a new pet travel document button
	Then  I should redirected to the Are your details correct page
	Then  click on Welsh language
	When  select 'Nac ydyn' on Personal Details page
	And   click on continue
	Then  I provided the full name of the pet keeper as '<FullName>'
	And   click on continue
	And   I provided the postcode '<PostCode>'
	When  I click Search button
	Then  I should see a list of address in dropdownlist
	And   I select the index 1 from address list
	And   click on continue
	Then  I provided the phone number '<PhoneNumber>'
	And   click on continue
	Then  I selected the '<MicrochipOption>' option
	And   I provided microchip number as '<MicrochipNumber>' on pets
	When  click on continue
	Then  verify next page '<nextpage>' is loaded
	And   I have provided date of PETS microchipped
	When  click on continue
	Then  verify next page '<nextpage1>' is loaded
	And   I have selected an option as '<Pet>' for pets
	When  click on continue
	Then  verify next page '<nextpage2>' is loaded
	And   Select breed of your pet '<PetBreed>'
	When  click on continue
	Then  verify next page '<nextpage3>' is loaded
	And   I provided the Pets name as '<PetName>'
	When  click on continue
	Then  verify next page '<nextpage4>' is loaded
	When  Select Pet Sex option '<Gender>'
	When  click on continue
	Then  verify next page '<nextpage5>' is loaded
	And   I have provided date of birth
	When  click on continue
	Then  verify next page '<nextpage6>' is loaded
	And   I have selected the option as '<Color>' for color
	When  click on continue
	Then  verify next page '<nextpage7>' is loaded
	And   select Pets significant features '<IsSignificantFeatures>'
	When  click on continue
	Then  verify next page '<nextpage8>' is loaded
	And   I have ticked the I agree to the declaration checkbox
	Then  click Accept and Send button from Declaration page
	Then  verify next page '<nextpage9>' is loaded
	And   I can see the unique application reference number
	When  click on View all lifelong pet travel document link
	Then  verify next page '<nextpage10>' is loaded
	And   I should see the application on pets in 'Yn aros' status
	When  I have clicked the View hyperlink from home page
	Then  verify next page 'Crynodeb o' is loaded
	When  Reject an application via backend
	Then  click on back
	When  click View Invalid documents link in WELSH
	Then  verify next page 'Dogfennau annilys' is loaded
	Then  I should see the application in 'aflwyddiannus' status 
	When  I have clicked the View hyperlink from invalid documents page
	Then  verify next page 'Crynodeb o' is loaded
	Then  verify status on the application summary as 'Statws' 'aflwyddiannus' on Invalid documents page 
	And   verify print and download links are not displayed on PTD
	When  click on back
	And   click on back
	Then  verify next page 'Dogfennau teithio' is loaded
	And   click on signout button and verify the signout message on pets

Examples:

	| logininfo | FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10              |
	| test5     | Updated Name | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Basenji  | Cais wedi | Dogfennau teithio gydol |



