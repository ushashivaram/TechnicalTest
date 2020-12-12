Feature: MainView
	As A product manager
   I want frontend users to be able to update the database
   So That I dont have to book time with a database administrator

@mytag
Scenario: Verify that the user is in  main view page
    Given that I navigate to the computer database app
    Then I am in the Main View page
	And I see list of the existing computers present in the database
	When I click  on the Add a new computer button
	Then I am in the Add a computer page


Scenario: Verify that it is be possible to open Add New Computer page
    Given that I navigate to the computer database app
	When I click  on the Add a new computer button
	Then I am in the Add a computer page
	When I click on Cancel button on the Add a new computer page
	Then I am in the Main View page

Scenario: Verify that there are  four new fields and two buttons in the Add New Computer page
    Given that I navigate to the computer database app
	When I click  on the Add a new computer button
	Then I am in the Add a computer page
	Then I should see four fields
	| Fields        | Type  |
	| Computer name | input |
	| Introduced    | input |
	| Discontinued  | input |
	| Company       | select|


Scenario: Verify that new computers to be added unless all fields are populated
    Given that I navigate to the computer database app
	When I click  on the Add a new computer button
	Then I am in the Add a computer page
	When I click on Create this computer button
	Then I see required error message


Scenario: Verify user can successfully create a new computer
    Given that I navigate to the computer database app
	When I click  on the Add a new computer button
	Then I am in the Add a computer page
	Then I edit the following fields
	 | Fields        | Values     |
	 | Computer name | Apple Air  |
	 | Introduced    | 2019-12-12 |
	 | Discontinued  | 2020-12-12 |
	 | Company       | Apple Inc. |
	When I click on Create this computer button
	Then I should see success message   