   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  5          SQL_Labb2.View.StoreView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SQL_Labb2.View     5      
�������  � 	Resources  5
         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5      $	 4,2q�5      
�������$ 5��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � ��
 �   �6T   5      5      5       5!      5"      .��5%      �  � RowDefinitions 5&   
   �� 5'      $
��auto �6   �� 5(      $��* �6   �� 5)      $��* �6   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   .+�5/   
   �� $P��JWelcome, browse our selection of books and add what you deem is necessary.��6   $��1��50      $��30(�51      $��Bottom=�52      $��Center=�53      $
��Bold"�54      $��	Underline{�55      $��40q�56      �� 58   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $
��Left=�6;   .+�59      �� $	��200��6   �� 5;      -   5        $��B2��5;      $	��150��5<      $	��300��5=      
�������#��[  5?      ��5@      �� *SetStoreShowcaseCommand+��5A      ��  �� RelativeSource �� *Self+.��5B      �� $��/Assets/Amazon.jpeg��6   $��Center=�5C      5D      �� 5E      $����Free shipping on millions of items. Get the best of shopping and entertainment with Prime. Enjoy low prices and great deals on the largest selection of books.��6   $	��400��5F      $
��Wrap=�5G       �� Padding$ 5q�5H      $��18(�5I      $��Center=�5J      
���   �5K      5L      �� 5N   
   $ 
Horizontal=�6   $��3��6.   $
��left=�6;   .+�5O      �� $	��200��6   �� 5P      -   5        $��B1��5P      $	��150��5Q      $	��300��5R      
�������#��[  5T      ��5U      �� *SetStoreShowcaseCommand+��5V      ��  �� *Self+.��5W      �� $��/Assets/Adlibris.png��6   $��Center=�5X      5Y      �� 5Z      $����Adlibris is the Nordic region's largest bookstore and offers over 13 million book titles with the latest in games, crafts, yarn and everything that belongs to a modern bookstore.��6   $	��400��5[      $
��Wrap=�5\      $ 5q�5]      $��18(�5^      $��Center=�5_      
���   �5`      5a      �� 5c   
   $ 
Horizontal=�6   $��4��6.   $
��left=�6;   .+�5d      �� $	��200��6   �� 5e      -   5        $��B3��5e      $	��150��5f      $	��300��5g      ���#1a1b1c#��[  5i      ��5j      �� *SetStoreShowcaseCommand+��5k      ��  �� *Self+.��5l      �� $��/Assets/SciFi.png��6   $��Center=�5m      5n      �� 5o      $|��vThe Science Fiction bookstore sells books, cartoons, games and gadgets related to science fiction, fantasy and horror.��6   $	��400��5p      $
��Wrap=�5q      $ 5q�5r      $��18(�5s      $��Center=�5t      
���   �5u      5w      �� 5x   
   -   5        $��B4��5x      $��Admin��5y      $��5��5z      $��50��5{      $	��120��5|      $��30(�5}      
�������#��[  5      ��5�      �� *SetStoreShowcaseCommand+��5�      ��  �� *Self+5�      5�      