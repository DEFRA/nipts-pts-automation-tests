@Regression 

Feature: E2E Welsh


Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And  click on Welsh language


Scenario Outline: Create PETS Travel Document By Registered User with details correct for Dog Species - Approved 
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Approve an application via backend
	Then click on back
	And I should see the application in 'cymeradwyo' status
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10 |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Ragdoll  | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with details correct for Cat Species - Approved in WELSH
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	And I have selected the option as '<Gender>' for sex
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' 'Benyw'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' 'Benyw'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Approve an application via backend
	Then click on back
	And I should see the application in 'cymeradwyo' status
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10 |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Cath| Cat     | Benyw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Birman   | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with free text breed in WELSH
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Approve an application via backend
	Then click on back
	And I should see the application in 'cymeradwyo' status
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed				  | nextpage9 | nextpage10 |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Cath| Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Unique unknown breed   | Cais wedi | Dogfennau teithio gydol |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Dog     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Unique unknown breed   | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with Other color option in WELSH
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	And I provided other color of the pet as "Unique Color"
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value 'Unique Color'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value 'Unique Color'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Approve an application via backend
	Then click on back
	And I should see the application in 'cymeradwyo' status
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed	| nextpage9 | nextpage10 |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Cath| Cat     | Gwryw  | Other | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Birman   | Cais wedi | Dogfennau teithio gydol |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Dog     | Gwryw  | Other | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Birman   | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User and navigate to Pet owner details page in WELSH
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	And I have selected the option as '<Gender>' for sex
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	And I provided other color of the pet as "Unique Color"
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	And click on Apply for another lifelong pet travel document link
	Then verify next page 'manylion chi' is loaded
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed	| nextpage9 | nextpage10 |
	| PetDog's | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Cath| Cat     | Gwryw  | Other | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Birman   | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with details not correct - Revoked in WELSH
	When select 'Nac ydyn' on Personal Details page
	And click on continue
	Then I provided the full name of the pet keeper as '<FullName>'
	And click on continue
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	And click on continue
	Then I provided the phone number '<PhoneNumber>'
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify pet owner details on the application summary in WELSH as 'Enw' '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Revoke an application via backend
	Then click on back
	And I should not see the application in the Dashboard
	When click View Invalid documents link in WELSH
	Then verify next page 'Dogfennau annilys' is loaded	
	Then I should see the application on pets in 'u canslo' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Dogfen teithio a datganiad ar gyfer anifail anwes gydol oes' is loaded	
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Statws' and field value 'u canslo'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify pet owner details on the application summary in WELSH as 'Enw' '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10 |
	| Updated Name | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Basenji  | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with enter address manually - Rejected in WELSH
	When select 'Nac ydyn' on Personal Details page
	And  click on continue
	Then I provided the full name of the pet keeper as '<FullName>'
	And  click on continue
	When click on enter address manually
	And  I provided address details with postcode '<PostCode>'
	And  click on continue
	Then I provided the phone number '<PhoneNumber>'
	And  click on continue
	Then I selected the '<MicrochipOption>' option
	And  I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And  I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage2>' is loaded
	And Select breed of your pet '<PetBreed>'
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	Then I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify pet owner details on the application summary in WELSH as 'Enw' '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Reject an application via backend
	Then click on back
	And I should not see the application in the Dashboard
	When click View Invalid documents link in WELSH
	Then verify next page 'Dogfennau annilys' is loaded	
	Then I should see the application on pets in 'Yn aflwyddiannus' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Statws' and field value 'Yn aflwyddiannus'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify WELSH summary on the application summary page with field name 'Brid' and field value '<PetBreed>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify pet owner details on the application summary in WELSH as 'Enw' '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And click on signout button and verify the signout message on pets

Examples:
	| FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10 |
	| Updated Name | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ci  | Cat     | Gwryw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Basenji  | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with details correct for Ferret Species - Approved in WELSH
	When select 'Ydyn' on Personal Details page
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Approve an application via backend
	Then click on back
	And I should see the application in 'cymeradwyo' status
	And click on signout button and verify the signout message on pets

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet     | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | nextpage9 | nextpage10 |
	| PetFerret| Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ffured  | Ferret  | Gwryw  | Arian | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with details not correct for Ferret species- Revoked in WELSH
	When select 'Nac ydyn' on Personal Details page
	And click on continue
	Then I provided the full name of the pet keeper as '<FullName>'
	And click on continue
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	And click on continue
	Then I provided the phone number '<PhoneNumber>'
	And click on continue
	Then I selected the '<MicrochipOption>' option
	And I provided microchip number as '<MicrochipNumber>' on pets
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify pet owner details on the application summary in WELSH as 'Enw' '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Revoke an application via backend
	Then click on back
	And I should not see the application in the Dashboard
	When click View Invalid documents link in WELSH
	Then verify next page 'Dogfennau annilys' is loaded	
	Then I should see the application on pets in 'u canslo' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Dogfen teithio a datganiad ar gyfer anifail anwes gydol oes' is loaded	
	And click on signout button and verify the signout message on pets

Examples:
	| FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet     | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | nextpage9 | nextpage10 |
	| Ferret       | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ffured  | Ferret  | Gwryw  | Arian | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Cais wedi | Dogfennau teithio gydol |


Scenario Outline: Create PETS Travel Document By Registered User with enter address manually for ferret species - Rejected in WELSH
	When select 'Nac ydyn' on Personal Details page
	And  click on continue
	Then I provided the full name of the pet keeper as '<FullName>'
	And  click on continue
	When click on enter address manually
	And  I provided address details with postcode '<PostCode>'
	And  click on continue
	Then I provided the phone number '<PhoneNumber>'
	And  click on continue
	Then I selected the '<MicrochipOption>' option
	And   provided microchip number as <MicrochipNumber>
	When click on continue
	Then verify next page '<nextpage>' is loaded
	And  I have provided date of PETS microchipped
	When click on continue
	Then verify next page '<nextpage1>' is loaded
	And I have selected an option as '<Pet>' for pets
	When click on continue
	Then verify next page '<nextpage3>' is loaded
	And I provided the Pets name as '<PetName>'
	When click on continue
	Then verify next page '<nextpage4>' is loaded
	When Select Pet Sex option '<Gender>'
	When click on continue
	Then verify next page '<nextpage5>' is loaded
	And I have provided date of birth
	When click on continue
	Then verify next page '<nextpage6>' is loaded
	And I have selected the option as '<Color>' for color
	When click on continue
	Then verify next page '<nextpage7>' is loaded
	And select Pets significant features '<IsSignificantFeatures>'
	When click on continue
	Then verify next page '<nextpage8>' is loaded
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	And I have ticked the I agree to the declaration checkbox
	Then click Accept and Send button from Declaration page
	Then I verify application submitted page title '<nextpage9>'
	And I can see the unique application reference number
	When click on View all lifelong pet travel document link
	Then verify next page '<nextpage10>' is loaded
	And I should see the application on pets in 'Yn aros' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded
	And verify WELSH summary on the application summary page with field name 'Rhif y microsglodyn' and field value '<MicrochipNumber>'
	And verify WELSH summary on the application summary page with field name 'Lleoliad y mewnblaniad' and field value 'O dan y croen'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<PetName>'
	And verify WELSH summary on the application summary page with field name 'Rhywogaeth' and field value '<Pet>'
	And verify gender on the application summary in WELSH as 'Rhyw' '<Gender>'
	And verify WELSH summary on the application summary page with field name 'Lliw' and field value '<Color>'
	And verify WELSH summary on the application summary page with field name 'Nodweddion arwyddocaol' and field value '<IsSignificantFeatures>'
	And verify WELSH summary on the application summary page with field name 'Enw' and field value '<FullName>'
	And verify WELSH summary on the application summary page with field name 'ffôn' and field value '<PhoneNumber>'
	And verify WELSH summary on the application summary page with field name 'Cyfeiriad' and field value '<PostCode>'
	And verify WELSH text for Michrochip Date 'Dyddiad mewnblannu neu sganio' and Michrochip Date on application summary page
	And verify WELSH text for Pet DOB 'Dyddiad geni' and Pet DOB on application summary page
	When Reject an application via backend
	Then click on back
	And I should not see the application in the Dashboard
	When click View Invalid documents link in WELSH
	Then verify next page 'Dogfennau annilys' is loaded	
	Then I should see the application on pets in 'Yn aflwyddiannus' status
	When I have clicked the View hyperlink from home page
	Then verify next page 'Crynodeb o' is loaded	
	And click on signout button and verify the signout message on pets

Examples:
	| FullName     | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet     | PetName | Gender | Color | IsSignificantFeatures | nextpage                             | nextpage1             | nextpage2  | nextpage3   | nextpage4               | nextpage5                       | nextpage6        | nextpage7                     | nextpage8             | PetBreed | nextpage9 | nextpage10 |
	| Ferret       | Ydyn                     | CV1 4PY  | 02012345678 | Oes             | 123456789123456 | Ffured  | Ferret  | Benyw  | Du    | Nac oes               | anifail anwes gael microsglodyn wedi | rhain yw eich anifail | Pa frid yw | Beth yw enw | rhyw eich anifail anwes | dyddiad geni eich anifail anwes | yw prif liw eich | unrhyw nodweddion arwyddocaol | Gwiriwch eich atebion | Pug      | Cais wedi | Dogfennau teithio gydol |


