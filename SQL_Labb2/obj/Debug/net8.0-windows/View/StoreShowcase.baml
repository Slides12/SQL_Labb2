   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  5      9!clr-namespace:SQL_Labb2.ViewmodelSQL_Labb2.Viewmodel  5      "    SQL_Labb2.View.StoreShowcase   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      (localclr-namespace:SQL_Labb2.View  5      *UI!clr-namespace:SQL_Labb2.Viewmodel  5        � 	Resources  5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5   !   $	 4,2q�5   !   
�������$ 5��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � ��
 �   �6T   5       5"      5$      5%      5&      .��5)      �  � RowDefinitions 5*      �� 5+      $
��auto �6   �� 5,      $
��auto �6   �� 5-      $��* �6   .+�53   
   �  � ColumnDefinitions 54      �� 55      $��50 �6#   �� 56      $	��140 �6#   �� 57      $��* �6#   �� 58      $	��100 �6#   .+�5;      �� $��30��6=   
���������6   �� *SetStoreViewCommand+.��5<      �� $��/Assets/LeftArrow.png��6   5=      �� 5?      $	��100��6=   $��Center=�6I   $��1��6f   $��0 10 0 0q�6v   ��6   �� *
StorePic+ �� Mode$ TwoWay=�6v   �� 5B      $��2��5C      $��5q�5D      $��1q�5E      $��Disabled=�5F      $��Center=�5G      
�������$��Center=�5I      ��5B      �� *%#StoreShowcaseViewModel.GenreButtons+��5J      �� 5K      .R�5L      �� $��Century Gothic)�5M      
�������
���   �$��0q�5P      $��10q�5Q      $
��10,5q�5R      $	��100��5S      $��40��5T      #��[  5W      ��5L      �� *	Content+��5U      �� *	Command+��5V      �� *CommandParameter+  5X      ��%^   '��       �� 5Y      " ��6$   .�5Z   "   ��  �@��CornerRadius$ 7��6A   5[      5\      5]      5^      ��5a      �� 5b      .R�5c      �  � Orientation$ 
Horizontal=�6    5d      5f      5h      �� 5k   
   $��2��5l      $��15q�5m      $��1q�5n      $��9��5o      $
��auto��5p      $��Disabled=�5q      $��15q�5r      ��5k      �� *StoreShowcaseViewModel.Books+ �� SelectedItem 5s      �� *#!StoreShowcaseViewModel.ActiveBook+��5u      �� 5v      .R�5y      �� $	��Top=�6   $	��140��5z      $	��200��5{       J� IsHitTestVisible$ False��5|      $|�False��5}      .��5~      ��  �� Orientation$ Vertical=�6%   $��Center=�6<   .+�5   "   �� $	��115��6B   $	��115��6O   $	��Top=�6[   ��6(   �� *Omslag+6[   �� 5�   "   $��Center=�5�       $��Center=�5�        �� Padding$ 5q�5�       $��Book Antiqua)�5�       $��15(�5�       $
��Wrap=�5�       ��5�   ,   �� *Titel+5�       �� 5�   "   $��Center=�6,   $��Center=�5�       $��Garamond)�5�       $��15(�5�       $
��Bold"�5�       �� 5�      �6   �� *Pris+ �� 5�      $	� Kr��6   5�   #   5�      5�      5�      ��5�      �� 5�      .R�5�      � $ 
Horizontal=�5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5�      �� $��Add a new book��6   $��30��5�      $	��200��5�      $��5q�5�      $
��Bold"�5�      $��15(�5�      $��Garamond)�5�      y�5�      �� *AddBookBTNVisibility+��5�      �� *AddBooksCommand+5�      �� 5�      $��Remove book from DB��6   $��30��5�      $	��200��5�      $��5q�5�      $
��Bold"�5�      $��15(�5�      $��Garamond)�5�      y�5�      �� *AddBookBTNVisibility+��5�      �� *RemoveBooksCommand+5�      �� 5�      $��Remove Authors��6   $��30��5�      $	��200��5�      $��5q�5�      $
��Bold"�5�      $��15(�5�      $��Garamond)�5�      y�5�      �� *AddBookBTNVisibility+��5�      �� *RemoveAuthorCommand+5�      5�      5�      5�      