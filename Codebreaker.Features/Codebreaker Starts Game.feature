Feature: Code-breaker Starts Game
	
	As a code-breaker
	I want to start a game
	So that I can break the code

@codeBreaker
Scenario: Start game
	Given I am not playing yet
	When I start a new game
	Then I should see "Welcome to Codebreaker!"
	And I should see "Enter guess:"
