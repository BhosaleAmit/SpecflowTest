Feature: ShoppingCart
	Shopping cart and wishlist functionality

@mytag
Scenario: Verify wishlist item with minimum price is added to shopping cart
	Given I add four different products to my wishlist
	When I view wishlist table
	Then I find total four selected items in Wishlist
	When I search for lowest price product
	And I am able to add the lowest price item to my cart
	Then I am able to verify the item in my cart