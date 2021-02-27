Feature: Producer Resource


Scenario: Get All Producer
	Given I am a client
	When I make GET Request 'api/producer/all'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Arjun","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"},{"id":2,"name":"Arun","bio":"--","gender":"Male","dob":"2004-09-11T00:00:00"}]'

Scenario: Get Producer 
	Given I am a client
	When I make GET Request 'api/producer/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Arjun","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"}'

Scenario: Add Producer 
	Given I am a client
	When I am making a post request to 'api/actor' with the following Data '{"name":"Robin","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"}'
	Then response code must be '200'

Scenario: Delete Producer 
	Given I am a client
	When I make Delete Request 'api/producer/10'
	Then response code must be '200'
Scenario: Update Producer 
	Given I am a client
	When I make PUT Request 'api/producer/10' with the following Data with the following Data '{"name":"UpdatedName","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"}'
	Then response code must be '200'
