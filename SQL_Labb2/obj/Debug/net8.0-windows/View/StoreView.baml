   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  5      9!clr-namespace:SQL_Labb2.ViewmodelSQL_Labb2.Viewmodel  5          SQL_Labb2.View.StoreView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SQL_Labb2.View     5      0UI!clr-namespace:SQL_Labb2.Viewmodel     5      
�������  � 	Resources  5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5      $	 4,2q�5      
�������$ 5��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � ��
 �   �6T   5      5       5"      5#      5$      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��auto �6   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6   .+�51   
   �� $P��JWelcome, browse our selection of books and add what you deem is necessary.��6   $��1��52      $��30(�53      $��Bottom=�54      $��Center=�55      $
��Bold"�56      $��	Underline{�57      $��40q�58      �� 5:   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $
��Left=�6;   .+�5;      �� $	��200��6   �� 5=      -   5        $��B2��5=      $	��150��5>      $	��300��5?      
�������#��[  5A      ��5B      �� *SetStoreShowcaseCommand+��5C      ��  �� RelativeSource �� *Self+.��5D      �� $��/Assets/Amazon.jpeg��6   $��Center=�5E      5F      �� 5G      $����Free shipping on millions of items. Get the best of shopping and entertainment with Prime. Enjoy low prices and great deals on the largest selection of books.��6   $	��400��5H      $
��Wrap=�5I       �� Padding$ 5q�5J      $��18(�5K      $��Center=�5L      
���   �5M      5N      �� 5P   
   $ 
Horizontal=�6   $��2��6.   $
��left=�6;   .+�5Q      �� $	��200��6   �� 5R      -   5        $��B1��5R      $	��150��5S      $	��300��5T      
�������#��[  5V      ��5W      �� *SetStoreShowcaseCommand+��5X      ��  �� *Self+.��5Y      �� $��/Assets/Adlibris.png��6   $��Center=�5Z      5[      �� 5\      $����Adlibris is the Nordic region's largest bookstore and offers over 13 million book titles with the latest in games, crafts, yarn and everything that belongs to a modern bookstore.��6   $	��400��5]      $
��Wrap=�5^      $ 5q�5_      $��18(�5`      $��Center=�5a      
���   �5b      5c      �� 5e   
   $ 
Horizontal=�6   $��4��6.   $
��left=�6;   .+�5f      �� $	��200��6   �� 5g      -   5        $��B3��5g      $	��150��5h      $	��300��5i      ���#1a1b1c#��[  5k      ��5l      �� *SetStoreShowcaseCommand+��5m      ��  �� *Self+.��5n      �� $��/Assets/SciFi.png��6   $��Center=�5o      5p      �� 5q      $|��vThe Science Fiction bookstore sells books, cartoons, games and gadgets related to science fiction, fantasy and horror.��6   $	��400��5r      $
��Wrap=�5s      $ 5q�5t      $��18(�5u      $��Center=�5v      
���   �5w      5y      �� 5z   
   -   5        $��B4��5z      $��Admin��5{      $��5��5|      $��50��5}      $	��120��5~      $��30(�5      
�������#��[  5�      ��5�      �� *SetStoreShowcaseCommand+��5�      ��  �� *Self+5�      5�      