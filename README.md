# Vending-Machine
Vending Machine on C# WPF, MS SQL Server, EF

An application that simulates the operation of a vending machine provides the following general functionality:
- simulates the operation of a vending machine for drinks;
- accepts coins in denominations of 1, 2, 5, 10 rubles;
drinks are loaded into the vending machine, which can be purchased by depositing an amount equal to or exceeding their cost;
- all drinks by default 5 pieces;
- all coins are 27 pieces by default;
- availability of user and administrative interface;
- the user interface assumes the purchase of drinks – depositing the amount in coins, choosing a drink, receiving change;
- the administrative interface provides tools for managing the vending machine - replenishing the number of drinks, changing the assortment, blocking the acceptance of certain coins, blocking certain drinks.

The database was formed using the migration mechanism to the Microsoft SQL Server database management system.
The resulting database consists of four tables: three unrelated tables describing the subject area and tables of the history of migrations to the database.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/c0219f56-9b2e-45f1-8da7-f6efea6a920b)
