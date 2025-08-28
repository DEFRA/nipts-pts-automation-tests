@CPRegression
Feature: VerifyReferredToSPS

Validate Referred to SPS page

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
	When Approve an application via backend

Scenario Outline: Validate pagination on Referred to SPS page
	When I have selected '<Transportation>' radio option
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
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber1>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber2>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber3>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber4>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber5>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber6>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber7>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber8>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber9>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber10>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	Then I verify referred to SPS record count '10' on page
	When I click on page '2'
	Then I verify referred to SPS record count '1' on page
	When I click on page '1'
	Then I verify referred to SPS record count '10' on page
	When I click on 'Next' page
	Then I verify referred to SPS record count '1' on page
	When I click on 'Previous' page
	Then I verify referred to SPS record count '10' on page

Examples:
	| Transportation | FerryRoute               | TypeOfPassenger      | nextPage        | ApplicationRadio     | PTDNumber2 | PTDNumber3 | PTDNumber4 | PTDNumber5 | PTDNumber6 | PTDNumber7 | PTDNumber8 | PTDNumber9 | PTDNumber10 | PTDNumber1 |
	| Ferry          | Cairnryan to Larne (P&O) | Ferry foot passenger | Referred to SPS | Search by PTD number | C5A036     | E6361B     | 05A888     | 393A1B     | 027E5C     | 1DEFA0     | E2E7AE     | D4EA77     | 35E5AB      | 17F418     |

#Scenario Outline: Validate wrong ascending order on Reffered to SPS page
#	When I have selected '<Transportation>' radio option
#	And I select the '<FerryRoute>' radio option
#	And I have provided Scheduled departure time
#	When I click save and continue button from route checke page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the '<PTDNumber1>' of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I get PTD or reference number and add it in collection
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio1>' radio button
#	And I provided the Application Number '<ReferenceNumber1>' of the application
#	When I click search button
#	And I should see the application status in 'Pending'
#	And I get PTD or reference number and add it in collection
#	When I click continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio1>' radio button
#	And I provided the Application Number '<ReferenceNumber2>' of the application
#	When I click search button
#	And I should see the application status in 'Unsuccessful'
#	And I get PTD or reference number and add it in collection
#	When I click continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio2>' radio button
#	And I provided the Microchip number '<MicrochipNumber1>' of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I get PTD or reference number and add it in collection
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the '<PTDNumber3>' of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I get PTD or reference number and add it in collection
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio2>' radio button
#	And I provided the Microchip number '<MicrochipNumber2>' of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I get PTD or reference number and add it in collection
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the '<PTDNumber4>' of the application
#	When I click search button
#	And I should see the application status in 'Cancelled'
#	And I get PTD or reference number and add it in collection
#	When I click continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio>' radio button
#	And I provided the '<PTDNumber5>' of the application
#	When I click search button
#	And I should see the application status in 'Approved'
#	And I get PTD or reference number and add it in collection
#	And I select Refer to SPS radio button
#	When I click save and continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio1>' radio button
#	And I provided the Application Number '<ReferenceNumber3>' of the application
#	When I click search button
#	And I should see the application status in 'Pending'
#	And I get PTD or reference number and add it in collection
#	When I click continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click search button from footer
#	Then I navigate to Find a document page
#	And I click search by '<ApplicationRadio1>' radio button
#	And I provided the Application Number '<ReferenceNumber4>' of the application
#	When I click search button
#	And I should see the application status in 'Pending'
#	And I get PTD or reference number and add it in collection
#	And I arrange PTD or reference number in ascending order
#	When I click continue button from application status page
#	Then I should navigate to Report non-compliance page
#	And I select 'Cannot find microchip' as non compliance reason
#	And I click '<TypeOfPassenger>' in Passenger details
#	And I click on GB outcome
#	When I click Report non-compliance button from Report non-compliance page
#	Then I should navigate to Welcome page
#	When I click on view on Checks page
#	Then verify next page '<nextPage>' is loaded
#	Then I verify wrong PTD and reference number are displayed in ascending order
#
#Examples:
#	| Transportation | FerryRoute               | TypeOfPassenger      | nextPage        | PTDNumber1 | PTDNumber2 | PTDNumber3 | PTDNumber4 | PTDNumber5 | ApplicationRadio1            | ApplicationRadio2          | ReferenceNumber1 | ReferenceNumber2 | ReferenceNumber3 | ReferenceNumber4 | MicrochipNumber1 | MicrochipNumber2 | ApplicationRadio     |
#	| Ferry          | Cairnryan to Larne (P&O) | Ferry foot passenger | Referred to SPS | C5A036     | E6361B     | E6361B     | F7DFF5     | 393A1B     | Search by application number | Search by microchip number | FUL5G1XA         | TS9YYQQ3         | QLPZ78Q2         | GLXU05Q5         | 981118686767887  | 981118686767887  | Search by PTD number |

Scenario Outline: Validate ascending order on Reffered to SPS page
	When I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber1>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Application Number '<ReferenceNumber1>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Application Number '<ReferenceNumber2>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio2>' radio button
	And I provided the Microchip number '<MicrochipNumber1>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber3>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber4>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Application Number '<ReferenceNumber3>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio1>' radio button
	And I provided the Application Number '<ReferenceNumber4>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I get PTD or reference number and add it in collection
	And I arrange PTD or reference number in ascending order
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	Then I verify PTD and reference number are displayed in ascending order

Examples:
	| Transportation | FerryRoute                   | TypeOfPassenger      | nextPage        | PTDNumber1 | PTDNumber3 | PTDNumber4 | ApplicationRadio     | ApplicationRadio1            | ApplicationRadio2          | ReferenceNumber1 | ReferenceNumber2 | ReferenceNumber3 | ReferenceNumber4 | MicrochipNumber1 | 
	| Ferry          | Loch Ryan to Belfast (Stena) | Ferry foot passenger | Referred to SPS | C5A036     | F907B5     | EFFFEB     | Search by PTD number | Search by application number | Search by microchip number | 5OEVGAD5         | JKYGRLAF         | TKMIAYTF         | GLXU05Q5         | 123454444123456  |

