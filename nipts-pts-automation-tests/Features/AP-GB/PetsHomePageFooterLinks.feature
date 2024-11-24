@PETS @APGBRegression 
Feature: PetsHomePageFooterLinks

Checking the header, footer, GetHelp and Feedback Hyperlinks

Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

Scenario: Checking the Feedback Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Feedback Link
	Then I should navigate to the Feedback details correct page

Scenario: Checking the Gethelp Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Gethelp Link
	Then I should navigate to the Gethelp details correct page

Scenario: Checking the AccessibilityStatement Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the AccessibilityStatement Link
	Then I should navigate to the AccessibilityStatement details correct page

Scenario: Checking the Cookies Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page

Scenario: Checking the PrivacyNotice Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the PrivacyNotice Link
	Then I should navigate to the PrivacyNotice details correct page

Scenario: Checking the TermsAndConditions Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the TermsAndConditions Link
	Then I should navigate to the TermsAndConditions details correct page

Scenario: Checking the CrownCopyright Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the CrownCopyright Link
	Then I should navigate to the CrownCopyright details correct page