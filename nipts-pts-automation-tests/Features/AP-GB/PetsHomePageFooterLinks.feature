@APGBRegression 
Feature: PetsHomePageFooterLinks

Checking the header, footer, GetHelp and Feedback Hyperlinks

Scenario: Checking the Feedback Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Feedback Link
	Then I should navigate to the Feedback details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the AccessibilityStatement Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the AccessibilityStatement Link
	Then I should navigate to the AccessibilityStatement details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the Cookies Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the PrivacyNotice Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the PrivacyNotice Link
	Then I should navigate to the PrivacyNotice details correct page

Scenario: Checking the TermsAndConditions Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the TermsAndConditions Link
	Then I should navigate to the TermsAndConditions details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the CrownCopyright Hyperlink
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should navigate to Lifelong pet travel documents page
	And  I click the CrownCopyright Link
	Then I should navigate to the CrownCopyright details correct page
	When that I navigate to the DEFRA application
	Then click on signout button and verify the signout message on pets

Scenario Outline: Checking the updated dashboard on homepage
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I verify PTD table heading '<Petname>' on homepage
	Then I verify PTD table heading '<Status>' on homepage

Examples:
	| Petname  | Status |
	| Pet name | Status |

Scenario Outline: Verify Footer links and pages on Pets without login
	Given open Cookies link page without login
	Then  verify the page title in Footer page '<Cookies page Title>'
	And   verify the link in Footer page details '<Cookies Link 1>'
	When  open Accessibility link page without login
	Then  verify the page title in Footer page '<Accessibility page title>'
	And   verify the link in Footer page details '<Accessibility Link 1>'
	And   verify the link in Footer page details '<Accessibility Link 2>'
	When  open TCs link page without login
	Then  verify the page title in Footer page '<TCs page title>'
	Then  verify the link in Footer page details '<TCs Link 1>'
	Then  verify the link in Footer page details '<TCs Link 2>'

Examples: 
    | Cookies page Title | Cookies Link 1                           | Accessibility page title                                           | Accessibility Link 1          | Accessibility Link 2                         | TCs page title                                          | TCs Link 1                             | TCs Link 2                           |
    | Cookies            | website for the Information Commissioner | Taking a dog, cat or ferret from Great Britain to Northern Ireland | AbilityNet (opens in new tab) | Find out about call charges (open in new tab)| Northern Ireland Pet Travel Scheme terms and conditions | Windsor Framework (opens in a new tab) | Read more about commercial movements |

