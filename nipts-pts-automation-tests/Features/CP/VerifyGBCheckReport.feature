@CPRegression
Feature: VerifyGBCheckReport

validate GB Check Report page fields

Background:
	Given I navigate to the port checker application
	And I click signin button on port checker application
	When I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'GBUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	When Create an application via backend
	When Approve an application via backend

Scenario Outline: Validate GB Check Report page fields
	When I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
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
	When I select MicrochipReason '<MicrochipNumberNoMatch>' on Report non-compliance page
	And I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter relevant comment '<AdditionalComment>'
	And I select GB Outcome '<PassengerRefferedDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	When I click on view on Checks page
	And I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<MicrochipNumberNoMatch>'
	And I verify GB check report with MicrochipReason '<CannotFindMicrochip>'
	And I verify GB check report with relevent comment '<AdditionalComment>'
	And I verify GB check report with GB Outcome '<PassengerRefferedDAERA>'
	And I verify GB check report with GB Outcome '<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | MicrochipNumberNoMatch | CannotFindMicrochip | PassengerType        | AdditionalComment        | PassengerRefferedDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel |
	| Ferry          | Birkenhead to Belfast (Stena) | MicrochipNumberNoMatch | CannotFindMicrochip | Ferry foot passenger | Verify Additonal Comment | PassengerRefferedDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel |
	| Ferry          | Birkenhead to Belfast (Stena) | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | PassengerRefferedDAERA | No                       | PassengerWillNotTravel |
	| Ferry          | Birkenhead to Belfast (Stena) | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | PassengerRefferedDAERA | No                       | No                     |

