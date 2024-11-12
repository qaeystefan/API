Feature: API Requests

   @POST
  Scenario: Make a POST request with body and token
    Given I have a valid token
    And I have a JSON payload named "PostPayload.json"
    When I make a POST request to the "postEndpoint"
    Then the response should be successful

    @GET
  Scenario: Make a GET request
    Given I have a valid token
    When I make a GET request to the "getEndpoint"
    Then the response should be successful

    @UPDATE
  Scenario: Make an UPDATE request
    Given I have a valid token
    And I have a JSON payload named "PatchPayload.json"
    When I make an UPDATE request to the "updateEndpoint"
    Then the response should be successful

    @DELETE
  Scenario: Make a DELETE request
    Given I have a valid token
    When I make a DELETE request to the "deleteEndpoint"
    Then the response should be successful