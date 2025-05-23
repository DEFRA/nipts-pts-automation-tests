@CPRegression
Feature: CreateOfflineAppl

CreateOfflineAppl


Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	
Scenario Outline: Create Offline Application for Cat
	When Create an offline application via backend for 'Cat'
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
	When Revoke Approved application via backend
	And I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Cancelled'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |


Scenario Outline: Create Offline Application for Dog
	When Create an offline application via backend for 'Dog'
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
	When Revoke Approved application via backend
	And I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Cancelled'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Create Offline Application for Ferret
	When Create an offline application via backend for 'Ferret'
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
	When Revoke Approved application via backend
	And I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Cancelled'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |


