   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Erste.AdministratorErste.Administrator  5          Erste.Sluzbenik.Kandidati   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Erste.Administrator     5      .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGrid��5      $��3��6#      DataGridErsteStyle   ColumnHeaderStyle# [  67      VerticalGridLinesBrush �	#FFB2B2B2   HorizontalGridLinesBrush �	#FFB2B2B2  DataGridCellErsteStyle   	CellStyle# [ 6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$	 Ime��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� 
 �� Path$
 	osoba.Ime�6a     5      $ * 6%   $ Prezime��6/   	 6@   �� $
 osoba.Prezime�6i     5      $ * 6%   $ Email��6/   	 6>   �� $
 osoba.Email�6e     5      $ * 6%   $ Broj telefona��6/   	 6F   �� $
 osoba.BrojTelefona�6t   5      � 5   
   $��0��6   $��3��6   $��1��63    5      �� 5      $��* �6#   �� 5       $��* �6#   5"      5#      5$      