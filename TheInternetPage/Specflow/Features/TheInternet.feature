@TheInternet
Feature: TheInternet

Scenario: Verifing checkbox funtionality
	Given anonymous user open TheInternet home page
	And click checkboxes link
	When checkboxes page is opened select checkbox 1
	And unselect checkbox 2
	Then verify if checkbox 1 is selected
	And verify if checkbox 2 is unselected


Scenario: Verifing login process
	Given anonymous user open TheInternet home page
	And click form authentication link
	When page is opened enter username:tomsmith
	And enter password:SuperSecretPassword!
	And click login
	Then verify if user is logged in
