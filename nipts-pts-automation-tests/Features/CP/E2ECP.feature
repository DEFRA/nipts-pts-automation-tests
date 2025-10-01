@CPRegression
Feature: E2ECP

As a PTS port checker I want ot check E2E journey for GB to NI

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
@RunOnly
Scenario Outline: Check GB to SPS PETS Travel Document details By PTD number - status in Approved
	When Create an application via backend
	And Approve an application via backend
	And I have captured pet details
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click search button from footer
	Then I navigate to Find a document page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	Then I should see the Search Results Heading 'Checks'
	When I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I verify the header text 'Check a pet travelling from GB to NI'
    And I verify the Reasons Heading structure
    And I verify the Microchip Heading structure
    And I click on Microchip details Heading structure
    And I verify the Other Issues Heading structure
    And I verify the Passanger details Heading structure
    And I click on Pet owner details Heading structure
    And I verify the Record outcome Heading structure
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<TypeOfPassenger>' in Passenger details
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I verify Pet document details on Referred to SPS details
	And I verify Pet departure details on Referred to SPS details
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And click on signout button on CP and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	When I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time with SPS user
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click on PTD number of the application
	Then verify next page '<nextPage1>' is loaded
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click on Update referral outcome
	Then verify next page '<nextPage2>' is loaded
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Approved' on Report non-compliance page
	And I Verify PTD number on Pet Travel document details link
	And I click 'Allowed' on SPS outcome
	And I enter details of outcome '<DetailsOfOutCome>'
	And I click on Save on update referral
	Then I should navigate to Welcome page
	And I verify submiited message
    And I verify submiited message image
	And I verify the header text 'Check a pet travelling from GB to NI'
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     | nextPage2               | DetailsOfOutCome        |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number | Update referral outcome | Test Details of Outcome |

Scenario Outline: Check GB to SPS PETS Travel Document details By Application number - status in Approved
	When Create an application with Mandatory address only via backend
	And Approve an application via backend
	And I have captured pet details
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
	And I verify Pet document details on Referred to SPS details
	And I verify Pet departure details on Referred to SPS details
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
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
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	And I click on PTD number of the application
	And I click on Update referral outcome
	Then verify next page '<nextPage2>' is loaded
	And I click 'Not allowed' on SPS outcome
	And I enter details of outcome '<DetailsOfOutCome>'
	And I click on Save on update referral
	Then I should navigate to Welcome page
	And I verify submiited message
    And I verify submiited message image
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute               | ApplicationRadio             | nextPage        | SPSOutcome  | nextPage2               | DetailsOfOutCome        |
	| Ferry          | Cairnryan to Larne (P&O) | Search by application number | Referred to SPS | Not allowed | Update referral outcome | Test Details of Outcome |

Scenario Outline: Check GB to SPS PETS Travel Document details By Application number - status in Revoked
	When Create an application via backend
	And Revoke an application via backend
	And I have captured pet details
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
	Then I should see the application status in 'Cancelled'
	And I verify warning message on search results page for status 'Cancelled'

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             | nextPage        | SPSOutcome |nextPage2               | DetailsOfOutCome        |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number | Referred to SPS | Allowed    |Update referral outcome | Test Details of Outcome |

Scenario Outline: Check GB to SPS PETS Travel Document details By Application number - status in Unsuccessful
	When Create an application via backend
	And Reject an application via backend
	And I have captured pet details
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
	And I should see the application status in 'Unsuccessful'
	And I should see the application subtitle 'Your application summary'
	And I verify warning message on search results page for status 'Unsuccessful'

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             |nextPage        | SPSOutcome |nextPage2               | DetailsOfOutCome        |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number |Referred to SPS | Allowed    |Update referral outcome | Test Details of Outcome |

Scenario Outline: Check GB to SPS PETS Travel Document details By Reference number - status in Pending
	When Create an application via backend
	When I have captured pet details
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
	Then I should see the application status in 'Pending'
	And I should see the application subtitle 'Your application summary'
	And I verify warning message on search results page for status 'Pending'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio			    |nextPage        | SPSOutcome |nextPage2               | DetailsOfOutCome        |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |Referred to SPS | Allowed    |Update referral outcome | Test Details of Outcome |

	@RunOnly
Scenario Outline: Verify navigation of back links in the application for GB user
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
	And I should see the application status in 'Approved'
	And I should see the application subtitle 'Lifelong pet travel document and declaration'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click on Back button
	Then I should see the application status in 'Approved'
	And I click on Back button
	Then I navigate to Find a document page
	And click on signout button on CP and verify the signout message
	
Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |nextPage2               | DetailsOfOutCome        |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |Update referral outcome | Test Details of Outcome |

Scenario Outline: Verify back link navigation for SPS user
	When Create an application via backend
	And Approve an application via backend
	And I have captured pet details
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
	And I verify Pet document details on Referred to SPS details
	And I verify Pet departure details on Referred to SPS details
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
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	And I click on PTD number of the application
	When I click on Update referral outcome
	Then verify next page '<nextPage2>' is loaded
	And I click on Back button
	Then verify next page '<nextPage1>' is loaded
	 

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |nextPage2               | DetailsOfOutCome        |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |Update referral outcome | Test Details of Outcome |

	@RunOnly
Scenario Outline: Check GB to SPS PETS Travel Document details with Other Colour By PTD number - status in Approved
	When Create an application via backend with Other Colour
	And Approve an application via backend
	And I have captured pet details
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
	And I verify Pet document details on Referred to SPS details
	And I verify Pet departure details on Referred to SPS details
	And I verify Species 'Dog' and Colour 'Other' on Referred to SPS details
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
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Other' on Referred to SPS details
	When I click on PTD number of the application
	Then verify next page '<nextPage1>' is loaded
	When I click on Update referral outcome
	Then verify next page '<nextPage2>' is loaded
	And I click 'Allowed' on SPS outcome
	And I enter details of outcome '<DetailsOfOutCome>'
	And I click on Save on update referral
	Then I should navigate to Welcome page
	And I verify submiited message
    And I verify submiited message image
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute               | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     | nextPage2               | DetailsOfOutCome        |
	| Ferry          | Cairnryan to Larne (P&O) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number | Update referral outcome | Test Details of Outcome |

