   M S B A M L   `   `   `  ����J  FBaza urządzeń, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:xdxd  5   	   b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5   	       xd.Dodawanie   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:xd     5   	   ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5   	   -   5          � Title$"  Dodawanie nowego urządzenia��5	   	   $	��570��6-   $	��793��6:    � 
ResizeMode$ NoResize=�6F    � WindowStyle$
 None=�6\   $��Center=�6�   $��Center=�6�    � ShowInTaskbar .   J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5   
   .��5      � ���	#FFC9C9C9.+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��570��6T   $	��Top=�6a   $	��793��6y   �� 5   
   -   5         ��Name$ 	btn_dodaj��5      $��Dodaj��6$   $
��Left=�64   $	��Top=�6O   $	��646��6g   $��
10,541,0,0q�6s   ���	#FF62AE5A
���   �
���   �6�   �� 5   
   -   5        $ 
btn_anuluj��5      $��Anuluj��6%   $
��Left=�66   $��661,541,0,0q�6Q   $	��Top=�6f   $	��123��6~   ���	#FFA85454
���   �
���   �6�   �� 5   
   -   5         ��Name$ 	tbx_nazwa��5      $
��Left=�6%   $��24��6@   $��
176,10,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��305��6�   
�������
���   �
���   � �� SelectionBrush �	#FF686868.��6�   5      �� 5   
   -   5        $ 	tbx_model��5      $
��Left=�6%   $��24��6@   $��
176,61,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��305��6�   
�������
���   �
���   � �	#FF686868.��6�   5      �� 5   
   -   5        $ tbx_cena��5      $
��Left=�6$   $��24��6?   $��176,113,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��110��6�   
�������
���   �
���   � �	#FF686868.��6�   5      �� 5   
   -   5        $ tbx_info��5      $
��Left=�6$   $	��128��6?   $��113,408,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��671��6�   	 �� TextAlignment$	 Justify=�6�   
�������
���   �
���   � �	#FF686868.��6  5      �� 5   
   -   5        $ tbx_data��5      $
��Left=�6$   $��24��6?   $��176,160,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��140��6�   
�������
���   �
���   � �	#FF686868.��6�   5      �� 5    
   -	   5        $ btn_wyposarzenie_dodaj��5       $��Dodaj��61   $
��Left=�6A   $��588,378,0,0q�6\   $	��Top=�6q   $	��117��6�   ���	#FF73B864
���   �
���   �6�   �� 5!   
   -
   5        
 ��Name$
 lbx_wyposarzenie��5!      $
��Left=�6,   $	��150��6G   $��588,195,0,0q�6T   $	��Top=�6i   $	��196��6�   
���   ����	#FF858585���	#FFE4E4E46�   �� 5"   
   -   5        $ btn_wyposarzenie_usun��5"      $��Usuń��60   $
��Left=�6?   $��710,378,0,0q�6Z   $	��Top=�6o   $��74��6�   ���	#FFAE5555
���   �
���   �6�   �� 5#   
   -   5        $ btn_usterka_dodaj��5#      $��Dodaj��6,   $
��Left=�6<   $��387,378,0,0q�6W   $	��Top=�6l   $	��117��6�   ���	#FF73B864
���   �
���   �6�   �� 5$   
   -   5        $
 lbx_usterka��5$      $
��Left=�6'   $	��150��6B   $��387,195,0,0q�6O   $	��Top=�6d   $	��196��6|   
���   ����	#FF858585���	#FFE4E4E46�   �� 5%   
   -   5        $ btn_usterka_usun��5%      $��Usuń��6+   $
��Left=�6:   $��509,378,0,0q�6U   $	��Top=�6j   $��74��6�   ���	#FFAE5555
���   �
���   �6�   	� 5&   
   -   5         	�Name$ rbtn_od_nowosci_tak��5&      $	��Tak��63   $
��Left=�6A   $��160,274,0,0q�6\   $	��Top=�6q   
���   ����	#FFAEAEAE d� 	IsChecked$
 TrueY�6�   	� 5'   
   -   5        $ rbtn_od_nowosci_nie��5'      $	��Nie��63   $
��Left=�6A   $��160,294,0,0q�6\   $	��Top=�6q   
���   ����	#FFAEAEAE6�   �� 5(   
   -   5        $ tbx_gdzie_nabyto��5(      $
��Left=�6,   $��62��6G   $��160,336,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��222��6�   
�������
���   �
���   � �	#FF686868.��6�   5*      �� 5+   
   $��Nazwa:��6   $
��Left=�6!   $��10,8,0,0q�6<   $	��Top=�6N   
���   �6f   �� 5,   
   $��Model:��6   $
��Left=�6!   $��	10,61,0,0q�6<   $	��Top=�6O   
���   �6g   �� 5-   
   $��Cena:��6   $
��Left=�6    $��
10,113,0,0q�6;   $	��Top=�6O   
���   �6g   �� 5.   
   $��Data zakupu(DD-MM-RRRR): ��6   $
��Left=�64   $��
10,160,0,0q�6O   $	��Top=�6c   
���   �6{   �� 5/   
   $��Czy od Nowości:��6   $
��Left=�6*   $��
10,271,0,0q�6E   $	��Top=�6Y   
���   �6q   �� 50   
   $��Gdzie nabyto:��6   $
��Left=�6(   $��
10,332,0,0q�6C   $	��Top=�6W   
���   �6o   �� 51   
   $��Informacje:��6   $
��Left=�6&   $��
10,404,0,0q�6A   $	��Top=�6U   
���   �6m   �� 52   
   $��Usterki:��6   $
��Left=�6#   $��387,164,0,0q�6>   $	��Top=�6S   
���   �6k   �� 53   
   $��Wyposażenie:��6   $
��Left=�6'   $��588,164,0,0q�6B   $	��Top=�6W   
���   �6o   �� 54   
   -   5        $ tbx_nazwa_usterki��54      $
��Left=�6-   $��23��6H   $��387,350,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��196��6�   
�������
���   �
���   � �	#FF686868.��6�   56      �� 57   
   -   5        $ tbx_nazwa_wyposarzenia��57      $
��Left=�62   $��23��6M   $��588,350,0,0q�6Y   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��196��6�   
�������
���   �
���   � �	#FF686868.��6  59      �� 5;   
   -   5         ��Name$ cbx_categories��5;      
���   �
���   �
�������$
��Left=�6f   $��
570,35,0,0q�6�   $	��Top=�6�   $	��195��6�   $��24��6�   5=      �� 5>   
   -   5        $ btn_czysc_kat��5>      $��X��6(   $
��Left=�64   $��
570,64,0,0q�6O   $	��Top=�6c   $	��196��6{   ���	#FFBDBDBD
���   ����	#FFFF0404 J� RenderTransformOrigin$ 0.5,0.5&�6�   $��21��6  5A      �� 5B   
   $��
Kategoria:��6   $
��Left=�6%   $��	567,8,0,0q�6@   $	��Top=�6S   
���   �6k   5G      5H      