@PETS @APGBRegression 
Feature: PetsHomePageFooterLinks

Checking the header, footer, GetHelp and Feedback Hyperlinks

Background: 
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin

Scenario: Checking the Feedback Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Feedback Link
	Then I should navigate to the Feedback details correct page
	And click on signout button and verify the signout message on pets

#Scenario: Checking the Gethelp Hyperlink
#	Then I should navigate to Lifelong pet travel documents page
#	And  I click the Gethelp Link
#	Then I should navigate to the Gethelp details correct page
#	And click on signout button and verify the signout message on pets

Scenario: Checking the AccessibilityStatement Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the AccessibilityStatement Link
	Then I should navigate to the AccessibilityStatement details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the Cookies Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the PrivacyNotice Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the PrivacyNotice Link
	Then I should navigate to the PrivacyNotice details correct page

Scenario: Checking the TermsAndConditions Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the TermsAndConditions Link
	Then I should navigate to the TermsAndConditions details correct page
	And click on signout button and verify the signout message on pets

Scenario: Checking the CrownCopyright Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the CrownCopyright Link
	Then I should navigate to the CrownCopyright details correct page
	When that I navigate to the DEFRA application
	Then click on signout button and verify the signout message on pets
