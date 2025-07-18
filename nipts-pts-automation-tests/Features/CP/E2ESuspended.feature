@CPRegression
Feature: E2ESuspended

As a PTS port checker I want ot check E2E Suspended journey for GB to NI

Scenario Outline: Check Pending application status for Suspensed application user
	Given I navigate to the port checker application
	When I click signin button on port checker application
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
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Pending'
	And I should see the application subtitle 'Your application summary'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| Transportation | FerryRoute                   | ApplicationRadio             | ReferenceNumber |
	| Ferry          | Loch Ryan to Belfast (Stena) | Search by application number | TKWXU4GG        |

Scenario Outline: Check Unsuccessful application status for Suspensed application user
	Given I navigate to the port checker application
	When I click signin button on port checker application
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
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	And I should see the application subtitle 'Your application summary'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| Transportation | FerryRoute                   | ApplicationRadio             | ReferenceNumber |
	| Ferry          | Loch Ryan to Belfast (Stena) | Search by application number | YNC53JTA        |


Scenario Outline: Check Approved application status for Suspensed application user
	Given I navigate to the port checker application
	When I click signin button on port checker application
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
	And I provided the '<PTDNumber>' of the application
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
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify pass button not displayed on search result page
    And I verify fail button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| Transportation | FerryRoute                   | ApplicationRadio     | ApplicationRadio1            | ReferenceNumber | PTDNumber |
	| Ferry          | Loch Ryan to Belfast (Stena) | Search by PTD number | Search by application number | DICG1MU9        | 502E74    |


Scenario Outline: Check Revoked application status for Suspensed application user
	Given I navigate to the port checker application
	When I click signin button on port checker application
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
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I should see the suspended application warning 'This person cannot travel under the Northern Ireland Pet Travel Scheme'
	And I should see the suspended application warning 'you should read them the suspended failure script.'
    And I verify continue button not displayed on search result page
	And click on signout button on CP and verify the signout message

Examples:
	| Transportation | FerryRoute                   | ApplicationRadio     | ApplicationRadio1            | ReferenceNumber | PTDNumber |
	| Ferry          | Loch Ryan to Belfast (Stena) | Search by PTD number | Search by application number | 12IBO7SB        | 21490A    |

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
