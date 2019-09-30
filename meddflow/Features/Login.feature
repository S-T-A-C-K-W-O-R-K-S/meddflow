Feature: Login
  In order to access my account
  As a user of the website
  I should be able to log in using my username and password

@authentication
Scenario: Logging in with valid credentials
  Given I am on the login page
  When I enter my username and password
  | Username       | Password   |
  | BRL.Automation | aut0mati0n |
  And I click the login button
  Then I should be authenticated to the application home page
