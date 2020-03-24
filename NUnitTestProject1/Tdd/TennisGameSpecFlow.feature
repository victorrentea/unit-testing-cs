Feature: TennisGameSpecFlow
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Empty game
	Given an empty tennis game
	Then the score is "Love - Love"

Scenario: Fifteen Fifteen
	Given an empty tennis game
	When player1 scores 1 point
	Then the score is "Fifteen - Love"

Scenario Outline: Everything
	Given an empty tennis game
	When player1 scores <p1> point
	And player2 scores <p2> point
	Then the score is "<expectedScore>"

	Examples: 
	| p1 | p2 | expectedScore     |
	| 1  | 1  | Fifteen - Fifteen |
	| 7  | 6  | Advantage Player1 |
	| 6  | 6  | Deuce |
