   M S B A M L   `   `   `  ����@  <Erste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ErsteErste  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Erste.AdminMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Erste     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          �Name$  
MainWindow��5   ?    � Title$ Erste��5
   	   $	��505��6   $	��833��6$   $��Stretch=�60   $��Stretch=�6U    � WindowStartupLocation$ CenterScreen=�6x   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��361* �6    � ColumnDefinitions 5   
   �� 5      $
��185* �6   $	��160��6,   �� 5      $
��608* �6   .+�5   
   �� ���	#FF6DCEF9 � UseLayoutRounding .  $��0,0,0,1q�6F   .+�5      �� -   5         ��Name$ image��5      $��60��6#   $��0q�6/   $��Resources/erste_logo.jpg��6:   $	��Top=�6\   $
��Fill=�6t   �� 5      -   5         ��Name$ label��5      $��31��6#   $��0q�6/   $��Službenici��6:   $��14(�6O   $��Rockwell)�6]   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5      -   5         ��Name$ prikaziSluzbenikeButton��5         buttonStyle#���   6V   $��Prikaži službenike��6|   $
��Left=�6�   �� 5      -   5        $ dodajSluzbenikeButton��5      #���   6S   $��Dodaj službenika��6y   $
��Left=�6�   �� 5      -   5        $ label1��5      $��31��6$   $��0q�60   $��	Profesori��6;   $��14(�6O   $��Rockwell)�6]   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5      -   5        $ prikaziProfesoreButton��5      #���   6X   $��Prikaži profesore��6~   $
��Left=�6�   �� 5      -   5        $ dodajProfesoreButton��5      #���   6Q   $��Dodaj profesora��6w   $
��Left=�6�   �� 5      -	   5        $ label2��5      $��31��6$   $��0q�60   $��Kursevi��6;   $��14(�6M   $��Rockwell)�6[   ���	#FFEF3D4A$
��Bold"�6�   $��8,8,5,5q�6�   6�   �� 5      -
   5        $ prikaziKurseveButton��5      #���   6T   $��Prikaži kurseve��6z   $
��Left=�6�   �� 5      -   5        $ dodajKursButton��5      #���   6G   $��
Dodaj kurs��6m   $
��Left=�6�   �� 5      $��40��6   6"   �� 5       -   5        $ odjavaButton��5       #���   6+   $��Odjava��6Q   $
��Left=�6b   $��35��6�   $��0,0,-0.333,0q�6�   �� 5!      -   5        $ button6��5!      #���   6&   $��Izlaz��6L   $
��Left=�6\   $��40��6�   $��Bottom=�6�   $��0,0,-0.333,0q�6�   5"      � 5#   
   -   5        	 �Name$	 GridZaPrikaz��5#      $��1��6%   5$      5%      5&      