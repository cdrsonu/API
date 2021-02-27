Feature: Actor Resource


Scenario: Get ALL Actor
	Given I am a client
	When I make GET Request 'api/actor/all'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Mila Kunis","bio":"--","gender":"Female","dob":"1986-11-14T00:00:00"},{"id":2,"name":"George Michael","bio":"--","gender":"Male","dob":"1978-11-23T00:00:00"}]'


Scenario: Get Actor 
	Given I am a client
	When I make GET Request 'api/actor/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Mila Kunis","bio":"--","gender":"Female","dob":"1986-11-14T00:00:00"}'

Scenario: Add Actor 
	Given I am a client
	When I am making a post request to 'api/actor' with the following Data '{"name": "New Actor","bio": "--","gender": "Male","dob": "2021-02-25T08:02:15.613Z"}'
	Then response code must be '200'

Scenario: Delete Actor 
	Given I am a client
	When I make Delete Request 'api/actor/1'
	Then response code must be '200'

Scenario: Update Actor 
	Given I am a client
	When I make PUT Request 'api/actor/3' with the following Data with the following Data '{"name": "Test Actor","bio": "--","gender": "Male","dob": "2021-02-25T08:02:15.613Z"}'
	Then response code must be '200'

