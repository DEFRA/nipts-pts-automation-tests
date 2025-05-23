@Regression 
Feature: FooterLinks

Verify Footer links on Pets


Scenario Outline: Verify Footer links and pages on Pets
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	When  click privacy link on footer page
	And   switch to next opened tab
	Then  verify the page title in Footer page '<Privacy page title>'
	And   verify the link in Footer page details '<Privacy Link 1>'
	And   verify the link in Footer page details '<Privacy Link 2>'
	And   Close Current tab
	And   switch to previous tab
	When  click cookies link on footer page
	Then  verify the page title in Footer page '<Cookies page Title>'
	#And   verify the link in Footer page details '<Cookies Link 1>'
	And   click on back
	When  click accessibility link on footer page
	Then  verify the page title in Footer page '<Accessibility page title>'
	And   verify the link in Footer page details '<Accessibility Link 1>'
	And   verify the link in Footer page details '<Accessibility Link 2>'
	And   click on back
	When  click TCs link on footer page
	Then  verify the page title in Footer page '<TCs page title>'
	Then  verify the link in Footer page details '<TCs Link 1>'

Examples: 
    | logininfo | Privacy page title              |Privacy Link 1		   	   |Privacy Link 2        |Cookies page Title |Cookies Link 1                     |Accessibility page title                |Accessibility Link 1         |Accessibility Link 2                                    | TCs page title                       |TCs Link 1 |
	| test      | Pet travel scheme privacy notice|data.protection@defra.gov.uk|www.legislation.gov.uk|Cookies            |opt out of Google Analytics cookies|Accessibility statement for taking a dog|AbilityNet (opens in new tab)|contact the Equality Advisory and Support Service (EASS)| Northern Ireland Pet Travel Scheme terms and conditions| Windsor Framework  |



Scenario Outline: Verify text and Logo on the footer of Sign up page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	Then  verify text '<FooterText>' on the page footer
	Then  verify the link in Footer page details '<FooterPageLink>'
	Then  verify the link in Footer page details '<FooterLogoLink>'


Examples: 
    | logininfo | nextPage                      | FooterText                         |FooterPageLink              |FooterLogoLink |
    | test      | Lifelong pet travel documents | All content is available under the |Open Government Licence v3.0|Crown copyright|

Scenario Outline: Verify Welsh updated dashboard on home page
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then I verify PTD table heading '<Petname>' on homepage
	Then I verify PTD table heading '<Status>' on homepage

Examples:
	| Petname             | Status | logininfo |
	| Enw’r anifail anwes | Statws | test      |
