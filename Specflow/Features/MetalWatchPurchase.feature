Feature: Watch Purchase on Magento Website

As a registered customer, I want to purchase a Metal Watch successfully.

@PositiveScenario
Scenario Outline: End-to-End purchase flow for a Metal Watch with Order Confirmation Validation
    Given I am on the Magento Home Page
    Then I should see the signin button on the home page
    When I click on the signin button on the home page
    Then I should be redirected to the login screen
    When I enter the email "<email>" and password "<password>"
    And I click on the signin button
    Then I should see the welcome text on the home page
    When I click on the "<menu>" item
    And I click on the submenu "<submenu>" item
    Then I should see available shopping options
    When I select the "<shopping>" category
    And I filter by "<subcategory>"
    Then I should see the product "<productName>" in the product list
    When I click on the product "<productName>"
    Then I should be directed to the product details page
    And I should see the product name "<productName>"
    And I should get the quantity and price for the product "<productName>"
    When I add the product to the cart
    Then A success message should confirm that the product "<productName>" is added to the cart
    When I navigate to the shopping cart page
    Then I should see the product "<productName>" in the shopping cart
    And I should validate the quantity of the product "<productName>" in the shopping cart
    And I should validate the product "<productName>" price in the shopping cart 
    And I should validate the product "<productName>" subtotal in the shopping cart 
    When I update the quantity of "<productName>" to "<updatedQuantity>"
    And I click on the updateshoppingcart button
    Then The new quantity in the cart should be "<updatedQuantity>" for the product "<productName>"
    And The subtotal price should reflect the updated quantity for the product "<productName>"
    And The order Total price should reflect the updated quantity for the product "<productName>"
    When I Click on proceed to checkout
    Then I should see the number of items in the cart in the order summary
    When I click on the number of items in the cart
    Then I should see the product "<productName>" in the order summary
    And I should validate the product "<productName>" price in the order summary
    When I choose the shipping method "Best Way - Table Rate"
    And I click on the next button
    Then I should validate order summary details in the Review Page
    When I click on place order
    Then I should be able to place the order successfully

Examples:
    | email                     | password  | menu | submenu | shopping | subcategory | productName      | updatedQuantity |
    | bhanu.dobbala93@gmail.com | Lassy@123 | Gear | Watches | Material | Metal       | Didi Sport Watch |        1        |

@NegativeScenarios
Scenario Outline: Login with invalid email and password
    Given I am on the Magento Home Page
    Then I should see the signin button on the home page
    When I click on the signin button on the home page
    Then I should be redirected to the login screen
    When I enter the email "<email>" and password "<password>"
    And I click on the signin button
    Then I should not see the welcome text on the home page

Examples:
    | email                     | password  | 
    | bhanu.dobbala@gmail.com   | Lassy@123 |

@NegativeScenarios
Scenario Outline: Filtering Watches with Plastic instead of Metal
    Given I am on the Magento Home Page
    Then I should see the signin button on the home page
    When I click on the signin button on the home page
    Then I should be redirected to the login screen
    When I enter the email "<email>" and password "<password>"
    And I click on the signin button
    Then I should see the welcome text on the home page
    When I click on the "<menu>" item
    And I click on the submenu "<submenu>" item
    Then I should see available shopping options
    When I select the "<shopping>" category
    And I filter by "<subcategory>"
    Then I should not see the product "<productName>" in the product list

Examples:
    | email                     | password  | menu | submenu | shopping | subcategory | productName      | 
    | bhanu.dobbala93@gmail.com | Lassy@123 | Gear | Watches | Material | Plastic     | Didi Sport Watch |
