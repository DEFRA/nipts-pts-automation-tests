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

Scenario Outline: Validate GB Check Report page fields for GB User
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
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<RefusedToSignDeclaration>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	When I click on view on Checks page
	And I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthPersonButNoConfirmation>','<NumberMicrochipReasons>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<RefusedToSignDeclaration>','<NumberMicrochipReasons>'
	And I verify GB check report with details of outcome '<DetailsOfOutcome>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | CannotFindMicrochip | PassengerType        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | NumberOtherIssues | AuthPersonButNoConfirmation | RefusedToSignDeclaration | ApplicationRadio     | DetailsOfOutcome          |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | CannotFindMicrochip | Ferry foot passenger | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | 2                 | AuthPersonButNoConfirmation | RefusedToSignDeclaration | Search by PTD number | Verify Details of Outcome |
	| Ferry          | Birkenhead to Belfast (Stena) | 0                      | No                  | Ferry foot passenger | 2               | PassengerReferredDAERA | No                       | PassengerWillNotTravel | 1                 | No                          | RefusedToSignDeclaration | Search by PTD number | None                      |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | CannotFindMicrochip | Ferry foot passenger | 1               | PassengerReferredDAERA | No                       | No                     | 0                 | No                          | No                       | Search by PTD number | None                      |

	
Scenario Outline: Validate GB Check Report page fields for SPS User
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
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<RefusedToSignDeclaration>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	And I click on view on Checks page
	When click on signout button on CP and verify the signout message
	And I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time with SPS user
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	When I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthPersonButNoConfirmation>','<NumberMicrochipReasons>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<RefusedToSignDeclaration>','<NumberMicrochipReasons>'
	And I verify GB check report with details of outcome '<DetailsOfOutcome>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | CannotFindMicrochip | PassengerType        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | NumberOtherIssues | AuthPersonButNoConfirmation | RefusedToSignDeclaration | ApplicationRadio     | DetailsOfOutcome           |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | CannotFindMicrochip | Ferry foot passenger | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | 2                 | AuthPersonButNoConfirmation | RefusedToSignDeclaration | Search by PTD number | Pet details does not match |
	| Ferry          | Birkenhead to Belfast (Stena) | 0                      | No                  | Ferry foot passenger | 2               | PassengerReferredDAERA | No                       | PassengerWillNotTravel | 1                 | No                          | RefusedToSignDeclaration | Search by PTD number | None                       |
	| Ferry          | Birkenhead to Belfast (Stena) | 0                      | No                  | Ferry foot passenger | 1               | PassengerReferredDAERA | No                       | No                     | 1                 | AuthPersonButNoConfirmation | No                       | Search by PTD number | None                       |


Scenario Outline: Validate GB Check Report page fields for duplicate checks for GB User
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
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page	
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page	
	And I click '<PassengerType>' in Passenger details	
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And click on Save outcome
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
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<RefusedToSignDeclaration>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	When I click on view on Checks page
	Then I verify referred to SPS record count '1' on page
	And I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthPersonButNoConfirmation>','<NumberMicrochipReasons>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<RefusedToSignDeclaration>','<NumberMicrochipReasons>'
	And I verify GB check report with details of outcome '<DetailsOfOutcome>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | CannotFindMicrochip | PassengerType        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | NumberOtherIssues | AuthPersonButNoConfirmation | RefusedToSignDeclaration | ApplicationRadio     | DetailsOfOutcome          |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | CannotFindMicrochip | Ferry foot passenger | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | 2                 | AuthPersonButNoConfirmation | RefusedToSignDeclaration | Search by PTD number | Verify Details of Outcome |

@RunOnly
Scenario Outline: Validate GB Check Report page fields for duplicate checks for SPS User
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
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Other issues '<AuthPersonButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<RefusedToSignDeclaration>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter details of outcome '<DetailsOfOutcome>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	And I click on view on Checks page
	When click on signout button on CP and verify the signout message
	And I navigate to the port checker application
	And I click signin button on port checker application
	And I have provided the password for prototype research page
	And I have provided the CP credentials and signin for user 'SPSUser'
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time with SPS user
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click on view on Checks page with SPS user for '<FerryRoute>'
	Then I verify referred to SPS record count '1' on page
	When I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthPersonButNoConfirmation>','<NumberMicrochipReasons>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<RefusedToSignDeclaration>','<NumberMicrochipReasons>'
	And I verify GB check report with details of outcome '<DetailsOfOutcome>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | CannotFindMicrochip | PassengerType        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | NumberOtherIssues | AuthPersonButNoConfirmation | RefusedToSignDeclaration | ApplicationRadio     | DetailsOfOutcome           |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | CannotFindMicrochip | Ferry foot passenger | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | 2                 | AuthPersonButNoConfirmation | RefusedToSignDeclaration | Search by PTD number | Pet details does not match |

