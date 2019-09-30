Feature: Log Into My Account
  IN ORDER TO ACCESS MY ACCOUNT
  AS A USER OF THE WEBSITE
  I SHOULD BE ABLE TO LOG IN WITH MY EMAIL AND PASSWORD

@authentication
Scenario: Logging In With Valid Credentials
  Given I AM ON THE LOGIN PAGE
  When I ENTER MY EMAIL AND PASSWORD
  | EMAIL              | PASSWORD |
  | automation@runn.er | auto-M8  |
  And I CLICK THE LOGIN BUTTON
  Then I SHOULD BE AUTHENTICATED TO MY ACCOUNT
