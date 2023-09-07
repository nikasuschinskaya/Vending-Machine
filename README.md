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

## Administrative and user interface

After launching the developed application, the MainWindow user interface window opens.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/c91abad2-5f66-4c4b-82ce-a960e661bd22)

To buy drinks, you need to deposit an amount exceeding or equal to the price of the drink. The amount is deposited by clicking on the buttons of the desired denomination. As soon as the deposited amount reaches the amount of the drink, it will be displayed on a black field where you can select a drink. A blocked or finished drink will not be displayed on the interface.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/afb68035-9268-4a74-a6ec-de9dad5db100)

The purchase of a drink is carried out by clicking on the picture of one of the drinks. You can also select several drinks and top up the amount to buy several drinks if the amount deposited is insufficient. To receive the change, you need to click on the "Done" button.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/c37b57ef-2ed9-4917-84a9-06e3695108ce)

The change is displayed in the form of issued denominations and their number. If the denominations are blocked or there are no coins of this denomination, then the machine gives out a smaller number of coins. If the change is not needed, the machine thanks the user for it.
The transition to the administrative interface is carried out using the "Login" button on the user interface. When you click on the "Login" button, the AutorizationWindow administrator authorization window opens.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/382cbace-ccb3-4525-96c4-5a7998088924)

When entering a non-existent username and password, the program notifies the user of his error. When entering the existing login and password, the transition to the administrative interface is carried out. The Admin Window consists of two tabs: coins and drinks.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/a9b2e397-44ae-4472-b1ec-7317a9c2af68)

On the "Coins" tab, the administrator can manage the coin table: update the number of coins, block or unlock denominations.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/d1ef822f-0395-4138-8393-525f514c4530)

On the Drinks tab, the administrator can manage the drinks table: add new drinks, update the quantity and price of drinks, delete drinks, block or unblock drinks.

## Testing
The Vending Machine Test s project for unit tests contains tests for important and complex functional classes. It allows you to check whether the developed classes and their methods work correctly.

![image](https://github.com/nikasuschinskaya/Vending-Machine/assets/92970744/9c7f1aaf-312b-4444-a9e3-9f2266d7863e)

The Vending Machine Test s project tests repositories that access the database and perform CRUD operations, and managers that contain the basic logic of interaction with data received from repositories.
