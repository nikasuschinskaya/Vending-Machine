   M S B A M L   `   `   `  ����L  HVendingMachine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:VendingMachine.UI.ViewModelsVendingMachine.UI.ViewModels  5   	   A%clr-namespace:VendingMachine.UI.ViewsVendingMachine.UI.Views  5   	   )    #VendingMachine.UI.Views.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9vm*clr-namespace:VendingMachine.UI.ViewModels     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:VendingMachine.UI.Views     5   	     � Title$  AdminWindow��5	   	   $	��680��6   $
��1000��6*    � WindowStartupLocation$ CenterScreen=�5
   	    � DataContext 5      1   +VendingMachine.UI.ViewModels.AdminViewModel  5   
   .��5      � .+�5   
   �� $��0,0,10,0q�6   .@�5      �� $��Напитки��6   $��14(�6'   .��5      �� $	��900��6    �� Orientation$ 
Horizontal=�6)   .+�5      �� $	��300��6!   .+�5      �� $��Id��6    $��16(�6-   $��Rubik)�6;   $
��Left=�6N   $��10q�6i    J� RenderTransformOrigin$ 0.472,0.017&�6u   $��54��6�   �� 5      -   5         ��Name$ drinkIdTextBox��5   "   $��14(�6a   $
��Left=�6o   $��10q�6�    �� TextWrapping$
 Wrap=�6�   $	��200��6�   ��6:   �� *SelectedDrink.DrinkId+6�   �� 5      $��Название��6    $
��Left=�63   $��16(�6N   $��Rubik)�6\   $��92��6o   �� 5      -   5        $ drinkNameTextBox��5   "   $��14(�6`   $
��Left=�6n   $��10q�6�   $
 Wrap=�6�   $	��200��6�   ��6<   �� *SelectedDrink.Name+6�   �� 5      $��Количество��6    $��16(�65   $
��Left=�6C   $��Rubik)�6^   $ 0.472,0.017&�6q   $	��108��6�   �� 5      -   5        $ drinkCountTextBox��5   "   $��14(�6b   $
��Left=�6p   $��10q�6�   $
 Wrap=�6�   $	��200��6�   ��6=   �� *SelectedDrink.Count+6�   �� 5      $��Цена��6    $��16(�6/   $
��Left=�6=   $��Rubik)�6X   $ 0.472,0.017&�6k   $��54��6�   �� 5      -   5        $ drinkCostTextBox��5   "   $��14(�6`   $
��Left=�6n   $��10q�6�   $
 Wrap=�6�   $	��200��6�   ��6<   �� *SelectedDrink.Cost+6�   A� 5       A� Rows$ 5��6&   $��10q�6/   .+�5      �� -   5         ��Name$ AddDrinkButton��5   %   $��Добавить��6b   $
��Left=�6u   $��10q�6�   $��16(�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��120��6�   	 � Cursor$
	 Hand��6�   ��6=   �� *OnClickAddButton+6�   �� 5      -   5        $ UpdateDrinkButton��5   %   $��Обновить��6h   $��16(�6{   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��120��6�   $
	 Hand��6  ��6@   �� *OnClickUpdateButton+6  �� 5      -   5        $ DeleteDrinkButton��5   %   $��Удалить��6h   $��16(�6z   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��120��6�   $
	 Hand��6   ��6@   �� *OnClickDeleteButton+6   �� 5      -   5        $ BlockDrinkButton��5   %   $ ��Заблокировать��6f   $��16(�6~   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��153��6�   $
	 Hand��6  ��6?   �� *OnClickBlockButton+6  �� 5       -	   5        $ UnlockDrinkButton��5    %   $"��Разблокировать��6h   $��16(�6�   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��153��6�   $
	 Hand��6  ��6@   �� *OnClickUnlockButton+6  5!      5"      �� 5#      .+�5$      �� $��Напиток��6    $��20(�62   $��Rubik)�6@   $	��104��6S   &   System.Windows.Controls.DataGrid  5%      -
   5        $��DrinksDataGrid��5%   #   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 69      AutoGenerateColumns$ False��6�   $	��301��6�   $	��600��6�   ��6I   �� *Drinks+ �� SelectedItem 6h   �� *SelectedDrink+   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Id��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	DrinkId+  5(   "   $
 Name��65    6C   �� *Name+  5)   "   $ Count��65    6D   �� *Count+  5*   "   $
 Cost��65    6C   �� *Cost+  5+   "   $ State��65    6D   �� *
DrinkState+5-      5.      5/      50      �� 51      $��Монеты��6   $��14(�6&   .��52      �� $	��900��6   $ 
Horizontal=�6)   .+�53      �� $	��300��6!   .+�54      �� $��Id��6    $��16(�6-   $
��Left=�6;   $��5q�6V   $��Rubik)�6a   $ 0.472,0.017&�6t   $��54��6�   �� 55      -   5        $ coinIdTextBox��55   "   $��14(�6^   $
��Left=�6l   $��10q�6�   $
 Wrap=�6�   $	��200��6�   ��69   �� *SelectedCoin.CoinId+6�   �� 56      $��Количество��6    $��16(�65   $
��Left=�6C   $��5q�6^   $��Rubik)�6i   $ 0.472,0.017&�6|   $	��114��6�   �� 57      -   5        $ coinCountTextBox��57   "   $��14(�6`   $
��Left=�6n   $��10q�6�   $
 Wrap=�6�   $	��200��6�   ��6<   �� *SelectedCoin.Count+6�   A� 58      $ 3��6&   $��35q�6/   .+�59      �� -   5        $ UpdateCoinButton��59   %   $��Обновить��6k   $��16(�6~   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��120��6�   $
	 Hand��6  ��6?   �� *OnClickCoinUpdateButton+6  �� 5:      -   5        $ BlockCoinButton��5:   %   $ ��Заблокировать��6i   $��16(�6�   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��153��6�   $
	 Hand��6  ��6>   �� *OnClickBlockCoinButton+6  �� 5;      -   5        $ UnlockCoinButton��5;   %   $"��Разблокировать��6k   $��16(�6�   $
��Left=�6�   $��10q�6�   $��Rubik)�6�   
���   �
�������$��39��6�   $	��153��6�   $
	 Hand��6
  ��6?   �� *OnClickUnlockCoinButton+6
  5<      5=      �� 5>      .+�5?      �� $��Монета��6    $��20(�61   $��Rubik)�6?   $	��104��6R     5@      -   5        $��CoinsDataGrid��5@   #   $
 * 68   $ False��6�   $	��301��6�   $	��600��6�   ��6H   �� *Coins+ 6f   �� *SelectedCoin+ 5A        5B   "   $ Id��65    6A   �� *CoinId+  5C   "   $ Denomination��65    6K   �� *Denomination+  5D   "   $ Count��65    6D   �� *Count+  5E   "   $ State��65    6D   �� *	CoinState+5G      5H      5I      5J      5K      5L      5M      