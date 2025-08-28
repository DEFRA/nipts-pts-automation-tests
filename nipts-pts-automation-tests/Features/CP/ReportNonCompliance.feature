@CPRegression
Feature: Report Non Compliance

As a PTS port checker I want ot Check application Report non compliance page

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend

Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Approved
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
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Approved' on Report non-compliance page
	And I Verify PTD number on Report non-compliance page
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message 'Select the type of passenger' in Report non-compliance page

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number |

#Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Pending
#	When I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the Reference number of the application
#	When I click search button
#	And I should see the application status in 'Pending'
#	And click on continue
#	Then I should navigate to Report non-compliance page
#	And I click Pet Travel Document details link dropdown
#	And I Verify status 'Pending' on Report non-compliance page
#	And I Verify Application Reference number on Report non-compliance page
#	
#Examples:
#	| Transportation | FerryRoute                    | ApplicationRadio             | 
#	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number | 
#
#Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Revoked
#	When Revoke an application via backend
#	And I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the Reference number of the application
#	When I click search button
#	And I should see the application status in 'Cancelled'
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I click Pet Travel Document details link dropdown
#	And I Verify status 'Cancelled' on Report non-compliance page
#
#Examples:
#	| Transportation | FerryRoute               |  ApplicationRadio             |
#	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number |
#
#Scenario Outline: PTS port checker Fail application status in non-compliance page - status in Unsuccessful
#	When Reject an application via backend
#	And I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the Reference number of the application
#	When I click search button
#	And I should see the application status in 'Unsuccessful'
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I click Pet Travel Document details link dropdown
#	And I Verify status 'Unsuccessful' on Report non-compliance page
#	
#Examples:
#	| Transportation | FerryRoute                    |ApplicationRadio             |
#	| Ferry          | Birkenhead to Belfast (Stena) |Search by application number | 


#Scenario: Verify error messages for microchip number field on Report Non- Compliance page
#	When Approve an application via backend
#	And I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the PTD number of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And  select Michrochip does not match the PTD checkbox
#	And  I click '<PassengerType>' in Passenger details
#	And  I click on GB outcome
#	And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
#	When click on Save outcome
#	Then I should see an error message '<ErrorMsg>' in Report non-compliance page
#	
#Examples:
#	| Transportation | FerryRoute                    | PassengerType        | MichrochipNumber | ErrorMsg                                                | ApplicationRadio     |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger |                  | Enter the 15-digit microchip number                     | Search by PTD number |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | 11233            | Enter the 15-digit microchip number, using only numbers | Search by PTD number |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | 123@             | Enter the 15-digit microchip number, using only numbers | Search by PTD number |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | wwqw             | Enter the 15-digit microchip number, using only numbers | Search by PTD number |

Scenario: Verify hint text and GB,SPS outcome error messages on Report Non- Compliance page
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
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	#And  verify hint text 'Any relevant comments' for Other reason
	When click on Save outcome
	Then I should see an error message 'Select at least one GB outcome' in Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType | MichrochipNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Airline       |                  | Search by PTD number |

#Scenario: Verify error messages for any relevant comment field on Report Non- Compliance page
#	When Approve an application via backend
#	And I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the PTD number of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And  select Michrochip does not match the PTD checkbox
#	And  I click '<PassengerType>' in Passenger details
#	And I enter relevant comment '<AdditionalComment>'
#	And  I click on GB outcome
#	And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
#	When click on Save outcome
#	Then I should see an error message '<ErrorMsg>' in Report non-compliance page
#	
#Examples:
#	| Transportation | FerryRoute                    | PassengerType        | MichrochipNumber | ErrorMsg                                                | ApplicationRadio     | AdditionalComment   |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | 111111111111111  | Relevant comments must be 500 characters or less        | Search by PTD number |	Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering the 501 word count. Entering				|
#
#Scenario: Verify boundaries  for any relevant comment field on Report Non- Compliance page
#	When Approve an application via backend
#	And I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the PTD number of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And  select Michrochip does not match the PTD checkbox
#	And  I click '<PassengerType>' in Passenger details
#	And I enter relevant comment '<AdditionalComment>'
#	And  I click on GB outcome
#	And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
#	When click on Save outcome
#	Then I should navigate to Welcome page
#	
#Examples:
#	| Transportation | FerryRoute                    | PassengerType        | MichrochipNumber | ApplicationRadio     | AdditionalComment   |
#	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | 111111111111111  | Search by PTD number |	Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Entering the 499 word count. Enteri|

Scenario: Verify Validation positive check for details of outcome field on Report Non- Compliance page
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
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select 'Cannot find microchip' as non compliance reason
	And  I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutCome>'
	And  I click on GB outcome
	#And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
	When click on Save outcome
	Then I should navigate to Welcome page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType       | MichrochipNumber | ApplicationRadio     | DetailsOfOutCome  |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger| 111111111111111  | Search by PTD number |Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit for details of outcome Positive check with 500 char limit y|

Scenario: Verify error message  for details of outcome field on Report Non- Compliance page
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
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select 'Cannot find microchip' as non compliance reason
	And  I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutCome>'
	And  I click on GB outcome
	#And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
	And click on Save outcome
	Then I should see an error message '<ErrorMsg>' in Report non-compliance page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType    | MichrochipNumber | ErrorMsg                                        | ApplicationRadio     | DetailsOfOutCome                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
	| Ferry          | Birkenhead to Belfast (Stena) | Vehicle on ferry | 111111111111111  | Outcome summary must be 500 characters or less  | Search by PTD number | Entered 501 char limit for details of   outcomefield Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for details of outcome field Entered 501 char limit for detail |

Scenario: Verify boundaries  check for details of outcome field on Report Non- Compliance page
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
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select 'Cannot find microchip' as non compliance reason
	And  I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutCome>'
	And  I click on GB outcome
	#And  Enter michrochip Number in Michrochip Does not match PTD field '<MichrochipNumber>'
	And click on Save outcome
	Then I should navigate to Welcome page
	
Examples:
	| Transportation | FerryRoute                    | PassengerType    | MichrochipNumber | ApplicationRadio     | DetailsOfOutCome  |
	| Ferry          | Birkenhead to Belfast (Stena) | Vehicle on ferry | 111111111111111  | Search by PTD number |Boundaries check with 499 char limit for details of outcome- Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check with 499 char limit for details of outcome Boundaries check w|
	