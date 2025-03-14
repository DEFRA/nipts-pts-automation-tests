@CPRegression
Feature: CP Route Checking Validation

Validating the negative scenarios for Route Checking Information

Background: 
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	

Scenario Outline: Verify validation text for not selection checking a ferry or a flight​
	Then I have selected '<Transportation>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error '<ErrorMessage>' in route checking page
Examples:
	| Transportation | ErrorMessage                                   |
	|                | Select if you are checking a ferry or a flight |

Scenario Outline: Verify validation text for not selection checking a ferry options
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Select the ferry you are checking" in route checking page
Examples:
	| Transportation | FerryRoute |
	| Ferry  	     |			  |

Scenario Outline: Verify validation text for empty text box checking a flight
	Then I have selected '<Transportation>' radio option
	Then I provide the '<Flight number>' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the flight number. For example, RK 103" in route checking page
Examples:
	| Transportation | Flight number |
	| Flight         |               |		
	
Scenario Outline: Verify validation text when user enter More or less than 8 alphanumeric values
	Then I have selected '<Transportation>' radio option
	Then I provide the '<Flight number>' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the flight number using up to 8 letters and numbers (for example, RK 103)" in route checking page
Examples:
	| Transportation | Flight number |
	| Flight         | abc 123456    |	
	
Scenario Outline: Verify validation text for special character text box checking a flight
	Then I have selected '<Transportation>' radio option
	Then I provide the '<FlightNumber>' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the flight number using up to 8 letters and numbers (for example, RK 103)" in route checking page
Examples:
	| Transportation | FlightNumber |
	| Flight         | $$£@lk       |

	Scenario Outline: Verify validation text for not selection Schedule Departure Date
	Then I have selected '<Transportation>' radio option
	Then I have selected '<ScheduledDepartureDay>''<ScheduledDepartureMonth>''<ScheduledDepartureYear>'Date option
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure date, for example 27 3 2024" in route checking page
Examples:
	| ScheduledDepartureDay | ScheduledDepartureMonth | ScheduledDepartureYear | Transportation | Flight number |
	|                       |                         |                        | Flight         | 1234          |

Scenario Outline: Verify validation text special characters for  Schedule Departure Date
	Then I have selected '<Transportation>' radio option
	Then I have selected '<ScheduledDepartureDay>''<ScheduledDepartureMonth>''<ScheduledDepartureYear>'Date option
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page
Examples:
	| ScheduledDepartureDay | ScheduledDepartureMonth | ScheduledDepartureYear | Transportation | Flight number |
	| @@                    |  @@                     | @@                     | Flight         | 1234          |

Scenario Outline: Verify validation text  for date field when user left any one of the columnin empty and more values on other column for  Schedule Departure Date
	Then I have selected '<Transportation>' radio option
	Then I have selected '<ScheduledDepartureDay>''<ScheduledDepartureMonth>''<ScheduledDepartureYear>'Date option
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page
Examples:
	| ScheduledDepartureDay | ScheduledDepartureMonth | ScheduledDepartureYear | Transportation | Flight number |
	|                       |  01                     | 29876987               | Flight         | 1234          |

Scenario Outline: Verify validation text  for date field when user enter the date field that exceeds 48 hours before
	Then I have selected '<Transportation>' radio option
	Then I provided date less than 48 hours from the current date
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "The flight or ferry must have departed in the past 48 hours or departs within the next 24 hours" in route checking page
Examples:
	| Transportation | Flight number |
	| Flight         | 1234          |

Scenario Outline: Verify validation text  for date field when user enter the date field that exceeds 24 hours after
	Then I have selected '<Transportation>' radio option
	Then I provided date more than 24 hours from the current date
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "The flight or ferry must have departed in the past 48 hours or departs within the next 24 hours" in route checking page
Examples:
	| Transportation | Flight number |
	| Flight         | 1234          |

Scenario Outline: Verify validation text for blank Schedule Departure Time
	Then I have selected '<Transportation>' radio option
	Then I have selected '<ScheduledDepartureDay>''<ScheduledDepartureMonth>''<ScheduledDepartureYear>'Date option
	Then I provide the '<Flight number>' in the box
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page
Examples:
	| ScheduledDepartureDay | ScheduledDepartureMonth | ScheduledDepartureYear | Transportation | Flight number |
	| 19                    | 10                      | 2024                   | Flight         | 1234          |

Scenario Outline: Verify validation text for blank hour field and enter value in minutes field Schedule Departure Time
	Then I have selected '<Transportation>' radio option
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time in hours field only
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page
Examples:
	| ScheduledDepartureDay | ScheduledDepartureMonth | ScheduledDepartureYear | Transportation | Flight number |
	| 19                    | 10                      | 2024                   | Flight         | 1234          |

Scenario Outline: Verify validation text  for date field when user enter the time field that exceeds 24 hours after
	Then I have selected '<Transportation>' radio option
	Then I provided date that exceeds 24 hours from the current date
	Then I provided time that exceeds 24 hours from the current time
	Then I provide the '<Flight number>' in the box
	When I click save and continue button from route checke page
	Then I should see an error message "The flight or ferry must have departed in the past 48 hours or departs within the next 24 hours" in route checking page
Examples:
	| Transportation | Flight number |
	| Flight         | 1234          |

Scenario Outline: Verify positive flow for date field when user enter the date field within 48 hours
	Then I have selected '<Transportation>' radio option
	Then I provided date within 48 hours from the current date
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
Examples:
	| Transportation | Flight number |
	| Flight         | 1234          |
Scenario Outline: Verify positive flow for date field when user enter the date field within 24 hours
	Then I have selected '<Transportation>' radio option
	Then I provided date that exceeds 24 hours from the current date
	Then I provide the '<Flight number>' in the box
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
Examples:
	| Transportation | Flight number |
	| Flight         | 1234          |

Scenario Outline: Verify filter functionality for ferry route 
	When Create an application via backend
	And Approve an application via backend
	And I have captured pet details
	And I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	And verify the route details on the welcome page for ferry '<FerryRoute>'

Examples:
	| Transportation | FerryRoute                   | 
	| Ferry          | Loch Ryan to Belfast (Stena) | 

