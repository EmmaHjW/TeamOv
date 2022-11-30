# NET-22 System developer Last project for the C\# OOP course Emma Hjalmarsson & Oskar Ullsten
UML in separate file.

The project was about creating an application after a backlog about a bank.  
This is our interpretation of what a banking application might look like.  
  
In program.cs there is no logic, only the start of TeamEmOS bank.  
  
This is how the program is divided:

-   **Bank class  
    **Predetermined bank accounts are created to the bank account list.  
    Predetermined admin and customers are created to user list.  
    Login screen is shown**  
    **
-   **User class  
    **Constructor that provides requirements for existing and new accounts.**  
    **Properties for admin and customers.  
    Maintain customer list.  
    Method to create and add customers to list.
-   **Bank account class  
    **Constructor that provides requirements for existing and new users.  
    Properties for accounts.  
    Maintain bank account list.  
    Method to create and add bank accounts to list.  
    Method to generate bank account number.
-   **Loan class  
    **Inherits from Bank account class.  
    Method for managing the loan application.  
    Methods for printing loans approved or not.
-   **Saving account class**  
    Inherits from Bank account class.  
    Method for calculate interest.
-   **Admin class  
    **Inherits from user class.**  
    **Manages admin list.
-   **Customer class  
    **Inherits from user class.
-   **Admin menu class  
    **Manages menu for admin.  
    Method to add new users to list.  
    Method that checks if a user exists before creating.  
    Method to printing all customers.  
    Method to delete customer.
-   **Customer menu class  
    **Manges customer menu.  
    Method to create salary account.  
    Method that’s add new bank account.  
    Method to printing account for logged in customer.
-   **Login service class  
    **Handles the login screen with validation if the user exists.  
    Set value to show logged in user.  
    Method to hide password when logging in.
-   **Transfer class  
    **Handles all transfers.  
    Method for Deposit.  
    Method for withdraw.  
    Method for third party transfers.
-   **Currency service  
    **Method to show exchange rates.
-   **Transaction service class  
    **Maintains transaction list and loan list.  
    Methods to printing lists

Bugs exist, but there was no time to fix them right now.
