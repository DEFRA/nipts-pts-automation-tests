﻿@CPRegression
Feature: Search Clear Documents Number

As a PTS port checker I want ot Clear documents number from Find a document search box


Background: 
	Given I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

	Scenario Outline: Verify validation text for No radio button selection on document search page
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	When I click search button
	Then I should see an error message "Select if you are searching for a PTD, application or microchip number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | 
	| Ferry          | Birkenhead to Belfast (Stena) |

	Scenario Outline: Verify text is retained in the textbox when switching between radio buttons
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	And I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	And I click search by '<ApplicationRadio2>' radio button
	And I provided the Application Number '<ReferenceNumber>' of the application
	Then I click search by '<ApplicationRadio>' radio button
	And verify the text '<PTDNumber>' in the textbox for the selected radio button '<ApplicationRadio>'
    When I click search by '<ApplicationRadio3>' radio button
	And I provided the Microchip number '<MicrochipNumber>' of the application
	And I click search by '<ApplicationRadio2>' radio button
	Then verify the text '<ReferenceNumber>' in the textbox for the selected radio button '<ApplicationRadio2>'
    When I click search by '<ApplicationRadio3>' radio button
	Then verify the text '<MicrochipNumber>' in the textbox for the selected radio button '<ApplicationRadio3>'

Examples:
	| Transportation | FerryRoute                    | ApplicationRadio     | PTDNumber | ApplicationRadio2            | AppNumber | ReferenceNumber | ApplicationRadio3          | MicrochipNumber |
	| Ferry          | Birkenhead to Belfast (Stena) | Search by PTD number | C93213    | Search by application number | PSZLLSM3  | QRWD9DZQ        | Search by microchip number | 123456789123456 |

	Scenario Outline: Verify validation text for blank PTD Number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) |           | Search by PTD number |

Scenario Outline: Verify validation of less than 6 PTD Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 12345     | Search by PTD number |

Scenario Outline: Verify validation of more than 6 PTD Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 1234567   | Search by PTD number |

Scenario Outline: Verify validation of alphabets other than A-F PTD Number format
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826', using only letters A-F and numbers" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | C9321G    | Search by PTD number |

Scenario Outline: Verify validation provide invalid 6 PTD Number format and navigate to Document not found page 
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should navigate to Document not found page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | 123456    | Search by PTD number |

Scenario Outline: Verify validation of special characters with PTD number
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by '<ApplicationRadio>' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | ApplicationRadio     |
	| Ferry          | Birkenhead to Belfast (Stena) | @@@@@$$&  | Search by PTD number |

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
	Then I should see an error message "Enter 8 characters using letters and numbers, for example MOG2TXF7" in Find a document page
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
	Then I should see an error message "Enter 8 characters using letters and numbers" in Find a document page
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

