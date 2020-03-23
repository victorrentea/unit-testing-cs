Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered <a> into the calculator
	And I have entered <b> into the calculator
	When I press add
	Then the result should be <ab> on the screen

	Examples: 
	| a  | b  | ab |
	| 50 | 70 |120|
	| 50 | 80 |130|
