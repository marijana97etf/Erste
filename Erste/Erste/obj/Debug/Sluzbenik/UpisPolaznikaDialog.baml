   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Erste.AdministratorErste.Administrator  5   	   )    #Erste.Sluzbenik.UpisPolaznikaDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Erste.Administrator     5   	     � Title$  NalogSluzbenikaDialog��5   	    � SizeToContent$ WidthAndHeight=�6'   $	��530��6F   $	��998��6S   $	��530��6_   $	��998��6o   $	��530��6~   $	��998��6�    � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � -   5         �Name$
 grid��5	       � RowDefinitions 5
   
   �� 5      $
��206* �6    � ColumnDefinitions 5   
   �� 5      $
��274* �6   .+�5   
   �� -   5        $��textBox_Ime��5      $	��Top=�6%   $��110,78,743,0q�6=   $��23��6S   �� 5   
   -   5        $��textBox_Prezime��5      $	��Top=�6)   $��109,112,742,0q�6A   $��23��6X   �� 5   
   -   5        $��textBox_Email��5      $	��Top=�6'   $��109,151,742,0q�6?   $��23��6V   �� 5   
   -   5        $��textBox_BrojTelefona��5      $	��Top=�6.   $��109,192,742,0q�6F   $��23��6]   � 5   
   $��0,0,10,0q�6    5      �� 5      $
��299* �6    �� 5      $
��202* �6     5      �� 5      $
��218* �6#   �� 5      $
��637* �6#   .+�5       �� -   5        $��	btn_Apply��5       $��Uredu��6&      buttonStyle#���   6O   $
��Auto��6u   $��1��6�   $��0,150,556,22q�6�   $��1��6�   $��Right=�6�   $	��112��6�   �� 5!      $	��Top=�6   $��26��6,   $
��Ime:��68   $��53,76,160,0q�6G   �� 5"      $	��Top=�6   $��26��6,   $��Prezime:��68   $��31,111,159,0q�6K    J� RenderTransformOrigin$ -7.757,0.786&�6a   �� 5#      $	��Top=�6   $��26��6,   $��Email:��68   $��45,152,161,0q�6I   �� 5$      $	��Top=�6   $��26��6,   $��Broj telefona:��68   $��	7,190,0,0q�6Q   $
��Left=�6d   $��84��6   �� 5%      $	��Top=�6   $��26��6,   $��Jezik:��69   $ 1.481,0.613&�6J   $��
48,226,0,0q�6n   $
��Left=�6�   $��39��6�   �� 5&      $	��Top=�6   $��26��6,   $��Nivo kursa:��68   $��
16,258,0,0q�6N   $
��Left=�6b   $��78��6}   �� 5'      -   5         ��Name$ btn_PrikaziGrupe��5'      $��Prikaži grupe��6/   #���   6g   $��28��6�   $	��Top=�6�   $��1��6�   $��
53,57,50,0q�6�   $ 0.347,0.891&�6�   �� 5(      -   5        $ Button2��5(      $��Otkaži��6&   #���   6N   $
��Auto��6t   $��1��6�   $��269,150,0,22q�6�   $��1��6�   $
��Left=�6�   $	��103��6�   �� 5)      -	   5        	 ��Name$	 label��5)      $ ��        Podaci o polazniku��6#   $��34��6H   $	��Top=�6T   $��19(�6l   $
��Bold"�6z   
���  ��$��6,9,0,0q�6�   � 5*      $
��Left=�6   $	��350��6.   $	��Top=�6;   $	��505��6S   $��	96,34,0,0q�6_   $��2��6r   $��1��6�    5+      �� 5,       5.      �� 5/      $��* �6'   �� 50      $��* �6'   �� 51      $��* �6'   .+�54      &   System.Windows.Controls.DataGrid  -
   5        $��GrupeDataGrid��54      $��3��60   
�������  DataGridErsteStyle
   ColumnHeaderStyle#
 [ 6W     DataGridCellErsteStyle   	CellStyle# [ 6�      VerticalGridLinesBrush �	#FFB2B2B2   HorizontalGridLinesBrush �	#FFB2B2B2$��-53,0,-92,0q�64     Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      Header$ Naziv grupe��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   ��  �� Path$ Grupa.Naziv�6t     57      $ * 6-   $ Jezik��67    6F   �� $ Jezik.Naziv�6m     58      $ * 6-   $ 
Nivo kursa��67    6K   �� $ 	Kurs.Nivo�6p     59      $ * 6-   $ Broj clanova��67    6M   �� $ Grupa.BrojClanova�6z     5:      $ * 6-   $ Datum pocetka kursa��67    6T   �� $ Kurs.DatumOd�6|     5;      $ * 6-   $ Datum završetka kursa��67    6V   �� $ Kurs.DatumDo�6~   5=      5>      �� 5?      -   5         ��Name$ NapomenaBox��5?   3   $
��Left=�6   $y�	Collapsed=�6H   $��	37,27,0,0q�6_   $��1��6r   $
��Wrap=�6   $��	TextBlock��6�   $	��Top=�6�   $��38��6�   $	��171��6�   �� 5@      -   5         ��Name$ 	chb_Jezik��5@      $��110,226,0,0q�6*   $	��Top=�6?   $��22��6X   6d   �� 5A      -   5        $ chb_Nivo��5A      $
��Left=�6)   $��110,262,0,0q�6D   $	��141��6Y   $��2��6e   $��20��6y   $	��Top=�6�   5B      5C      5D      