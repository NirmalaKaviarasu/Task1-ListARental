Feature: List A Rental
	     In order to List a Rental
	     As a Property Owner
	     I want to have Property which is already displyed under Myproperty 

@ListARental
Scenario: List A Rental
    Given Login as Property Owner 
	And Navigate to OwnersPage and Select MyPropertyPage
	When I Select List a Rental option 
    And Enter Details in List Rental Property Page by selecting Property to Rent and Save
	Then Property should dispalyed on PropertiesForRent Page
