Feature: Open Library Books API

  Scenario: Validate books API responses
    Given I send a GET request to the Open Library endpoint
    Then the response status code should be 200
    And the response time should be less than <ResponseTime> milliseconds
    And the book response should contains <SearchNumber> results
	And the returned book details should be correct 
    And the thumbnail images should match the stored images

    Examples: 
      | ResponseTime | SearchNumber |
      |         2000 |            3 |
      

#Additional scenarios 
#Validate the API responses, such as checking for specific book titles, authors, or publication dates in the response.
#Invalid ISBN returns empty result
#Validate no sensitive headers are exposed
#Verify that the API handles edge cases, such as searching for a non-existent book or using special characters in the search query.
#Verify HTTPS
#Verify that the API returns appropriate error messages for invalid requests, such as missing required parameters or invalid ISBN formats.
#Validate that the API supports pagination and returns the correct number of results per page when requested.
#Validate that the API returns consistent results for the same search query across multiple requests, ensuring data integrity and reliability.
