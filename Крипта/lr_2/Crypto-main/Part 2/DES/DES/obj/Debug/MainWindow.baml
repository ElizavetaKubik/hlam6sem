   M S B A M L   `   `   `  ����>  :DES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DESDES  5   	       DES.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:DES     5   	     � Title$?  9Лабораторная №5 - блочные шифры��5   	   $��439.2��61   $	��800��6@   .��5	      � .+�5
   
   �� $	��DES��6   $
��Bold"�6    $
��Left=�62   $	��297��6M   $��	24,85,0,0q�6Z   $	��Top=�6m   $	��360��6�   $��Showcard Gothic)�6�   $��15(�6�   .��5      �� .+�5      �� $��Normal"�6   $��Encrypt text:��6,   $��	10,10,0,0q�6D   �� 5      -   5        $��	DESCypher��5   .   $��Normal"�6   $
��Left=�6?   ��. $��84��6   $��10,5,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��326��6�    �� 
IsReadOnly . 6�   �� 5      $��Normal"�6   $��Decrypt text:��6,   $��	10,15,0,0q�6D   �� 5      -   5        $��DESDecypher��5   .   $��Normal"�6   $
��Left=�6A   ��. $��85��6�   $��10,5,0,0q�6�   $
 Wrap=�6�   $��Center=�6�   $	��326��6�    . 6�   5      5      �� 5   
   $
��DES3��6   $
��Bold"�6!   $
��Left=�63   $	��297��6N   $��
401,85,0,0q�6[   $	��Top=�6o   $	��367��6�   $��Showcard Gothic)�6�   $��15(�6�   .��5      �� .+�5      �� $��Encrypt text:��6   $��	10,10,0,0q�60   $��Normal"�6C   �� 5      -   5        $��
DES3Cypher��5      $��Normal"�6,   $
��Left=�6@   ��. $��84��6�   $��10,5,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��326��6�    . 6�   �� 5      $��Decrypt text:��6   $��	10,15,0,0q�60   $��Normal"�6C   �� 5      -   5        $��DES3Decypher��5      $��Normal"�6.   $
��Left=�6B   ��. $��85��6�   $��10,5,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��326��6�    . 6�   5      5      �� 5   
   -   5        $��	InputText��5      $
��Left=�6#   $��41��6>   $��
135,27,0,0q�6J   $
 Wrap=�6^   $	��Top=�6s   $	��518��6�   $��Showcard Gothic)�6�   $��15(�6�   $��Center=�6�   �� 5   
   $��Input text:��6   $
��Bold"�6&   $
��Left=�68   $��	24,27,0,0q�6S   $	��Top=�6f   $��41��6~   $	��106��6�   $��Showcard Gothic)�6�   $��15(�6�   $��Center=�6�   �� 5   
   -   5        $��Start��5      $
��Left=�6!   $
��Bold"�6<   $��
670,27,0,0q�6N   $	��Top=�6b   $��98��6z   $��41��6�   $��Showcard Gothic)�6�   $��15(�6�   6�   5      5      