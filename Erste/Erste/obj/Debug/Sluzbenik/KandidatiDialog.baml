   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Erste.AdministratorErste.Administrator  5   	   %    Erste.Sluzbenik.KandidatiDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Erste.Administrator     5   	     � Title$  NalogSluzbenikaDialog��5   	   $	��346��6'   $	��448��64    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�6e   .��5	      � -   5         �Name$
 grid��5	       � RowDefinitions 5
   
   �� 5      $
��206* �6    � ColumnDefinitions 5   
   �� 5      $
��274* �6   .+�5   
   �� -   5        $��textBox_Ime��5      $	��Top=�6%   $��	0,71,82,0q�6=   $��18��6P   $��Right=�6\   $	��160��6x   �� 5   
   -   5        $��textBox_Prezime��5      $	��Top=�6)   $��
0,111,82,0q�6A   $��18��6U   $��Right=�6a   $	��160��6}   �� 5   
   -   5        $��textBox_Email��5      $	��Top=�6'   $��
0,151,82,0q�6?   $��18��6S   $��Right=�6_   $	��160��6{   �� 5   
   -   5        $��textBox_BrojTelefona��5      $	��Top=�6.   $��
0,191,82,0q�6F   $��18��6Z   $��Right=�6f   $	��160��6�   � 5   
   $��8��6    5      �� 5      $
��791* �6#   .+�5      �� -   5        $��Button_Uredu��5      $��Uredu��6)   $��103,243,0,0q�6T      buttonStyle#���   6i   $��28��6�   $	��Top=�6�   $
��Left=�6�   $	��102��6�   �� 5      $	��Top=�6   $��26��6,   $��
136,65,0,0q�68   $
��Ime:��6L   $
��Left=�6[   $��37��6v   �� 5      $	��Top=�6   $��26��6,   $��114,106,0,0q�68   $��Prezime:��6M   $
��Left=�6`   $��60��6{   �� 5      $	��Top=�6   $��26��6,   $��127,147,0,0q�68   $��Email:��6M   $
��Left=�6^   $��49��6y   �� 5      $
��Left=�6   $	��Top=�6/   $��26��6G   $��
89,185,0,0q�6S   $��84��6g   $��Broj telefona:��6r   �� 5       -   5         ��Name$ Button_Otkazi��5       $��Otkaži��6,   $��0,243,110,0q�6Y   #���   6n   $��28��6�   $	��Top=�6�   $��Right=�6�   $	��103��6�   �� 5!      -   5         ��Name$ label��5!      $��Podaci o kandidatu��6#   $��34��6@   $��	127,8,0,0q�6L   $	��Top=�6_   $��19(�6w   $
��Bold"�6�   
���  ��$
��Left=�6�   $	��188��6�   5"      5#      5$      