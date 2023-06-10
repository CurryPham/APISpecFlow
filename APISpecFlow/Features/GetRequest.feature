Feature: GetRequest

A short summary of the feature

@tag1
Scenario: Get Request Testing
	Given User send a request with url as "https://reqres.in/api/users/2"
	Then  Request should be a success with 200 codes
