Feature: Movie Resource


Scenario: Get ALL Movie
	Given I am a client
	When I make GET Request 'api/movie/all'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Rocky","yearOfRelease":2010,"plot":"--","actors":[{"id":1,"name":"Mila Kunis","bio":"--","gender":"Female","dob":"1986-11-14T00:00:00"},{"id":2,"name":"George Michael","bio":"--","gender":"Male","dob":"1978-11-23T00:00:00"}],"genres":[{"id":1,"name":"Action"},{"id":3,"name":"Drama"}],"producer":{"id":1,"name":"Arjun","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"},"coverImage":null}]'



Scenario: Get Movie 
	Given I am a client
	When I make GET Request 'api/movie/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Rocky","yearOfRelease":2010,"plot":"--","actors":[{"id":1,"name":"Mila Kunis","bio":"--","gender":"Female","dob":"1986-11-14T00:00:00"},{"id":2,"name":"George Michael","bio":"--","gender":"Male","dob":"1978-11-23T00:00:00"}],"genres":[{"id":1,"name":"Action"},{"id":3,"name":"Drama"}],"producer":{"id":1,"name":"Arjun","bio":"--","gender":"Male","dob":"1998-05-14T00:00:00"},"coverImage":null}'

Scenario: Add Movie 
	Given I am a client
	When I am making a post request to 'api/movie' with the following Data '{"name": "New Actor","bio": "--","gender": "Male","dob": "2021-02-25T08:02:15.613Z"}'
	Then response code must be '200'

Scenario: Delete Movie 
	Given I am a client
	When I make Delete Request 'api/movie/1'
	Then response code must be '200'

Scenario: Update Movie 
	Given I am a client
	When I make PUT Request 'api/actor/1' with the following Data with the following Data '{"name": "Updated Name","yearOfRelease":1980,"plot":"--","actorIds":[1,2],"genreIds":[1,2],"producerId": 1,"coverImage": "--"}'
	Then response code must be '200'

