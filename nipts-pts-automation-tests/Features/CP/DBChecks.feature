Feature: DBChecks

As a PTS port checker I want ot check E2E journey for GB to NI with Backend SQL tables

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page

	#@RunOnly
Scenario Outline: Veirfy backend entries for GB and SPS Outcome for Fail or Reffered to SPS journey
	When I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
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
	When I click continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select MicrochipReason '<MicrochipNumberNoMatch>' on Report non-compliance page
	And I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I click '<TypeOfPassenger>' in Passenger details
	And I enter relevant comment '<AdditionalComment>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then verify next page '<nextPage>' is loaded
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
	And I select MicrochipReason '<MicrochipNumberNoMatch>' on Report non-compliance page
	And I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I click '<SPSOutcome>' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then verify next page '<nextPage>' is loaded
	And I verify SPS outcome '<SPSOutcome>' on referred SPS page 
	And I click on Reference number of the application
	Then I verify backend SQL entries for GB Summary Table
	And I verify backend SQL entries for SPS Summary Table
	And I verify backend SQL entries for GB Outcome
	And I verify backend SQL entries for SPS Outcome '<TypeOfPassenger>','<SPSOutcome>'

	Examples:
	| Transportation | FerryRoute                    | ApplicationRadio             | nextPage        | SPSOutcome  | TypeOfPassenger     |MicrochipNumberNoMatch | CannotFindMicrochip | AdditionalComment        | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by application number | Referred to SPS | Allowed     | Ferry foot passenger|MicrochipNumberNoMatch | CannotFindMicrochip | Verify Additonal Comment | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel |
	| Ferry          | Cairnryan to Larne (P&O)      | Search by application number | Referred to SPS | Not allowed | Vehicle on ferry    |MicrochipNumberNoMatch | No                  | None                     | PassengerReferredDAERA | No                       | PassengerWillNotTravel |

		#@RunOnly
Scenario Outline: Veirfy backend entries for GB outcome for Pass journey
	When I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
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
	Then I verify backend SQL entries for GB Summary Table for Pass appl


Examples:
	| Transportation | FerryRoute                    | 
	| Ferry          | Birkenhead to Belfast (Stena) |

			#@RunOnly
Scenario Outline: Veirfy backend entries for SPS outcome and Summary table for SPS flight journey
	When I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
	And Approve an application via backend
	And I have selected '<Transportation>' radio option
	And I provide the '<Flight number>' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click '<TypeOfPassenger>' in Passenger details
	And I select 'Cannot find microchip' as non compliance reason
	And I click '<SPSOutcome>' on SPS outcome
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Welcome page
	And I verify backend SQL entries for SPS Summary Table
	And I verify backend SQL entries for SPS Outcome '<TypeOfPassenger>','<SPSOutcome>'


Examples:
	| Transportation | Flight number | TypeOfPassenger | nextPage        | SPSOutcome  |
	| Flight         | AI 123        | Airline         | Referred to SPS | Allowed     |
	| Flight         | AI 123        | Airline         | Referred to SPS | Not allowed |

