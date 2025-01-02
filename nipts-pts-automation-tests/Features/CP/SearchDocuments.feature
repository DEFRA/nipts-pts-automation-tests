@CPRegression
Feature: Search Clear Documents Number

As a PTS port checker I want ot Clear documents number from Find a document search box


Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

	
	Scenario Outline: Verify validation text for blank PTD Number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) |           |

Scenario Outline: Verify validation of less than 6 PTD Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 12345	 |

Scenario Outline: Verify validation of more than 6 PTD Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 1234567   |

Scenario Outline: Verify validation provide invalid 6 PTD Number format and navigate to Document not found page 
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should navigate to Document not found page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | 123456    |

Scenario Outline: Verify validation of special characters with PTD number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | @@@@@$$&  |

Scenario Outline: Verify validation for blank Application Number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio			  |
	| Ferry          | Birkenhead to Belfast (Stena) |			       | Search by application number |

Scenario Outline: Verify validation of Wrong Application Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters" in Find a document page
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio			  |
	| Ferry          | Birkenhead to Belfast (Stena) | QRWD9DZ		   | Search by application number |

Scenario Outline: Verify validation of special characters with Application number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters, using only letters and numbers" in Find a document page
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio			  |
	| Ferry          | Birkenhead to Belfast (Stena) | @@@@@$$&		   | Search by application number |

Scenario Outline: Verify validation with correct format invalid application number and navigate to Document not found page
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	When I click search button
	Then I should navigate to Document not found page
Examples:
	| Transportation | FerryRoute                    | ReferenceNumber | ApplicationRadio			  |
	| Ferry          | Birkenhead to Belfast (Stena) | QRWD9DZQ		   | Search by application number |

Scenario Outline: Verify validation for blank Microchip number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio		    |
	| Ferry          | Birkenhead to Belfast (Stena) |				   | Search by microchip number |

Scenario Outline: Verify validation for special characters Microchip number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio		    |
	| Ferry          | Birkenhead to Belfast (Stena) | @@@@@$$&		   | Search by microchip number |

Scenario Outline: Verify validation for more than 15 Microchip number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber  | ApplicationRadio		    |
	| Ferry          | Birkenhead to Belfast (Stena) | 1234560890123405 | Search by microchip number |

	
Scenario Outline: Verify validation for less than 15 Microchip number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber | ApplicationRadio		    |
	| Ferry          | Birkenhead to Belfast (Stena) | 12345608901234  | Search by microchip number |

	
Scenario Outline: Verify validation for invalid 15 Microchip number and and navigate to Document not found page  
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	When I click search button
	Then I should navigate to Document not found page
Examples:
	| Transportation | FerryRoute                    | MicrochipNumber	| ApplicationRadio		     |
	| Ferry          | Birkenhead to Belfast (Stena) | 123456089012340  | Search by microchip number |

