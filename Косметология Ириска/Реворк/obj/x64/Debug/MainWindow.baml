   M S B A M L   `   `   `  ����S  OКосметология, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:КосметологияКосметология  5   	   )    #Косметология.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Косметология     5   	     � Title$  
MainWindow��5   	   $	��305��6   $	��279��6)    � 
ResizeMode$ NoResize=�65   ���	#FF6681A5 � WindowStyle$
 None=�6b    � WindowStartupLocation$ CenterScreen=�6u    � 	Resources 5	         Comboxbutton �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 :� RoutedEvent �� TargetProperty g� Duration	 t� To��%�  &	        �� 5
   
   " ��6%   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� �	#FFFFFFFF6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      :� 5      $
 PreviewMouseDown��6+   .[�5   "   �� .��5   &   �� .��5   *   t� $ Margin�6=   $ 	0:0:0.100D�5   =   $ 2, 2,0,0X�6R   5   +   5   '   5   #   5      :� 5      $
 PreviewMouseUp��6+   .[�5    "   �� .��5!   &   �� .��5"   *   t� $ Margin�6=   $ 	0:0:0.100D�5#   =   $ 0X�6R   5%   +   5&   '   5'   #   5(      5*      5,      5-      5/      .��51      �  � RowDefinitions 52   
   �� 53      $��28 �6   �� 54      .+�57   
   � -   5         �Name$ ToolBar��57      $��0��6    ���	#FF929292$��	0,0,0,268q�6D   $��2��6W   .+�59      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5:      �� -   5        $��3q�5:      $��23��6#   $��23��6/   $��/Source/Черта.png��6:   5=      �� 5>      -   5        $��3q�5>      $��22��6#   $��23��6/   $ ��/Source/Крестик.png��6:   5A      5B      5D      � 5E   
   -   5        $
 Main��5E      $��1��6   .+�5G      �� $
��Left=�6   $	��218��6/   $��32,-45,-17,0q�6<   $	��Top=�6R   $	��264��6j   $��/ЛБ_512.png��6v   �� 5I      -   5         ��Name$ 
Polsovatel��5I      $
��Left=�6+   $��158,164,0,0q�6F   $	��Top=�6[   $��99��6s    �� SelectedIndex$ 0��6�   $��SemiCondensed&�6�    � Cursor$ Arrow��6�   .@�5J      �� $��Менеджер��6   �� 5K      $��
Админ��6   5L      �� 5M      -   5         ��Name$ Login��5M      $
��Left=�6%   $��	88,95,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��169��6   6�   �� 5N      -   5        $ Password��5N      $
��Left=�6(   $��
88,136,0,0q�6C   $
 Wrap=�6W   $	��Top=�6k   $	��169��6�   �� 5O      $��
Логин��6   $
��Left=�6$   $��	23,88,0,0q�6?   $	��Top=�6R   
�������$��Dubai Medium)�6}   $��14(�6�   �� 5P      $��Пароль��6   $
��Left=�6%   $��
23,130,0,0q�6@   $	��Top=�6T   
�������$��Dubai Medium)�6   $��14(�6�   �� 5Q      -   5        $��
Выйти��5Q      $
��Left=�6%   $��193,223,0,0q�6@   $	��Top=�6U   $��30��6m   $��55��6y   ���	#FFFF5050 �� IsCancel . 6�   �� 5R      -	   5        $��
Войти��5R      $
��Left=�6%   $��
40,223,0,0q�6@   $	��Top=�6T   $��30��6l   $��55��6x   ���	#FF0ABD25 �� 	IsDefault . 6�   5T      ��5U   
   �� 5V       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5W      �  � Color$ Black��6   � 5X      $ 	#FF3F6EFF��6    � Offset$ 1Q�61   5Y      5]      5a      