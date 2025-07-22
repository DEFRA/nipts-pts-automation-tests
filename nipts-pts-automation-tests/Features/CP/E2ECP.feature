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
	When I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I verify the header text 'Check a pet travelling from GB to NI'
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
	When I click on Conduct an SPS check
	Then I should see the application status in 'Approved'
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	Then I verify the header text 'Check a pet travelling from GB to NI'
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	Then I verify the header text 'Check a pet travelling from GB to NI'
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |

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
	And I select Fail radio button
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
	And I click on Conduct an SPS check
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Not allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             |nextPage        | SPSOutcome  |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number |Referred to SPS | Not allowed |

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
	And I should see the application status in 'Cancelled'
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
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
	And I click on Conduct an SPS check
	And I should see the application status in 'Cancelled'
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             | nextPage        | SPSOutcome |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number | Referred to SPS | Allowed    |

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
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	And I verify Pet document detailsfor Pending and Unsuccessful Appl on Referred to SPS details
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
	And I click on Reference number of the application
	And I click on Conduct an SPS check
	And I should see the application status in 'Unsuccessful'
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute               |  ApplicationRadio             |nextPage        | SPSOutcome |
	| Ferry          | Cairnryan to Larne (P&O) |  Search by application number |Referred to SPS | Allowed    |

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
	And I should see the Search Results Heading 'Checks'
	And I should see the application subtitle 'Your application summary'
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click on GB outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
	And I verify Pet document detailsfor Pending and Unsuccessful Appl on Referred to SPS details
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
	And I click on Reference number of the application
	And I click on Conduct an SPS check
	And I should see the application status in 'Pending'
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify Species 'Dog' and Colour 'Black' on Referred to SPS details
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 
	
Examples:
	| Transportation | FerryRoute                    | ApplicationRadio			    |nextPage        | SPSOutcome |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number |Referred to SPS | Allowed    |

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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click on Back button
	Then I should see the application status in 'Approved'
	And I click on Back button
	Then I navigate to Find a document page
	And click on signout button on CP and verify the signout message
	
Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |

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
	And I select Fail radio button
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
	And I click on Conduct an SPS check
	Then I should see the application status in 'Approved'
	When I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click on Back button
	Then I should see the application status in 'Approved'
	And I click on Back button
	Then verify next page '<nextPage1>' is loaded
	 

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |

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
	And I select Fail radio button
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
	When I click on Conduct an SPS check
	Then I should see the application status in 'Approved'
	When I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click 'Allowed' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 

Examples:
	| Transportation | FerryRoute                    | TypeOfPassenger      | nextPage        | SPSOutcome | nextPage1       | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | Ferry foot passenger | Referred to SPS | Allowed    | GB check report | Search by PTD number |

