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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select MicrochipReason '<MicrochipNumberNoMatch>' on Report non-compliance page
	And I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Visual check '<PetDoesNotMatchThePTD>' on Report non-compliance page
	And I select Other issues '<PotentialCommercialMovement>' on Report non-compliance page
	And I select Other issues '<AuthorisedTravellerButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<OtherReason>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter relevant comment '<AdditionalComment>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
	When I click on view on Checks page
	And I click on PTD number of the application
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<MicrochipNumberNoMatch>','<NumberOtherIssues>'
	And I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report wiht Visual check '<PetDoesNotMatchThePTD>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<PotentialCommercialMovement>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthorisedTravellerButNoConfirmation>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<OtherReason>'
	And I verify GB check report with relevent comment '<AdditionalComment>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | MicrochipNumberNoMatch | CannotFindMicrochip | PassengerType        | AdditionalComment        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | PetDoesNotMatchThePTD | NumberOtherIssues | PotentialCommercialMovement | AuthorisedTravellerButNoConfirmation | OtherReason | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 2                      | MicrochipNumberNoMatch | CannotFindMicrochip | Ferry foot passenger | Verify Additonal Comment | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | PetDoesNotMatchThePTD | 3                 | PotentialCommercialMovement | AuthorisedTravellerButNoConfirmation | OtherReason | Search by PTD number |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | 2               | PassengerReferredDAERA | No                       | PassengerWillNotTravel | PetDoesNotMatchThePTD | 2                 | PotentialCommercialMovement | No                                   | OtherReason | Search by PTD number |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | 1               | PassengerReferredDAERA | No                       | No                     | No                    | 0                 | No                          | No                                   | No          | Search by PTD number |

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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select MicrochipReason '<MicrochipNumberNoMatch>' on Report non-compliance page
	And I select MicrochipReason '<CannotFindMicrochip>' on Report non-compliance page
	And I select Visual check '<PetDoesNotMatchThePTD>' on Report non-compliance page
	And I select Other issues '<PotentialCommercialMovement>' on Report non-compliance page
	And I select Other issues '<AuthorisedTravellerButNoConfirmation>' on Report non-compliance page
	And I select Other issues '<OtherReason>' on Report non-compliance page
	And I click '<PassengerType>' in Passenger details
	And I enter relevant comment '<AdditionalComment>'
	And I select GB Outcome '<PassengerReferredDAERA>' on Report non-compliance page
	And I select GB Outcome '<PassengerAdvisedNoTravel>' on Report non-compliance page
	And I select GB Outcome '<PassengerWillNotTravel>' on Report non-compliance page
	And click on Save outcome
	Then I should navigate to Welcome page
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
	Then I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<MicrochipNumberNoMatch>','<NumberOtherIssues>'
	And I verify GB check report with MicrochipReason '<NumberMicrochipReasons>','<CannotFindMicrochip>','<NumberOtherIssues>'
	And I verify GB check report wiht Visual check '<PetDoesNotMatchThePTD>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<PotentialCommercialMovement>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<AuthorisedTravellerButNoConfirmation>'
	And I verify GB check report with Other issues '<NumberOtherIssues>','<OtherReason>'
	And I verify GB check report with relevent comment '<AdditionalComment>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerReferredDAERA>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerAdvisedNoTravel>'
	And I verify GB check report with GB Outcome '<NumberGBOutcome>','<PassengerWillNotTravel>'

Examples:
	| Transportation | FerryRoute                    | NumberMicrochipReasons | MicrochipNumberNoMatch | CannotFindMicrochip | PassengerType        | AdditionalComment        | NumberGBOutcome | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | PetDoesNotMatchThePTD | NumberOtherIssues | PotentialCommercialMovement | AuthorisedTravellerButNoConfirmation | OtherReason | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 2                      | MicrochipNumberNoMatch | CannotFindMicrochip | Ferry foot passenger | Verify Additonal Comment | 3               | PassengerReferredDAERA | PassengerAdvisedNoTravel | PassengerWillNotTravel | PetDoesNotMatchThePTD | 3                 | PotentialCommercialMovement | AuthorisedTravellerButNoConfirmation | OtherReason | Search by PTD number |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | 2               | PassengerReferredDAERA | No                       | PassengerWillNotTravel | PetDoesNotMatchThePTD | 2                 | PotentialCommercialMovement | No                                   | OtherReason | Search by PTD number |
	| Ferry          | Birkenhead to Belfast (Stena) | 1                      | MicrochipNumberNoMatch | No                  | Ferry foot passenger | None                     | 1               | PassengerReferredDAERA | No                       | No                     | No                    | 0                 | No                          | No                                   | No          | Search by PTD number |
