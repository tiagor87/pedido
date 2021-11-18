Feature: Searching

@BrowserRequired
Scenario: Search product
    Given I go to '<url>'
    When I search for the product '<productName>'
    Then I see the breadcrumb with text '<productName>'
    And I see the main with id 'listing'
    
    Examples:
    | url                  | productName |
    | https://kabum.com.br | RTX 3070    |
    | https://kabum.com.br | RTX 3080    |