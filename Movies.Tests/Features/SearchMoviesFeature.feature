Feature: SearchMoviesFeature

Scenario: No search criteria is given
	Given No search criteria is given
	When searching
	Then the result should be bad request

Scenario: Search criteria is given
	Given Search by title 'the'
	When searching
	Then the result should be successful
