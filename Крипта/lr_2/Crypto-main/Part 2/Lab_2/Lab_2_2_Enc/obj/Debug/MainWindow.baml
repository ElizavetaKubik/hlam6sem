   M S B A M L   `   `   `  ����F  BLab_2_2_Enc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_2Lab_2  5   	       Lab_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_2     5   	     � Title$�  �Лабораторная №2 - криптографические шифры на основе подстановки (замены) символов��5   	   $	��450��6c   $	��800��6p   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   6*   �� 5      $	��18* �6   6+   �� 5      $��1* �6   6*   �� 5      $��2* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $	��10* �6   6-   �� 5      $	��10* �6   6-   �� 5      $��1* �6   6,   �� 5      $	��20* �6   6-   �� 5      $��1* �6   6,   .+�5   
   �� -   5        $��RichTextOrig��5      $��
5, 5, 5, 5q�6*   $��15(�6>   $��Showcard Gothic)�6L   $��1��6i   $��1��6v   $��2��6�   6�   �� 5   
   -   5        $��RichTextEnc��5      $��
5, 5, 5, 5q�6)   $��15(�6=   $��Showcard Gothic)�6K   $��1��6h   $��4��6u   $��1��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $��TextA��5      $��5, 5, 15, 5q�6   $��15(�64   $��Showcard Gothic)�6B   $��3��6_   $��1��6l    �� 	MaxLength$ 1��6�   6�   �� 5   
   -   5        $��Button��5      $��
5, 5, 5, 5q�6   $��15(�63   $��Showcard Gothic)�6A   $��3��6^   $��2��6k   $��3��6{   .��6�   	Encrypt6�   5      5       