   M S B A M L   `   `   `  ����S  OКосметология, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:КосметологияКосметология  5   	   @    :Косметология.Оформление_заявки   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Косметология     5   	   -   5          � Title$'  !Оформление заявки��5   	   $	��854��6#   $	��814��60    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ NoResize=�6�   .��5	      � -   5        $��Grid3��5	      $��0,0,0,-1q�6    J� RenderTransformOrigin$ 0.383,0.372&�6*    � RowDefinitions 5
   
   �� 5      $
��699* �6   �� 5      $	��25* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF8D9BC7��6   � 5      $ 	#FF303D69��6    � Offset$ 1Q�61   5      .+�5   
   �� $��/Source/desigh2.png��6   $��-52,258,-134,-139q�6-   	 J� OpacityMask
	 �   �$��2��6\   {�.  6m   �� 5   
   -   5        $
��Left=�5      $	��134��6+   $��327,676,0,0q�68   $	��Top=�6M   $	��152��6e   $��/Source/ЛБ_512.png��6q   
 � Cursor$

 Hand��6�   {�.  6�   �� 5   
   -   5         ��Name$ txtFio��5      $
��Left=�6"   $��465,247,0,0q�6=    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��278��6~   $��59��6�   $��Dubai Medium)�6�   �� 5   
   -   5        $ txtTel��5      $
��Left=�6"   $��466,328,0,0q�6=   $
 Wrap=�6R   $	��Top=�6f   $	��278��6~   $��36��6�   $��Dubai Medium)�6�   �� 5   
   -   5        $ txtMail��5      $
��Left=�6#   $��465,386,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��278��6   $��36��6�   $��Dubai Medium)�6�   �� 5   
   -   5        $ 	txtPriceW��5      $
��Left=�6%   $��465,444,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��278��6�   $��36��6�   $��Dubai Medium)�6�   �� 5   
   -   5        $ 	txtSkidka��5      $
��Left=�6%   $��465,502,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��278��6�   $��36��6�   $��Dubai Medium)�6�   �� 5   
   -	   5        $ 	txtPriceS��5      $
��Left=�6%   $��465,560,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��278��6�   $��36��6�   $��Dubai Medium)�6�   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ DateP��5      $
��Left=�6$   $��204,404,0,0q�6?   $	��Top=�6T   $	��150��6l   $��38��6x   $��Dubai Medium)�6�      FirstDayOfWeek$ Monday=�6�      SelectedDateFormat$ Short=�6�      IsTodayHighlighted . ��5      �� 5      $ 0.5,0&�6&   $ 0.5,1&�67   .��5       � $ 	#FFA3AEB9��6#   � 5!      $ 	#FF8399A9��6#   $ 0Q�65   � 5"      $ 	#FF718597��6#   $ 0Q�65   � 5#      $ 	#00FFFF00��6#   $ 0Q�65   5$      5&      �� 5'   
   $��ФИО:��6   $
��Left=�6   $��411,260,0,0q�6:   $	��Top=�6O   $��48��6g   $��Dubai Medium)�6r   $��14(�6�   
�������$��34��6�   �� 5(   
   $��Телефон:��6   $
��Left=�6#   $��384,329,0,0q�6>   $	��Top=�6S   $��72��6k   $��Dubai Medium)�6v   $��14(�6�   
�������$��33��6�   �� 5)   
   $��Mail:��6   $
��Left=�6    $��415,387,0,0q�6;   $	��Top=�6P   $��40��6h   $��Dubai Medium)�6s   $��14(�6�   
�������$��34��6�   �� 5*   
   $#��Цена без
скидки:��6   $
��Left=�6/   $��383,433,0,0q�6J   $	��Top=�6_   $��72��6w   $��Dubai Medium)�6�   $��14(�6�   
�������$��57��6�   �� 5+   
   $��Скидка:��6   $
��Left=�6"   $��393,507,0,0q�6=   $	��Top=�6R   $��62��6j   $��Dubai Medium)�6u   $��14(�6�   
�������$��34��6�   �� 5,   
   $*��$Итоговая
стоимость:��6   $
��Left=�62   $��371,549,0,0q�6M   $	��Top=�6b   $��84��6z   $��Dubai Medium)�6�   $��14(�6�   
�������$��57��6�   �� 5-   
   -   5        $��Сохранить��5-      $
��Left=�6%   $��465,718,0,0q�6@   $	��Top=�6U   ���	#FF35B113$��40��6�   $��98��6�   $��Dubai Medium)�6�   �� 5.   
   -   5        $��Отмена��5.      $
��Left=�6"   $��645,718,0,0q�6=   $	��Top=�6R   $��40��6j   $��98��6v   ���	#FFFF5050$��Dubai Medium)�6�   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ ClientsGrid��5/      $��	0,0,0,636q�6(   �� 50   
   -   5        $ txtID��50      $
��Left=�6!   $��204,247,0,0q�6<   $
 Wrap=�6Q   $	��Top=�6e   $��52��6}   $��26��6�   $��Dubai Medium)�6�   6�   �� 51   
   $��Код клиента:��6   $
��Left=�6'   $��
51,243,0,0q�6B   $	��Top=�6V   $��94��6n   $��Dubai Medium)�6y   $��14(�6�   
�������$ 0.402,1.428&�6�   $��34��6�   �� 52   
   $��Поиск по ФИО:��6   $
��Left=�6(   $��
51,196,0,0q�6C   $	��Top=�6W   $	��114��6o   $��Dubai Medium)�6{   $��14(�6�   
�������$ 0.402,1.428&�6�   $��34��6�   �� 53   
   -   5        $ 	txtSearch��53      $
��Left=�6%   $��204,200,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��539��6�   $��26��6�   $��Dubai Medium)�6�   �� 54   
   -   5         ��Name$ ComPrice��54   %    �� SelectedIndex$ 0��6   $
��Left=�67   $��204,300,0,0q�6R   $	��Top=�6g   $	��120��6   $��22��6�   $��Dubai Medium)�6�   6�   �� 55   
   -   5        $ ComStuff��55   %   $ 0��6   $
��Left=�67   $��204,350,0,0q�6R   $	��Top=�6g   $	��120��6   $��22��6�   $��Dubai Medium)�6�   �� 56   
   -   5        $(��"Ваучер для клиента��56      $
��Left=�6.   $��
21,724,0,0q�6I   $	��Top=�6]   $��38��6u   $	��124��6�   $��Dubai Medium)�6�   �� 57   
   -   5        $��
Отчет��57      $
��Left=�6!   $��177,724,0,0q�6<   $	��Top=�6Q   $��38��6i   $	��124��6u    � ToolTip$� Сохранить перед созданием отчета. Создает отчет по последнему заказу��6�   $��Dubai Medium)�6�   �� 58   
   $(��"Выбор специалиста:��6   $
��Left=�6-   $��
51,344,0,0q�6H   $	��Top=�6\   $	��146��6t   $��Dubai Medium)�6�   $��14(�6�   
�������$��34��6�   �� 59   
   $��Выбор услуги:��6   $
��Left=�6(   $��
51,295,0,0q�6C   $	��Top=�6W   $	��124��6o   $��Dubai Medium)�6{   $��14(�6�   
�������$��34��6�   �� 5:   
   $1��+Дата выполнения
заказа:��6   $
��Left=�66   $��
54,386,0,0q�6Q   $	��Top=�6e   $	��133��6}   $��Dubai Medium)�6�   $��14(�6�   
�������$��57��6�   � 5;   
   -   5         �Name$ border��5;      $��2��6   .+�5<      �� 
���   �$��1q�6)   
�������6=   �� 5>      $��v 1.1��6   $
��Left=�6$   $��	-1,-4,0,0q�6?   $	��Top=�6R   $��23��6j   5@      �� 5A   
   -   5        $��Подтвердить��5A      $
��Left=�6'   $��141,571,0,0q�6B   $	��Top=�6W   $��Dubai Medium)�6�   $	��175��6�   $��25��6�   �� 5B   
   -   5        $ txtTimeS��5B      $
��Left=�6$   $��144,447,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��172��6�   $��36��6�   $��Dubai Medium)�6�   6�   �� 5C   
   $��Начало:��6   $
��Left=�6"   $��
46,449,0,0q�6=   $	��Top=�6Q   $��62��6i   $��Dubai Medium)�6t   $��14(�6�   
�������$��34��6�   �� 5D   
   -   5        $ txtTimeE��5D      $
��Left=�6$   $��144,488,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��172��6�   $��36��6�   $��Dubai Medium)�6�   6�   �� 5E   
   $��Конец:��6   $
��Left=�6!   $��
46,491,0,0q�6<   $	��Top=�6P   $��62��6h   $��Dubai Medium)�6s   $��14(�6�   
�������$��34��6�   �� 5F   
   $��Формат ЧЧ:ММ��6   $
��Left=�6'   $��143,531,0,0q�6B   $	��Top=�6W   
�������6o   �� 5G   
   -   5        $
��Left=�5G      $��28��6+   $��329,347,0,0q�67   $	��Top=�6L   $��30��6d   $��/Source/61227.png��6o   $

 Help��6�   6�   5I      5L      