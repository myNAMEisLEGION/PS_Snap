Feature: Login
	

@possitive path
Scenario: LogIn to Application
	Given Application is opened 
	When I navigate to login page end enter UserName and Password
	| UserName           | Password |
	| izg28961@eveav.com | Cshark1  |

	Then I am successfully loged in

@possitive path
Scenario: LogIn to Client Lab
	Given Application is opened 
	When I navigate to login page end enter UserName and Password
	| UserName           | Password |
	| izg28961@eveav.com | Cshark1  |

	Then I am successfully loged in
	And Link to Client Lab is displayed
	When I navigate to Client Lab Page and enter UserName and Password
	| UserName           | Password |
	| gwt03992@bcaoo.com | Cshark1  |
	Then User is logged in to client lab welcome page is displayed

@negative path
Scenario: Login to application with incorrect credentials
	Given Application is opened 
	When I navigate to login page end enter incorrect UserName and Password
	| UserName           | Password |
	| izg28961@eveav.com | Cshark |
	Then I am not logged in and error message "Email i/lub hasło jest nieprawidłowe." is displayed

