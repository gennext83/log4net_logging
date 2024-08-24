Feature: Trimark Feature

Youtube search
@Trimark
Scenario: Trimark Feature
	Given Browse the New Staging URL
	And Login to the New Staging
	And Navigate to the Sites page
	And Navigate to the Devices page
	When Add a Device
	Then Quit the browser

Scenario: Add a Point
	Given Browse the New Staging URL
	And Login to the New Staging
	And Navigate to the Sites page
	And Navigate to the Points page
	When Add a Derived Point
	Then Quit the browser

Scenario: Search a Point
    Given Browse the New Staging URL
	And Login to the New Staging
	And Navigate to the Sites page
	And Navigate to the Points page
	When Search the point
	Then Quit the browser

Scenario: Portfolio Historical Trend Page
    Given Browse the New Staging URL
    And  Login to the New Staging
	And Navigate to the Sites page
    And  Navigate to the Portfolio Historical Trend Page
    And  Add points to the Page


