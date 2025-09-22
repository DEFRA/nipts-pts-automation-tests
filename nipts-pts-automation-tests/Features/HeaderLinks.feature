@Regression
Feature: HeaderLinks

Pets header page
	
	
	Scenario: Check header page links
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify header title '<GBtitle>'
	Then  verify header banner '<GBbannerText>'
	When  click on Welsh language 
	Then  verify header title '<title>'
	Then  verify header banner '<bannerText>'
	When  click on the feedback link
	And   switch to next opened tab
	Then  verify feedback page is loaded
	And   verify feedback page text 'Your feedback will help us improve the service.' is correct
	And   verify link 'Accessibility statement (opens in a new tab)' on feedback page text
	When  switch to previous tab
	And   Click on GOV.UK link in the header of the page
	Then  verify generic GOV page is loaded

	Examples: 
	| logininfo | title                                                  | bannerText                             | GBtitle                                             | GBbannerText                                  |
	| test      | Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Mae hwn yn wasanaeth newydd. Bydd eich | Taking a pet from Great Britain to Northern Ireland | This is a new service. Help us improve it and |


Scenario: Verify Cookies Banner in WELSH
	Given delete browser cookies
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language
	Then  verify header title '<title>'
	Then  verify cookies banner '<cookiesText>' in WELSH

	Examples: 
	| logininfo | title                                                  | cookiesText                         |
	| test      | Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon |

Scenario: Verify text for accepted cookies Banner in WELSH
	Given delete browser cookies
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language
	Then  verify header title '<title>'
	Then  verify cookies banner '<cookiesText>' in WELSH
	And   click on cookies preference button '<CookiesPrefBtn>' button in WELSH on cookies banner
	Then  verify text on the cookies preference banner '<SelectedCookiesText>'

	Examples: 
	| logininfo | title                                                  | cookiesText                                                     | SelectedCookiesText                     | CookiesPrefBtn |
	| test      | Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Rydych chi wedi derbyn cwcis ychwanegol | Derbyn cwcis ychwanegol |

Scenario: Verify text for rejected cookies Banner in WELSH
	Given delete browser cookies
	Given that I navigate to the Pets application portal
	When  sign in with valid credentials with logininfo '<logininfo>'
	When  click on Welsh language
	Then  verify header title '<title>'
	Then  verify cookies banner '<cookiesText>' in WELSH
	And   click on cookies preference button '<CookiesPrefBtn>' button in WELSH on cookies banner
	Then  verify text on the cookies preference banner '<SelectedCookiesText>'

	Examples: 
	| logininfo | title                                                  | cookiesText                                                     | SelectedCookiesText                     | CookiesPrefBtn |
	| test      | Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon | Rydych chi wedi gwrthod cwcis ychwanegol | Gwrthod cwcis ychwanegol |
