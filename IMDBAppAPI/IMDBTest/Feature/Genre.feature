Feature: Genre Resource


Scenario: Get All Genre
	Given I am a client
	When I make GET Request 'api/Genre/all'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Action"},{"id":2,"name":"Thrill"},{"id":3,"name":"Drama"}]'


Scenario: Get Genre 
	Given I am a client
	When I make GET Request 'api/Genre/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Action"}'

Scenario: Add Genre 
	Given I am a client
	When I am making a post request to 'api/Genre' with the following Data '{"name":"Thrill"}'
	Then response code must be '200'

Scenario: Delete Genre 
	Given I am a client
	When I make Delete Request 'api/Genre/1'
	Then response code must be '200'

Scenario: Update Genre 
	Given I am a client
	When I make PUT Request 'api/Genre/2' with the following Data with the following Data '{"name":"Romance"}}'
	Then response code must be '200'

