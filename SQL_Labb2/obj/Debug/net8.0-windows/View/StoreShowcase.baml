   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  5      "    SQL_Labb2.View.StoreShowcase   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      (localclr-namespace:SQL_Labb2.View  5        � 	Resources  5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5   !   $	 4,2q�5   !   
�������$ 5��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � ��
 �   �6T   5      5       5"      5#      5$      .��5'      �  � RowDefinitions 5(      �� 5)      $
��auto �6    �� 5*      $��* �6   .+�50   
   �  � ColumnDefinitions 51      �� 52      $��50 �6#   �� 53      $	��140 �6#   �� 54      $��* �6#   �� 55      $	��100 �6#   .+�58      �� $��30��6=   
���������6   �� *SetStoreViewCommand+.��59      �� $��/Assets/LeftArrow.png��6   5:      �� 5<      $	��120��6=   $��Center=�6I   $��1��6f   $��10q�6v   ��6   �� *
StorePic+ �� Mode$ TwoWay=�6v   �� 5?      $��2��5@      $��5q�5A      $��1q�5B      $��Disabled=�5C      $��Center=�5D      
�������$��Center=�5F      ��5?      �� *%#StoreShowcaseViewModel.GenreButtons+��5G      �� 5H      .R�5I      �� $��Century Gothic)�5J      
�������
���   �$��0q�5M      $��10q�5N      $
��10,5q�5O      $	��100��5P      $��40��5Q      #��[  5T      ��5I      �� *	Content+��5R      �� *	Command+��5S      �� *CommandParameter+  5U      ��%^   '��       �� 5V      " ��6$   .�5W   "   ��  �@��CornerRadius$ 7��6A   5X      5Y      5Z      5[      ��5^      �� 5_      .R�5`      �  � Orientation$ 
Horizontal=�6    5a      5c      5e      �� 5h   
   $��2��5i      $��15q�5j      $��1q�5k      $��9��5l      $
��auto��5m      $��Disabled=�5n      $��15q�5o      ��5h      �� *StoreShowcaseViewModel.Books+ �� SelectedItem 5p      �� *#!StoreShowcaseViewModel.ActiveBook+��5r      �� 5s      .R�5v      �� $	��Top=�6   $	��140��5w      $	��200��5x       J� IsHitTestVisible$ False��5y      $|�False��5z      .��5{      ��  �� Orientation$ Vertical=�6%   $��Center=�6<   .+�5|   "   �� $	��115��6B   $	��115��6O   $	��Top=�6[   ��6(   �� *Omslag+6[   �� 5}   "   $��Center=�5~       $��Center=�5        �� Padding$ 5q�5�       $��Book Antiqua)�5�       $��15(�5�       $
��Wrap=�5�       ��5}   ,   �� *Titel+5�       �� 5�   "   $��Center=�6,   $��Center=�5�       $��Garamond)�5�       $��15(�5�       $
��Bold"�5�       �� 5�      �6   �� *Pris+ �� 5�      $	� Kr��6   5�   #   5�      5�      5�      ��5�      �� 5�      .R�5�      � $ 
Horizontal=�5�      5�      5�      5�      5�      