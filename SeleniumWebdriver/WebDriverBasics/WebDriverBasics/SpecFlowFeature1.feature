Feature: LogOff
	In order to check we can log off
	As a logged in user 
	I want to log off

@mytag
Scenario Outline: Log off from yandex.mail
	Given I login with valid <username> and <password>
	When I press log off button
	Then I on yandex login page
Examples: 
| username          | password  |
| seleniumTestEpam3 | 24514125s |
| seleniumTestEpam1 | 24514125s |