   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SQL_Labb2.ViewmodelSQL_Labb2.Viewmodel  5   	   9!clr-namespace:SQL_Labb2.ConverterSQL_Labb2.Converter  5   	   %    SQL_Labb2.Windows.AddBookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   3local!clr-namespace:SQL_Labb2.Viewmodel     5   	   /c!clr-namespace:SQL_Labb2.Converter     5   	     � Title$  Add Book��5   	   $	��700��6   $	��400��6'    � 
ResizeMode$ NoResize=�63   
������� � Icon$ /Assets/Book.ico��6`    � WindowStartupLocation$ CenterOwner=�6x    � 	Resources 5	      5   /SQL_Labb2.Converter.DateOnlyToDateTimeConverter   DateOnlyToDateTimeConverter��%   &	          5
   
   6(   5      .��5      � .+�5   
   �� $	��Top=�6   $��Center=�6-   .+�5      �� $4��.ISBN (Starts with a 9 and is 13 numbers long.)��6   $��Center=�6M   $
��Bold"�6j   �� 5      -   5        $	��200��5      $��5q�6"   ��6-   �� *Isbn+6C   �� 5      $��Title��6   $��Center=�6$   $
��Bold"�6A   �� 5      $	��200��6   $��5q�6"   ��6-   �� *Title+�� 5      $��Price��6   $��Center=�6$   $
��Bold"�6A   �� 5      $	��200��6   $��5q�6"   ��6-   �� *Price+�� 5      $��Select/New Author��6   $��Center=�60   $
��Bold"�6M   �� 5      $	��200��6   $��5q�6#    �� SelectedItem 6.   �� *SelectedAuthor+��6V   �� *	Authors+�� 5      $	��200��6   $��5q�6"   ��6-   �� *	NewAuthor+�� 5      $��Select/New Genre��6   $��Center=�6/   $
��Bold"�6L   �� 5      $	��200��6   $��5q�6#    6.   �� *SelectedGenre+��6U   �� *Genres+�� 5       $	��200��6   $��5q�6"   ��6-   �� *
NewGenre+�� 5"      $��Select/New Language��6   $��Center=�62   $
��Bold"�6O   �� 5#      $	��200��6   $��5q�6#    6.   �� *SelectedLanguage+��6X   �� *	Languages+�� 5$      $	��200��6   $��5q�6"   ��6-   �� *NewLanguage+�� 5&      $��Description��6   $��Center=�6*   $
��Bold"�6G   �� 5'      $	��200��6   $	��100��6"   $��5q�6/   ��6:   �� *Description+�� 5)      $��Publishing year��6   $��Center=�6.   $
��Bold"�6K   (  "System.Windows.Controls.DatePicker  5*      $	��200��6   $��5q�6%      SelectedDate 60   �� *Pyear+ �� Mode$ TwoWay=� �� 	Converter# [  �� 5,      $��Add Book��6   $	��200��6(   $��5q�64   ��6?   �� *AddBookCommand+��6b   �� 	 �� RelativeSource	 �� 
 �� AncestorType

 Window5-      5.      5/      