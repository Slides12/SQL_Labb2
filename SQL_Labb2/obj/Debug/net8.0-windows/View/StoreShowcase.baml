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
��auto �6    �� 5*      $��30 �6   �� 5+      $��* �6   .+�50   
   �� $��Center=�6    �� Orientation$ 
Horizontal=�51   
   $��1��52   
   .+�54      �� $��18��6   $��18��55      $��Right=�56      $��Center=�57      $��1��58      ��59        FontAwesome.Sharp.Icon  *plus+��5:      �� �� 5;      $�� Add A Book.��6   $��18(�6+   5=      � 5?   
    � ColumnDefinitions 5@      �� 5A      $��50 �6#   �� 5B      $	��140 �6#   �� 5C      $��* �6#   �� 5D      $	��100 �6#   .+�5G      �� $��30��6=   
���������6   �� *SetStoreViewCommand+.��5H      �� $��/Assets/LeftArrow.png��6   5I      �� 5K      $	��120��6=   $��Center=�6I   $��1��6f   $��10q�6v   ��6   �� *
StorePic+ �� Mode$ TwoWay=�6v   �� 5N      $��2��5O      $��5q�5P      $��1q�5Q      $��Disabled=�5R      $��Center=�5S      
�������$��Center=�5U      ��5N      �� *%#StoreShowcaseViewModel.GenreButtons+��5V      �� 5W      .R�5X      �� $��Century Gothic)�5Y      
�������
���   �$��0q�5\      $��10q�5]      $
��10,5q�5^      $	��100��5_      $��40��5`      #��[  5c      ��5X      �� *	Content+��5a      �� *	Command+��5b      �� *CommandParameter+  5d      ��%^   '��       �� 5e      " ��6$   .�5f   "   ��  �@��CornerRadius$ 7��6A   5g      5h      5i      5j      ��5m      �� 5n      .R�5o      �  � Orientation$ 
Horizontal=�6    5p      5r      5t      �� 5w   
   $��2��5x      $��15q�5y      $��1q�5z      $��9��5{      $
��auto��5|      $��Disabled=�5}      $��15q�5~      ��5w      �� *StoreShowcaseViewModel.Books+ �� SelectedItem 5      �� *#!StoreShowcaseViewModel.ActiveBook+��5�      �� 5�      .R�5�      �� $	��Top=�6   $	��140��5�      $	��200��5�       J� IsHitTestVisible$ False��5�      $|�False��5�      .��5�      �� $ Vertical=�6%   $��Center=�6<   .+�5�   "   �� $	��115��6B   $	��115��6O   $	��Top=�6[   ��6(   �� *Omslag+6[   �� 5�   "   $��Center=�5�       $��Center=�5�        �� Padding$ 5q�5�       $��Book Antiqua)�5�       $��15(�5�       $
��Wrap=�5�       ��5�   ,   �� *Titel+5�       �� 5�   "   $��Center=�6,   $��Center=�5�       $��Garamond)�5�       $��15(�5�       $
��Bold"�5�       �� 5�      �6   �� *Pris+ �� 5�      $	� Kr��6   5�   #   5�      5�      5�      ��5�      �� 5�      .R�5�      � $ 
Horizontal=�5�      5�      5�      5�      5�      