   M S B A M L   `   `   `  ����L  HVendingMachine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:VendingMachine.UI.ViewModelsVendingMachine.UI.ViewModels  5   	   A%clr-namespace:VendingMachine.UI.ViewsVendingMachine.UI.Views  5   	   0    *VendingMachine.UI.Views.AutorizationWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9vm*clr-namespace:VendingMachine.UI.ViewModels     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:VendingMachine.UI.Views     5   	     � Title$  AutorizationWindow��5	   	   $	��400��6$   $	��500��61    � WindowStartupLocation$ CenterScreen=�5
   	    � DataContext 5      8   2VendingMachine.UI.ViewModels.AutorizationViewModel  5   
   .��5      � .+�5   
   �� $��Авторизация��6   $��40��6&   $	��200��65   $��Center=�6D   $	��Top=�6a   $��Rubik)�6y   $��18(�6�   $��0,30,0,0q�6�   �� 5   
   $��Логин:��6   $��40��6!   $	��200��60   $
��Left=�6?   $	��Top=�6Z   $��Rubik)�6r   $��14(�6�   $��	78,84,0,0q�6�   �� 5   
   -   5         ��Name$ LoginTextBox��5      $��13(�6L   $��78,116,80,216q�6Z   ��6(   �� *Login+ �� Mode$ TwoWay=�6Z   �� 5   
   $��Пароль:��6   $��40��6"   $	��200��61   $
��Left=�6@   $	��Top=�6[   $��Rubik)�6t   $��14(�6�   $��
78,169,0,0q�6�   G� 5   
   -   5         G�Name$ PassTextBox��5      $��13(�6+   $��80,202,80,131q�69   �� 5   
   -   5         ��Name$ Autorization��5      $��
Войти��6�   
�������
���   �$��Rubik)�6�   $��14(�6�   $��152,280,152,36q�6�    � Cursor$
 Hand��6�   ��6'   �� *OnclickAutorization+��6O   ��  �� ElementName$ PassTextBox��6�   5      5      