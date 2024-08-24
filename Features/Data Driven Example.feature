Feature: Data Driven Example

Youtube search
@Testing
Scenario Outline: Data Driven Example
	Given Open the Chrome browser
	When Browse the url
	Then search with <searchKey>
	Examples:
	| searchKey    |
	| Testers Talk |
	| Selenium C#  |


