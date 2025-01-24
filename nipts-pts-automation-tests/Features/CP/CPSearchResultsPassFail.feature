@CPRegression
Feature: CP E2E Pass Fail

Check Pass fail status on PTS port checker 

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend

Scenario Outline: PTS port checker Pass application by PTD number - status in Approved
	When Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I should navigate to Welcome page
	And I verify submiited message
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |Transportation | FerryRoute                    | 
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   |Ferry          | Birkenhead to Belfast (Stena) |

Scenario Outline: PTS port checker Pass application by Reference number - status in Approved
	When Approve an application via backend
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
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I should navigate to Welcome page
	And I verify submiited message
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |Transportation | FerryRoute                    | ApplicationRadio             | 
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   |Ferry          | Birkenhead to Belfast (Stena) | Search by application number | 

Scenario Outline: PTS port checker continue application by Reference number - status in Pending
	When I have selected '<Transportation>' radio option
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
	And I should see the application subtitle 'Your application summary'
	And click on continue
	Then I should navigate to Report non-compliance page
	
Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | Transportation | FerryRoute                    | ApplicationRadio             | 
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | Ferry          | Birkenhead to Belfast (Stena) | Search by application number |
