Feature: SellerLanguages

As a seller I would like The languages that I speak be displayed on my Profile page

@tag1
Scenario Outline: Add a new Language on my Profile Page
	Given I navigate to the Languages Section
	When I add a new '<Language>' 
	And I select the '<Level>'
	And I save the new language
	Then The new '<Language>' should be displayed in the Seller Language List
	Examples:
	| Language   | Level          |
	| Bisaya     | Fluent         |
	| Hiligaynon | Conversational |

Scenario Outline: Update an existing Language on my Profile Page
	Given I navigate to the Languages Section
	When I update an existing '<Language>' to a '<New Language>'
	And I update the Level to a '<New Level>' given the current '<Language>'
	And I save the updated '<Language>'
	Then The updated '<New Language>' should be updated successfully
	Examples:
	| Language   | New Language | New Level      |
	| Bisaya     | Tagalog      | Conversational |
	| Hiligaynon | Ilocano      | Basic          |

Scenario: Delete an existing Language on my Profile Page
	Given I navigate to the Languages Section
	When I delete an existing '<Language>'
	Then The existing '<Language>' selected should be deleted successfully
	Examples:
	| Language   |
	| Bohol      |
	| Hiligaynon |
