   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SQL_Labb2	SQL_Labb2  5   	   /clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  6/       SQL_Labb2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SQL_Labb2     5   	   -viewclr-namespace:SQL_Labb2.View     6/     � Title$  DJ's Book Store��5   	   $	��700��6!   $
��1200��6.    � Icon$ /Assets/Book.ico��6;   
�������$	��700��6k   $
��1200��6{    J� InputBindings 5	      �� 5   
   
 �� Key$ F4��6    �� 	Modifiers$	 Altf�6    �� Command 6.   �� *ExitCommand+�� 5   
   $ Return��6   $	 Altf�6"    62   �� *FullscreenCommand+.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5       $	��300 �6   .+�5$   
      SQL_Labb2.View.MenuView     SQL_Labb2.View.StoreView  5&   
   $��1��6   $��2��6Q   y�6&   �� *StoreViewVisibility+6Q   "   SQL_Labb2.View.StoreShowcase  5'   
   $��1��6   y�6*   �� *StoreShowcaseVisibility+��6Y   �� *StoreShowcaseRowSpan+!   SQL_Labb2.View.BookInfoView  5(   
   $��2��6   y�6)   �� *BookInfoViewVisibility+   SQL_Labb2.View.AdminView  5)   
   $��2��6   y�6&   �� *AdminViewVisibility+51      52      