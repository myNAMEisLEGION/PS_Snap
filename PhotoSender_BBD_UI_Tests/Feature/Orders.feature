Feature: Orders
	Creating Orders
	Verification orders
	Orders Data

@End to End test
Scenario: Create new Order
	Given I am logged in to application with credentials UserName and Password
	| UserName           | Password |
	| gwt03992@bcaoo.com | Cshark1  |
	When I am creating new order
	And Completing all stages
	Then Order is displayed in order list


@End to End test
Scenario: Create new order payment method PayU
	Given I am logged in to application with credentials UserName and Password
	| UserName           | Password |
	| gwt03992@bcaoo.com | Cshark1  |
	When Completing stages
	And Completing PayU payment
	Then Order is displayed in order list

@End to End test
	Scenario: Create new order with discount
	Given I am logged in to application with credentials UserName and Password
	| UserName           | Password |
	| gwt03992@bcaoo.com | Cshark1  |
	When User reach summary stage add discount
	And verify if price is correctly calculated
	Then Order is displayed in order list with discounted price

@End to End test
	Scenario: Create new order with pickup point as a delivery  method
	Given I am logged in to application with credentials UserName and Password
	| UserName           | Password |
	| gwt03992@bcaoo.com | Cshark1  |
	When User reach delivery stage delivery method: Collection in Person and Pickup Point is chosen 
	Then Order is displayed in order list with correct deivery method and pickup point address