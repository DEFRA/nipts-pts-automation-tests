@Validations @APGBRegression 
Feature: Pet Ownder Details Validations

Validating the negative scenarios for Pet Owner Details

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Verify pet owner details page validations and should not moves to next page
	When I click on continue button from Are your details correct page
	Then I should see an error message '<ErrorMessage>' in pet owner details page

Examples:
	 |  ErrorMessage						 |
	 |  Select if your details are correct	 |

Scenario Outline: Verify full name should not allows exceed limits
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should not be redirected to What is your postcode page
	And I should see an error message '<ErrorMessage>' in What is your full name page

Examples:
	| FullName                                                                                                                                                                                                                                                                                                                 | Are your details correct | ErrorMessage								       |
	| ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ | No                       | Enter your full name, using 300 characters or less |
	|                                                                                                                                                                                                                                                                                                                          | No                       | Enter your full name							   |

Scenario Outline: Verify pet owner phone number page validations and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should see an error message '<ErrorMessage>' in What is your phone number page
	And I should not be redirected to the Is your pet microchipped page

Examples:
	| FullName |  Are your details correct | PostCode | PhoneNumber                                                        | ErrorMessage                                               |
	| PetCat's |  No                       | CV2 4NZ  |                                                                    | Enter your phone number			                        |
	| PetDog's |  No                       | CV1 4PY  | ABCDEFGHAD                                                         | Enter your phone number, like 01632 960 001 or 07700 900 982	|
	| PetDog's |  No                       | CV1 4PY  | 075515528680755155286807551552868075515528680755155286807551552868 | Enter your phone number, like 01632 960 001 or 07700 900 982  |

Scenario Outline: Verify postcode search page validations and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see an error message '<ErrorMessage>' in What is your postcode page

Examples:
	| FullName |  Are your details correct | PostCode                           | ErrorMessage																|
	| PetCat's |  No                       |                                    | Enter your postcode															|
	| PetCat's |  No                       | ABC121C                            | Enter your postcode in England, Scotland or Wales						    |
	| PetDog's |  No                       | &&ABC1$$	        				| Enter your full postcode in the correct format, for example TF7 5AY or TF75AY|
	| PetDog's |  No                       | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGH | Enter your full postcode in the correct format, for example TF7 5AY or TF75AY|
	| PetDog's |  No                       | IM1 1AX                            | Enter your postcode in England, Scotland or Wales							|

Scenario Outline: Verify postcode search page by not selecting an address from dropdownlist and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	And I click Continue button from What is your postcode page
	Then I should see an error message '<ErrorMessage>' in What is your postcode page

Examples:
	| FullName |  Are your details correct | PostCode | ErrorMessage                      |
	| PetCat's |  No                       | CV2 4NY  | Select your address from the list |

Scenario Outline: Verify enter address manually validations with all fields blank
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I click Continue button from What is your address page
	Then I should see an error message '<ErrorMessages>' in What is your address page

Examples:
	| FullName |  Are your details correct | Address | ErrorMessages													    |
	| PetDog's |  No                       |         | Enter line 1 of your address,Enter your town or city,Enter your postcode   |
	
Scenario Outline: Verify enter address manually validations with maximum limit characters for each fields
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	Then I have provided address details as '<Address>' for each field
	When I click Continue button from What is your address page
	Then I should see an error message '<ErrorMessages>' in What is your address page

Examples:
	| FullName | Are your details correct | Address                                                                                                                                                                                                                                                            | ErrorMessages                                                                                                                                                                                                                                                                                |
	| PetDog's | No                       | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX | Enter line 1 of your address using 250 characters or less,Enter line 2 of your address using 250 characters or less,Enter your town or city using 250 characters or less,Enter your county using 100 characters or less,Enter your full postcode in the correct format, for example TF7 5AY or TF75AY |


Scenario Outline: Verify enter address manually validations with invalid postcode, special characters and exceed limits
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	Then I provided the postcode '<PostCode>'
	When I click Continue button from What is your address page
	Then I should see an error message '<ErrorMessages>' in What is your postcode page

Examples:
	| FullName |  Are your details correct | PostCode                           | ErrorMessages																     					  |
	| PetCat's |  No                       |                                    | Enter your postcode																					  |
	| PetCat's |  No                       | @ABC121C                           | Enter your full postcode in the correct format, for example TF7 5AY or TF75AY                          |
	| PetDog's |  No                       | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGH | Enter your full postcode in the correct format, for example TF7 5AY or TF75AY					      |
	| PetDog's |  No                       | BT9 7EP                            | Enter your postcode in England, Scotland or Wales												      |