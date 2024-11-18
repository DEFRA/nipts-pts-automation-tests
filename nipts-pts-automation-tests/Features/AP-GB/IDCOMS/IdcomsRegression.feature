@Idcoms @APGBRegression 
Feature: Idcoms Regression

IDCOMS System Regression for NIPTS

Scenario: Verify if a Caseworker can assign an already assigned case to themselves
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the first application
	And I assign the application to 'Vishal Shukla' another user
	And I assign the application to myself

Scenario: Verify if the Pet owner details are not editable
	When I Login to Dynamics application
	And I open the first application
	Then I cannot edit 'Pet Owner' Details

Scenario: Verify if the Pet details are not editable
	When I Login to Dynamics application
	And I open the first application
	Then I cannot edit 'Pet' Details

Scenario: Verify Revoke Pending System View	
	When I Login to Dynamics application
	And I Switch to 'Revoke Pending PTD Applications'
	And I open the first application
	Then the status is 'Revoke Pending'

Scenario: Verify Status transitions for Authorised application
	When I Login to Dynamics application
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	Then the status is 'Authorised'
	And I cannot see 'Activate' button

Scenario: Verify Status transitions for Revoked application
	When I Login to Dynamics application
	And I Switch to 'Revoked PTD Applications'
	And I open the first application
	Then the status is 'Revoked'
	And I cannot see 'Activate' button

Scenario: Verify Status transitions for Rejected application
	When I Login to Dynamics application
	And I Switch to 'Rejected PTD Applications'
	And I open the first application
	Then the status is 'Rejected'
	And I cannot see 'Activate' button


Scenario: Verify the duplicate subgrid - Rejected Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'ZIA73KAF' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Revoked Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'JUBBQB3A' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Authorised Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'JUBBQB3A' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Open Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'BSSOBCSA' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Pending Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the '6TVXHBPB' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Revoke pending Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'YUOMQ0Z7' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid

Scenario: Verify Microchip - Failed Verification Check Error Message
	When I Login to Dynamics application
	And I Switch to 'Open - Unassigned PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I Verify the 'Microchip' Failed Verification Check Error Message

Scenario: Verify Revoke application messages
	When I Login to Dynamics application	
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I 'Revoke' the application
	Then I verify the revocation error message
	
Scenario: Verify Reject application messages
	When I Login to Dynamics application	
	And I Switch to 'All PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I Verify the Rejection messages

Scenario: Verify the Other Revocation Reason is mandatory
	When I Login to Dynamics application	
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I 'Revoke' the application with reason 'Other:Other Reason'

Scenario: Verify Revoke reason: Clear and hide Other Reason field when not used
	When I Login to Dynamics application
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I verify Other Reason is not populated

Scenario: Verify Microchip Check: Clear and hide Other Reason field when not used
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I verify Other Fail reason is not populated

Scenario Outline: Revoke date & Reason is not available
	When I Login to Dynamics application	
	And I Switch to '<Application Type>'
	And I open the first application
	Then I verify revoke date and reason is not populated

Examples:
| Application Type                   |
| Open - Unassigned PTD Applications |
| Pending PTD Applications           |
| Authorised PTD Applications        |
| Rejected PTD Applications          |

Scenario: Verify the Microchip Check ‘Other Reason’ field mandatory
	When I Login to Dynamics application
	And I Switch to 'Open - Unassigned PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I Fail the Microchip check with 'Other' reason
	Then I verify the 'Other' Fail reason

Scenario: Verify if a Caseworker can filter the cases with pending status
	When I Login to Dynamics application
	And I filter with 'Status Reason' is 'Equals' to 'Pending' in PTS Application
	And I open the first application
	Then the status is 'Pending'
	
Scenario: Verify if Caseworker filters for cases assigned to them
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I filter with 'Owner' is 'Equals current user' to '' in PTS Application
	And I open the first application
	Then the Record Owner By 'current user'

Scenario: Verify if a Caseworker can search by microchip number
	When I Login to Dynamics application
	And I filter with 'Microchip Number' is 'Equals' to '123456789012345' in PTS Application
	And I open the first application
	Then the value of 'Microchip Number' is '123456789012345' in the PTD application

Scenario: Verify the caseworker can search by pet owner
	When I Login to Dynamics application
	And I filter with 'Name' is 'Equals' to 'Brinda CTS' in PTS Application
	And I open the first application
	Then the value of 'Name' is 'Brinda CTS' in the PTD application	

Scenario: Verify if Caseworker  clears caseworker filter - Dog
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Dog' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Dog' in the PTD application	

Scenario: Verify if Caseworker  clears caseworker filter - Cat
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Cat' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Cat' in the PTD application

Scenario: Verify if Caseworker  clears caseworker filter - Ferret
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Ferret' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Ferret' in the PTD application	

Scenario: Verify the Assisted Digital PTD Applications System Views
	When I Login to Dynamics application
	And I Switch to 'All Offline PTD Applications'
	And I Switch to 'All Offline PTD Applications (DEARA)'
	And I verify the system view

Scenario: Verify if the caseworker can create a new offline PTD application and Authorise it.
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Email' as 'Automationuser@xyz.com'
	And I enter 'Address Line 1' as '101A'
	And I enter 'Address Line 2' as 'Broad street'
	And I enter 'Address Line 3' as 'Fairstone'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Additional Breed' as 'Mixed Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Golden Brown'
	And I enter 'Other Colour' as 'Golden Brown and white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I Pass the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I dont see the Email in timeline
	And I cannot see 'Pending' command
		
Scenario: Verify if the caseworker can create a new offline PTD application, Authorise and Revoke it.
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Email' as 'Automationuser@xyz.com'
	And I enter 'Address Line 1' as '101A'
	And I enter 'Address Line 2' as 'Broad street'
	And I enter 'Address Line 3' as 'Fairstone'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Additional Breed' as 'Mixed Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Golden Brown'
	And I enter 'Other Colour' as 'Golden Brown and white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I Pass the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'	
	And I cannot see 'Pending' command
	When I assign the application to myself
	And I 'Revoke' the application with reason 'Pet Deceased'
	Then the status is changed to 'Revoked'
	And I cannot see 'Pending' command
	And I dont see the Email in timeline


Scenario: Verify the Duplicate Microchip Notification for offline PTD application submitted with only mandatory fields and reject it
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Address Line 1' as '11'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Cat'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Additional Breed' as 'Mixed-Beagle'
	And I enter 'Sex' as 'Female'
	And I enter 'Age' as '15'
	And I enter 'Colour' as 'Brown'
	And I enter 'Other Colour' as 'white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as '564789098987654'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And I do see Duplicate Microchip Notification
	When I Fail the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'
	And I cannot see 'Pending' command

Scenario: Verify if the caseworker can update the offline PTD application multiple time when the application status is Open
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I enter 'Applicant Name' as 'Automation user'
	And I enter 'Email' as 'Automationuser@xyz.com'
	And I enter 'Address Line 1' as '101A'
	And I Click on Save
	And I enter 'Address Line 2' as 'Broad street'
	And I enter 'Address Line 3' as 'Fairstone'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I Click on Save
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I Click on Save
	And I enter 'Additional Breed' as 'Mixed Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Golden Brown'
	And I enter 'Other Colour' as 'Golden Brown and white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Date of birth' as '12/11/2100'
	Then I See the error 'The date for Date of Birth cannot be in the future' notification
	When I enter 'Date of birth' as '22/11/2020'
	And I Click on Save
	
Scenario: Verify if the caseworker can update the offline PTD application multiple time when the application status is Pending
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I mark the application to 'Pending'
	Then the status is 'Pending'
	When I enter 'Applicant Name' as 'Automation user'
	And I enter 'Email' as 'Automationuser@xyz.com'
	And I enter 'Address Line 1' as '101A'
	And I Click on Save
	And I enter 'Address Line 2' as 'Broad street'
	And I enter 'Address Line 3' as 'Fairstone'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I Click on Save
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I Click on Save
	And I enter 'Additional Breed' as 'Mixed Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Golden Brown'
	And I enter 'Other Colour' as 'Golden Brown and white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '9/8/2100'
	Then I See the error 'The date for Microchipped Date cannot be in the future' notification
	When I enter 'Microchipped Date' as '9/8/2023'
	And I Click on Save
	
Scenario: Offline PTD Application should not be editable in Revoke Pending Status
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Email' as 'Automationuser@xyz.com'
	And I enter 'Address Line 1' as '101A'
	And I enter 'Address Line 2' as 'Broad street'
	And I enter 'Address Line 3' as 'Fairstone'
	And I enter 'Town' as 'Southampton'
	And I enter 'Postcode' as 'RG1 3JN'
	And I enter 'County' as 'Buckinghamshire'
	And I enter 'Country' as 'United Kingdom'
	And I enter 'Phone' as '07545534423'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Additional Breed' as 'Mixed Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Golden Brown'
	And I enter 'Other Colour' as 'Golden Brown and white'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I Pass the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I assign the application to myself
	Then I move the application to Revoke Pending status
	And I cannot edit 'Pet Owner' Details
	And I cannot edit 'Pet' Details
	And I cannot edit 'Applicant details' Details