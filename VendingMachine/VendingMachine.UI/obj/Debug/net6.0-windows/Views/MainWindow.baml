   M S B A M L   `   `   `  ����L  HVendingMachine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:VendingMachine.UI.ViewModelsVendingMachine.UI.ViewModels  5   	   A%clr-namespace:VendingMachine.UI.ViewsVendingMachine.UI.Views  5   	   (    "VendingMachine.UI.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9vm*clr-namespace:VendingMachine.UI.ViewModels     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:VendingMachine.UI.Views     5   	     � Title$  
MainWindow��5	   	   $	��700��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ CanMinimize=�6.    � DataContext 5      0   *VendingMachine.UI.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$ PaymentLabel��5      $��Внесено:��6&   $��24(�69   $��Rubik)�6G   $	��300��6Z   $��50��6i   $	��Top=�6u   $
��Left=�6�   $��
54,124,0,0q�6�   6�   �� 5   
   -   5        $ PaymentSumLabel��5      $��24(�6M   $��Rubik)�6[   $	��300��6n   $��50��6}   $	��Top=�6�   $
��Left=�6�   $��174,124,0,0q�6�   ��6)   �� *DepositedAmount+6�   �� 5   
   -   5        $ Label��5      $��руб.��6   $��24(�6.   $��Rubik)�6<   $	��300��6O   $��50��6^   $	��Top=�6j   $
��Left=�6�   $��224,124,0,0q�6�    J� RenderTransformOrigin$ 
2.89,0.387&�6�   6�   �� 5   
   -   5         ��Name$ OneCoinButton��5      $	��210��6�   $��70��6�   $
��Left=�6�   $��
60,204,0,0q�6�   $	��Top=�6�   
���   �$��	1 руб.��6�   $��20(�6  $��Rubik)�6  
������� � Cursor$
 Hand��67  ��6(   �� *OnClickOneCoinButton+y�6Q   �� *OneCoinButtonVisibible+67  �� 5   
   -   5        $ TwoCoinButton��5      $	��210��6   $��70��6�   $
��Left=�6�   $��
60,294,0,0q�6�   $	��Top=�6�   
���   �$��	2 руб.��6�   $��20(�6  $��Rubik)�6  
�������$
 Hand��66  ��6(   �� *OnClickTwoCoinButton+y�6Q   �� *TwoCoinButtonVisibible+66  �� 5   
   -   5        $ FiveCoinButton��5      $	��210��6�   $��70��6�   $
��Left=�6�   $��
60,384,0,0q�6�   $	��Top=�6�   
���   �$��	5 руб.��6�   $��20(�6  $��Rubik)�6  
�������$
 Hand��69  ��6)   �� *OnClickFiveCoinButton+y�6S   �� *FiveCoinButtonVisibible+69  �� 5   
   -   5        $ TenCoinButton��5      $	��210��6   $��70��6�   $
��Left=�6�   $��
60,474,0,0q�6�   $	��Top=�6�   
���   �$��
10 руб.��6�   $��20(�6  $��Rubik)�6  
�������$
 Hand��67  ��6(   �� *OnClickTenCoinButton+y�6Q   �� *TenCoinButtonVisibible+67  �� 5   
   -   5         ��Name$ BlackRectangle��5      $��70��6,   $	��Top=�68   
���   �6P   �� 5   
   $%��Автомат напитков��6   $��20(�6+   $��Rubik)�69   $	��200��6L   $��50��6X   $	��Top=�6d   $
��Left=�6|   $��400, 15q�6�   
�������6�   �� 5   
   -	   5        $ AutorizationButton��5      $	��210��6[   $��70��6g   $��Right=�6s   $	��Top=�6�   
���   �$��Вход��6�   $��20(�6�   $��Rubik)�6�   
�������$
 Hand��6�   ��6-   �� *OnClickAutorizationButton+6�   �� 5   
   -
   5        $ DrinkRectangle��5      $	��800��6,   
���   �$��338,100,62,27q�6E   �� 5   
   $%��Выберите напиток��6   $��24(�6+   $��Rubik)�69   $	��250��6L   $��50��6[   $	��Top=�6j   $
��Left=�6�   $��620,112,0,0q�6�   
�������6�   �� 5   
   -   5        	 ��Name$	 
FantaImage��5      $��422,178,630,361q�6$   $
��Fill=�6]   $
 Hand��6l   ��6=   �� *FantaImgPath+y�6z   �� *FantaVisibible+
 J� InputBindings
 5       d� 5!       d� MouseAction$ 	LeftClicke�6    �� Command 67   �� *OnClickFanta+5#      �� 5$   
   -   5        $	 SpriteImage��5$      $��659,175,387,361q�6F   $
 Hand��6_   ��6%   �� *SpriteImgPath+y�6m   �� *SpriteVisibible+
 5%      d� 5&      $ 	LeftClicke�6    67   �� *OnClickSprite+5(      �� 5)   
   -   5        $	 SevenUpImage��5)      $��922,178,144,361q�6&   $
��Fill=�6a   $
 Hand��6p   ��6?   �� *SevenUpImgPath+y�6~   �� *SevenUpVisibible+
 5*      d� 5+      $ 	LeftClicke�6    67   �� *OnClickSevenUp+5-      �� 5.   
   -   5        $	 	ColaImage��5.      $��522,370,530,165q�6#   $
��Fill=�6[   $
 Hand��6j   ��6<   �� *ColaImgPath+y�6x   �� *ColaVisibible+
 5/      d� 50      $ 	LeftClicke�6    67   �� *OnClickCola+52      �� 53   
   -   5        $	 
PepsiImage��53      $��792,370,258,165q�6$   $
��Fill=�6]   $
 Hand��6l   ��6=   �� *PepsiImgPath+y�6z   �� *PepsiVisibible+
 54      d� 55      $ 	LeftClicke�6    67   �� *OnClickPepsi+57      �� 59   
   -   5        $ FantaCostLabel��59      $��24(�6q   $��Rubik)�6   $	��250��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   $��456,316,0,0q�6�   
���������6(   �� *OutputFantaCost+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5:   
   -   5        $ SpriteCostLabel��5:      $��24(�6s   $��Rubik)�6�   $	��250��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   $��696,320,0,0q�6�   
���������6)   �� *OutputSpriteCost+$ PropertyChanged=�6�   �� 5;   
   -   5        $ SevenUpCostLabel��5;      $��24(�6u   $��Rubik)�6�   $	��250��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   $��949,320,0,0q�6�   
�������$ 0.468,0.107&�6  ��6*   �� *OutputSevenUpCost+$ PropertyChanged=�6  �� 5<   
   -   5        $ ColaCostLabel��5<      $��24(�6o   $��Rubik)�6}   $	��250��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   $��556,511,0,0q�6�   
�������$ 0.506,-0.155&�6	  ��6'   �� *OutputColaCost+$ PropertyChanged=�6	  �� 5=   
   -   5        $ PepsiCostLabel��5=      $��24(�6q   $��Rubik)�6   $	��250��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   $��827,511,0,0q�6�   
���������6(   �� *OutputPepsiCost+$ PropertyChanged=�6�   �� 5?   
   -   5        $ ReadyButton��5?      $	��217��6M   $��50��6Y   $
��Left=�6e   $��627,574,0,0q�6�   $	��Top=�6�   
��� ���$��Готово��6�   $��20(�6�   $��Rubik)�6�   $
 Hand��6�   ��6&   �� *OnClickReadyButton+6�   5B      5C      