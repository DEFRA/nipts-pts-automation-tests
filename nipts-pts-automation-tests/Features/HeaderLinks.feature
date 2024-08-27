@Regression
Feature: HeaderLinks

Pets header page
	
	
	Scenario: Check header page links
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language 
	Then  verify header title '<title>'
	Then  verify header banner '<bannerText>'
	When  click on the feedback link
	And   switch to next opened tab
	Then  verify feedback page is loaded
	When  switch to previous tab
	And   Click on GOV.UK link in the header of the page
	Then  verify generic GOV page is loaded

	Examples: 
	| logininfo | title                                                  | bannerText                         |
	| test      | Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Mae hwn yn wasanaeth newydd - bydd |
