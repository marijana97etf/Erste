   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ErsteErste  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Erste.SluzbenikMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Erste     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          �Name$  
MainWindow��5   ?    � Title$ Erste��5
   	    � WindowStartupLocation$ CenterScreen=�6   $	��659��6<   $	��830��6I   $��Stretch=�6U   $��Stretch=�6z   .��5      � 
�������$
��Auto=�6#    � RowDefinitions 5   
   �� 5      $
��361* �6    � ColumnDefinitions 5   
   �� 5      $
��185* �6   $	��160��6,   �� 5      $
��608* �6   .+�5   
   �� $��0��6   ���	#FF6DCEF9 � UseLayoutRounding .  $��0,0,0,0q�6V   .+�5      �� -   5         ��Name$ image��5      $��0��6#   $��0��60   $��60��6@   $��/Resources/erste_logo.png��6L   $
��Fill=�6o   $��0q�6~   �� 5      -   5         ��Name$ label��5      $��31��6#   $��0q�6/   $��	Kandidati��6:   $��14(�6N   $��Rockwell)�6\   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5      -   5         ��Name$ 
upisButton��5         buttonStyle#���   6)   $��Upiši kandidata��6O   $
��Left=�6i   $��35��6�   �� 5      -   5        $ pregledButton��5      #���   6,   $��Prikaži sve kandidate��6R   $
��Left=�6s   $��44��6�   5      �� 5      -   5        $ pregledCekanjeButton��5      #���   63   $
��Left=�6Y   $��47��6{   $��0q�6�   .��5      �� $$��Prikaži kandidate na čekanju��6   $
��Wrap=�6@   	 �� TextAlignment$	 Center=�6T   $	��132��6k   $��0q�6w   $��36��6�   5      �� 5      -   5        $ grupe��5      $��31��6#   $��0q�6/   $��Grupe��6:   $��14(�6J   $��Rockwell)�6X   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5       -   5        $ pregledGrupa��5       #���   6+   $��Prikaži grupu��6Q   $
��Left=�6i   6�   �� 5!      -	   5        $ kreiranjeGrupe��5!      #���   6-   $��Dodaj novu grupu��6S   $
��Left=�6n   6�   �� 5"      -
   5        $ label1��5"      $��31��6$   $��0q�60   $��Raspored nastave��6;   $��14(�6V   $��Rockwell)�6d   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5#      -   5        $ rasporedButton��5#      #���   6-   $��Prikaži raspored��6S   $
��Left=�6n   6�   �� 5$      -   5        $ noviTerminButton��5$      #���   6/   $��Dodaj novi termin��6U   $
��Left=�6q   6�   �� 5%      
 �� Orientation$
 Vertical=�6   .+�5&      �� -   5        $ label2��5&      $�� ��6(   $	��141��63   $��0q�6@   5'      �� 5(      -   5        $ odjavaButton��5(      #���   6+   $��Odjava��6Q   $
��Left=�6b   6�   �� 5)      -   5        $ button4��5)      #���   6&   $��Izlaz��6L   $
��Left=�6\   $��Bottom=�6�   5*      � 5+   
   -   5         �Name$ GridZaPrikaz��5+      $��1��6%   $��0,1,0,0q�65   5,      5-      