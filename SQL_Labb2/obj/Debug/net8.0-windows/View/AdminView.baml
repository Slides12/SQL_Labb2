   M S B A M L   `   `   `  ����D  @SQL_Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQL_Labb2.ViewSQL_Labb2.View  5      9!clr-namespace:SQL_Labb2.ViewmodelSQL_Labb2.Viewmodel  5          SQL_Labb2.View.AdminView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SQL_Labb2.View     5      0UI!clr-namespace:SQL_Labb2.Viewmodel     5      .��5      �   � ShowGridLines$  False��6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��55 �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�69   .+�5      �� $��40(�5      ��5      �� *)'StoreShowcaseViewModel.ActiveBook.Titel+5      �� 5      $��20(�5      $��Center=�5       $��15q�5!      $��Cambria)�5"      ��5      �� *#!StoreShowcaseViewModel.BookAuthor+5"      5#      �� 5%   
   $ 
Horizontal=�6   $��1��6.   $��1��6;   $��Center=�6K   $
��left=�6f   .+�5'   
   �� $
��Left=�6   .+�5(      �� $��Add Book��6   $	��100��5)      $��5q�5*      ��5+      �� *AdminViewModel.AddBookCommand+�� 5-      $��Remove Book��6   $	��100��5.      $��5q�5/      ��50      �� *" AdminViewModel.RemoveBookCommand+52      �� 53      $��50��6   �� 54      .+�56      �� $'��!Choose which store to add/remove.��6   $
��Bold"�6D   �� 58      $��30��6   $��Center=�59      $	��150��5:      $��Center=�5;      $��Center=�5<       �� SelectedIndex 5=      �� *AdminViewModel.SelectedIndex+ �� Mode$ TwoWay=�.@�5>      �� $��Adlibris��6   $��Center=�62   �� 5?      $��Amazon��6   $��Center=�60   �� 5@      $��Sci-fi Bookstore��6   $��Center=�6:   5A      5D      �� 5F      $��	80 0 0 0 q�6   $	��100��5G      $
��Bold"�5H      $��16(�5I      
����� ���5K      �� *'%AdminViewModel.AddCoverPictureCommand+.��5L      �� $��Add cover picture��6   $
��Wrap=�65   5M      5O      �� 5Q   
   $��2��6   $��1��5R      $
��Left=�5S      .+�5T   
   &   System.Windows.Controls.DataGrid     CanUserAddRows$ False��5V         AutoGenerateColumns$ False��5W      $��Center=�5X      ��5U      �� *AdminViewModel.StockBalance+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Store ID��6%   
   
IsReadOnly$

 True��6S      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	ButikId+6e     5[      $	 
Store Name��6%   $

 True��6^    69   �� *Butik.ButiksNamn+6^     5\      $	 Quantity��6%   $
 auto 6Q    67   �� *Antal+6Q   5^      5`      �� 5b   
   $��1��6   $��3��5c      $��2��5d      .+�5e      �� $\��VChange to desired quantity/Edit book information and press save below to save changes.��6   $��Center=�6u   �� 5f      $��Save changes��6   $	��100��5g      $��0q�5h      ��5i      �� *+)AdminViewModel.SaveBookInformationCommand+5m      �� 5p   
   $��1��6   $��2��6"   $��3��62   .+�5r      �� $ 
Horizontal=�6   $��Center=�62   .+�5s      �� $��Isbn:��6   $
��Bold"�6(   �� 5t      $��Center=�5u      $	��100��5v      $��Center=�5w       �� 
IsReadOnly$
 True��5x      ��5t      �� *AdminViewModel.Book.Isbn+5x      5z      �� 5|      $A��;Edit what you need below, press save to change all changes.��6   $
��Bold"�6Z   $��Center=�6l   �� 5}       �� TextWrapping$
 Wrap=�5~      $��2��5      $	��100��5�      $��0q�5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5}      �� *%#AdminViewModel.BookInfo.Beskrivning+5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $��Author��6   $
��Bold"�6)   �� 5�      $��Center=�6I   $��Center=�6m   ��6   �� * AdminViewModel.Author.Förnamn+6m   �� 5�      $��Center=�6K   $��Center=�6o   ��6   �� *!AdminViewModel.Author.Efternamn+6o   �� 5�      $��Genre��6   $
��Bold"�6(   �� 5�      $��Center=�6I   $��Center=�6m   ��6   �� *AdminViewModel.BookInfo.Genre+6m   �� 5�      $��Language��6   $
��Bold"�6+   $��	 10 0 0 0q�6=   �� 5�      $��Center=�6E   $��Center=�6i   ��6   �� *AdminViewModel.Book.Språk+6i   �� 5�      $��Price��6   $
��Bold"�6(   $��	 10 0 0 0q�6:   �� 5�      $��Center=�6D   $��Center=�6h   ��6   �� *AdminViewModel.Book.Pris+6h   5�      5�      5�      5�      