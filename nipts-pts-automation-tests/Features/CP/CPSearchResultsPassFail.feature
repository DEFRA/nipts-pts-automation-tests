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
	

Scenario Outline: PTS port checker Pass application by PTD number - status in Approved
	When Create an application via backend
	When Approve an application via backend
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
	And I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I should navigate to Welcome page
	And I verify submiited message
	And I verify count '1' for Pass Checks
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber1>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I should navigate to Welcome page
	And I verify submiited message
	And I verify count '2' for Pass Checks

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     | PTDNumber1 |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |  D4F115    |

Scenario Outline: PTS port checker Pass application by Reference number - status in Approved
	When Create an application via backend
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
	|Transportation | FerryRoute                    | ApplicationRadio             | 
	|Ferry          | Birkenhead to Belfast (Stena) | Search by application number | 

Scenario Outline: PTS port checker continue application by Reference number - status in Pending
	When Create an application via backend
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
	And I should see the application status in 'Pending'
	And I should see the application subtitle 'Your application summary'
	And click on continue
	Then I should navigate to Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             | 
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |



Scenario Outline: Verify format of PTD number and significant features option	
	When Create an application via backend with significant features option as No
    When Approve an application via backend
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
	Then verify format of PTD number on search results page
	Then verify significant features option 'No' on Search Pass Fail Results Page
	Then verify Pet color option 'Automation Black' on Search Pass Fail Results Page
	

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |


Scenario Outline: Verify breed selection with significant option as Yes on search results page
	When Create an application via backend
	When Approve an application via backend
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
	Then verify format of PTD number on search results page
	Then verify significant features option 'Automation Feature Descrition' on Search Pass Fail Results Page
	Then verify Pet Breed option 'Chihuahua' on Search Pass Fail Results Page
	
Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Verify no entries on checker page after 24 hours and before 48 hours
	When I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	And I verify no entries on checker page after 24 hours and before 48 hours	
Examples:
	|Transportation | FerryRoute                    | 
	|Ferry          | Birkenhead to Belfast (Stena) |

Scenario Outline: Verify no View link for no Referred to SPS record
	When Create an application via backend
	When Approve an application via backend
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
	And I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page
	And I select Pass radio button
	When I click save and continue button from application status page
	Then I should navigate to Welcome page
	And I verify submiited message
	And I verify count '1' for Pass Checks
    And I verify No View link if No Referred to SPS
	And click on signout button on CP and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	When I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time with SPS user
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
    And I verify No View link if No Referred to SPS with SPS User

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Verify Dog Pet details Search results with Pending application 	
	When Create an application via backend for 'Dog' with custom values
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
	Then verify Pet Breed option 'Automation Dog Breed Additional Info' on Search Pass Fail Results Page
	And verify Pet Name 'Automation Pet Dog' on Search Pass Fail Results Page
	And verify Pet Species 'Dog' on Search Pass Fail Results Page
	And verify Pet Sex 'Male' on Search Pass Fail Results Page
	And verify significant features option 'Automation Dog Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip date '21/08/2024' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789876543325' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Dog' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2024' on Search Pass Fail Results Page
	

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |

Scenario Outline: Verify Dog Pet details Search results with Approved application 
	When Create an application via backend for 'Dog' with custom values
    When Approve an application via backend
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
	Then verify format of PTD number on search results page
	And verify Pet Name 'Automation Pet Dog' on Search Pass Fail Results Page
	And verify Pet Species 'Dog' on Search Pass Fail Results Page
	And verify Pet Sex 'Male' on Search Pass Fail Results Page
	And verify significant features option 'Automation Dog Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789876543325' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Dog' on Search Pass Fail Results Page
	And verify Pet Microchip date '21/08/2024' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2024' on Search Pass Fail Results Page
	And verify Pet Breed option 'Automation Dog Breed Additional Info' on Search Pass Fail Results Page


Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Verify Cat Pet details Search results with Pending application 	
	When Create an application via backend for 'Cat' with custom values
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
	Then verify Pet Breed option 'Automation Cat Breed Additional Info' on Search Pass Fail Results Page
	And verify Pet Name 'Automation Pet Cat' on Search Pass Fail Results Page
	And verify Pet Species 'Cat' on Search Pass Fail Results Page
	And verify Pet Sex 'Female' on Search Pass Fail Results Page
	And verify significant features option 'Automation Cat Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip date '21/05/2025' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789876542125' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Cat' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2025' on Search Pass Fail Results Page
	

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |

Scenario Outline: Verify Cat Pet details Search results with Approved application 
	When Create an application via backend for 'Cat' with custom values
    When Approve an application via backend
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
	Then verify format of PTD number on search results page
	And verify Pet Name 'Automation Pet Cat' on Search Pass Fail Results Page
	And verify Pet Species 'Cat' on Search Pass Fail Results Page
	And verify Pet Sex 'Female' on Search Pass Fail Results Page
	And verify significant features option 'Automation Cat Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789876542125' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Cat' on Search Pass Fail Results Page
	And verify Pet Microchip date '21/05/2025' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2025' on Search Pass Fail Results Page
	And verify Pet Breed option 'Automation Cat Breed Additional Info' on Search Pass Fail Results Page


Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Verify Ferret Pet details Search results with Pending application 	
	When Create an application via backend for 'Ferret' with custom values
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
	Then I should see the application status in 'Pending'
	And verify Pet Name 'Automation Pet Ferret' on Search Pass Fail Results Page
	And verify Pet Species 'Ferret' on Search Pass Fail Results Page
	And verify Pet Sex 'Female' on Search Pass Fail Results Page
	And verify significant features option 'Automation Ferret Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip date '11/05/2023' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789126542125' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Ferret' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2022' on Search Pass Fail Results Page
	

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |

Scenario Outline: Verify Ferret Pet details Search results with Approved application 
	When Create an application via backend for 'Ferret' with custom values
    When Approve an application via backend
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
	Then verify format of PTD number on search results page
	And verify Pet Name 'Automation Pet Ferret' on Search Pass Fail Results Page
	And verify Pet Species 'Ferret' on Search Pass Fail Results Page
	And verify Pet Sex 'Female' on Search Pass Fail Results Page
	And verify significant features option 'Automation Ferret Feature Descrition' on Search Pass Fail Results Page
	And verify Pet Microchip Number '676789126542125' on Search Pass Fail Results Page
	And verify Pet color option 'Automation Black Ferret' on Search Pass Fail Results Page
	And verify Pet Microchip date '11/05/2023' on Search Pass Fail Results Page
	And verify Pets Date Of Birth '21/04/2022' on Search Pass Fail Results Page


Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |