Feature: Todo
	In order to remember what I have to do
	As a user
	I want to maintain tasks in a list

Scenario: Add a task
	When I enter "Added Task" 
	And I press add
	Then the task "Added Task" should be added to the list

Scenario: Delete a task
	Given the task "Delete me" is in the list
	When I delete the "Delete me" task 
	Then the task "Delete me" should be removed from the list