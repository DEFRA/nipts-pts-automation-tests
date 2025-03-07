@CPRegression
Feature: Pets WAF rule validation

Validate WAF rule validation page

Scenario Outline: Verify validation page for WAF rule on Flight Number
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	Then I provide the invalid FlightNumber in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to the custom '<nextPage>' is loaded

Examples:
	| Transportation | nextPage                                           |
	| Flight         | You cannot access this page or perform this action |

Scenario Outline: Verify validation page for WAF rule on Day Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	Then I have provided Invalid Day '<ScheduledDepartureMonth>''<ScheduledDepartureYear>'Date option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                     | ScheduledDepartureMonth | ScheduledDepartureYear |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena)  | 12                      | 2024                   |

Scenario Outline: Verify validation page for WAF rule on Month Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	Then I have provided Invalid Month '<ScheduledDepartureDay>''<ScheduledDepartureYear>'Date option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                     | ScheduledDepartureDay   | ScheduledDepartureYear |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena)  | 3                       | 2024                   |

Scenario Outline: Verify validation page for WAF rule on Year Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	Then I have provided Invalid Year '<ScheduledDepartureDay>''<ScheduledDepartureMonth>'Date option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                     | ScheduledDepartureDay   | ScheduledDepartureMonth |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena)  | 4                       | 12                      |

Scenario Outline: Verify validation page for WAF rule on Search PTD number Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Invalid PTD number of the application
	When I click search button
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                    | ApplicationRadio     |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena) | Search by PTD number |

Scenario Outline: Verify validation page for WAF rule on Search Application number Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Invalid Reference number of the application
	When I click search button
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                     |  ApplicationRadio             |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena)  |  Search by application number |

Scenario Outline: Verify validation page for WAF rule on Search Microchip number Field
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Invalid Microchip number of the application
	When I click search button
	Then I should navigate to the custom '<nextPage>' is loaded
Examples:
	| Transportation | nextPage                                           | FerryRoute                     |  ApplicationRadio             |
	| Ferry          | You cannot access this page or perform this action | Birkenhead to Belfast (Stena)  |  Search by microchip number   |
