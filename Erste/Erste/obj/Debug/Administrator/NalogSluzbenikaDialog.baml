   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Erste.AdministratorErste.Administrator  5   	   /    )Erste.Administrator.NalogSluzbenikaDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Erste.Administrator     5   	     � Title$  NalogSluzbenikaDialog��5   	    � SizeToContent$ WidthAndHeight=�6'   $	��450��6F   $��446.607��6S   $	��450��6c    � 
ResizeMode$ NoResize=�6s    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � -   5         �Name$
 grid��5	       � RowDefinitions 5
   
   �� 5      $
��206* �6    � ColumnDefinitions 5   
   �� 5      $
��274* �6   .+�5   
   �� -   5        $��textBox_Ime��5      $	��Top=�6%   $��	0,71,82,0q�6=   $��18��6P   $��Right=�6\   $	��159��6x   �� 5   
   -   5        $��textBox_Prezime��5      $	��Top=�6)   $��
0,111,82,0q�6A   $��18��6U   $��Right=�6a   $	��159��6}   �� 5   
   -   5        $��textBox_Email��5      $	��Top=�6'   $��
0,151,82,0q�6?   $��18��6S   $��Right=�6_   $	��159��6{   �� 5   
   -   5        $��textBox_BrojTelefona��5      $	��Top=�6.   $��
0,191,82,0q�6F   $��18��6Z   $��Right=�6f   $	��159��6�   �� 5   
   -   5        $��textBox_KorisnickoIme��5      $	��Top=�6/   $��
0,231,82,0q�6G   $��18��6[   $��Right=�6g   $	��161��6�   G� 5   
   -   5        $��textBox_Lozinka��5      $	��Top=�6-   $��
0,271,82,0q�6E   $��18��6Y   $��Right=�6e   $	��159��6�   G� 5   
   -   5        $��textBox_LozinkaProvjera��5      $	��Top=�65   $��
0,311,82,0q�6M   $��18��6a   $��Right=�6m   $	��159��6�   � 5   
   $��8��6    5      �� 5      $
��791* �6#   .+�5      �� -	   5        $��Button1��5      $��Uredu��6$   $��
96,372,0,0q�6J      buttonStyle#���   6^   $��28��6�   $	��Top=�6�   $
��Left=�6�   $	��101��6�   �� 5      $	��Top=�6   $��26��6,   $��
135,65,0,0q�68   $
��Ime:��6L   $
��Left=�6[   $��37��6v   �� 5       $	��Top=�6   $��26��6,   $��113,106,0,0q�68   $��Prezime:��6M   $
��Left=�6`   $��60��6{   �� 5!      $	��Top=�6   $��26��6,   $��126,147,0,0q�68   $��Email:��6M   $
��Left=�6^   $��49��6y   �� 5"      $	��Top=�6   $��26��6,   $��
88,185,0,0q�68   $��Broj telefona:��6L   $
��Left=�6e   $��84��6�   �� 5#      $	��Top=�6   $��26��6,   $��
78,227,0,0q�68   $��Korisničko ime:��6L   $
��Left=�6f   $��94��6�   �� 5$      $	��Top=�6   $��26��6,   $��115,266,0,0q�68   $��Lozinka:��6M   $
��Left=�6`   $��59��6{   �� 5%      $	��Top=�6   $��26��6,   $��
64,305,0,0q�68   $��Lozinka (ponovo):��6L   $
��Left=�6h   $	��109��6�   �� 5&      -
   5         ��Name$ Button2��5&      $��Otkaži��6&   $��0,372,112,0q�6M   #���   6b   $��28��6�   $	��Top=�6�   $��Right=�6�   $	��102��6�   �� 5'      -   5         ��Name$ label��5'      $��Podaci o službeniku��6#   $��34��6A   $��127,8,127,0q�6M   $	��Top=�6b   $��19(�6z   $
��Bold"�6�   
���  ��6�   5(      5)      5*      