   M S B A M L   `   `   `  ����  priceComparer    priceComparer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   
   $	��600��6   $	��800��6*    � 
ResizeMode$ NoResize=�67   $	��510��6M   $	��600��6]   .��5      � -   5        $��mainGrid��5   5   $��0q�6    J� IsManipulationEnabled .  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��220* �6   .+�5
   
   �� ���#ffffff$
��Left=�6#   $��40��6>   $��0,3,0,0q�6J   $��1��6[   $	��Top=�6i   $	��794��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 6Q�6#      	Direction$	 -90Q�62      Opacity$	 0.3Q�6B      ShadowDepth$ 2Q�6P   5      �� 5   
   $��70,5,433,527q�6   $��Berlin Sans FB)�6*   $��33��6F   $��1��6R   ���#808180$��Center=�6t   $��30(�6�   �� 6�   $�PriceComparerUa��6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $	��Top=�6+   $��/images/ua.png��6C   $��27��6[   $��21��6f   $��1��6r   $��304,10,0,532q�6   �� 5   
   -   5        $��hometab��5      $	��430��6%   $��0,3,0,0q�62   $
��10,0q�6C   $	��Top=�6R   
������ $��2��6�   
������ 	 J� 	AllowDrop	 . ���	#FF808180$��SemiBold"�6�   
 � IsSharedSizeScope
 . .@�5      �� -   5        $
��Home��5   '   $��Главная��6   $��407,0,-409,-20q�63    J� RenderTransformOrigin$ 0.5,0.5&�6K   $��Normal"�6k   ���	#FF20515C$��Colibri)�6�   	 . $��0q�6�    �� 
IsSelected . .��5      � ���#edf3f2$��50,20,50,-4q�6,    5        5      $ 20Q�6+   $ 12Q�6<   $	 -85Q�6L   $	 0.6Q�6\   .+�5      �� $
��Left=�6   $	��229��67   $��	26,70,0,0q�6D   $	��Top=�6W   $��/images/uaMap.png��6o   $	��321��6�   �� 5      $
��Left=�6    $��13,0,0,0q�6;   $
��Wrap=�6M   $	��Top=�6a   $	��334��6y   $��14(�6�   ���	#FF1F9DCD$��Segoe UI Semilight)�6�   $��SemiBold"�6�   $��24��6�   �� 6�   $N�HСравните цены в магазинах вашей страны!��6�   �� 6"  �� 6.  65  �� 5      $��	0,94,33,0q�6    $
��Wrap=�63   $	��Top=�6G   $	��251��6_   $��13(�6k   ���	#FF595858$��Tahoma)�6�   $��
ExtraLight"�6�   $��Right=�6�    �� 
LineHeight$ 19��6�   $	��270��6�    �� TextAlignment$ Justify=�6�   �� 6  $���Данное настольное Windows-приложение 'PriceCompaperUa' позволит Вам быстро и удобно находить нужный товар в базе прайсов украинских Интернет-магазинов, сравнивать цены, делать лучший выбор и экономить своё время и средства.��6  �� 6�  �� 6  6  5      5      �� 5      -   5        $��Partners��5   (   $��Партнёры��6   $��558,0,-562,-20q�69   $ 0.5,0.5&�6Q   ���	#FF20515C$��Colibri)�6�   .��5      � ���#edf3f2$��	0,20,0,-4q�6,    J� Opacity$
 0.95Q�6?    5        5      $ 20Q�6+   $ 12Q�6<   $	 -85Q�6L   $	 0.6Q�6\   .+�5"      &   System.Windows.Controls.DataGrid  -   5        $��	datagrid3��5#   2      AutoGenerateColumns .  $	��308��6
   $
��Left=�6   $��Bottom=�6C   $	��509��5$   
   	 . $��	19,0,0,10q�6'   
����������#666666   ClipboardCopyMode$ IncludeHeader=�6b      SelectionMode$ Extended=�5%      ��5"      �� ��5$   �   Z�  � 	Resources 5&       �� Color��%V   (��       5'   .   *DataGrid.FocusBorderBrushKey+)�� 6   $ Transparent��6^   5)      5*      �� 5+      
������ $	��199��6;   $��Right=�6G   $��
0,32,24,10q�6c   .+�5,      �� $
��Wrap=�6&   $	��151��6:   $��
12,50,10,0q�6G   ���	#FF555555$��Light"�6r   $��14(�6�   $ Center=�6�   �� 6�   $���Вы можете ознакомиться со списком наших партнёров, прайсы которых доступны для поиска в нашем приложении, а также перейти на их веб-страницы.��6�   6H  5.      5/      50      �� 51      -   5        $��
favourites��51   )   $��Избранное��6   $��562,0,-564,-20q�6<   $ 0.5,0.5&�6T   ���	#FF20515C$��Colibri)�6�   .��52      � ���#edf3f2$��	0,17,0,-1q�6,   $
 0.95Q�6?    53        54      $ 20Q�6+   $ 12Q�6<   $	 -85Q�6L   $	 0.6Q�6\   .+�56        -   5        $��	datagrid2��57   2    .  $	��308��6
   $
��Left=�6   $��Bottom=�6C   $	��509��58   
   	 . $��	19,0,0,10q�6'   
����������#666666$ IncludeHeader=�6b   $ Extended=�59      ��56      �� ��58   �   Z�  5:      ��%V   (��       5;   .   *DataGrid.FocusBorderBrushKey+)�� 6   $ Transparent��6^   5<      5=      �� 5>      
������ $	��199��6;   $��Right=�6G   $��
0,32,24,10q�6c   .+�5?      �� $
��Wrap=�6&   $	��151��6:   $��
12,50,10,0q�6G   ���	#FF555555$��Light"�6r   $��14(�6�   $ Center=�6�   �� 6�   $���Здесь вы можете просматривать сохраннные из результатов поиска позиции наиболее интересных товаров.��6�   6  �� 5@      -   5         ��Name$ ResetFavorite��5@   !   $��Reset favorite��68   $
��left=�6Q   $��45��6l   $��9,9,0,10q�6x   $	��Top=�6�   $	��183��6�   6�   5A      5B      5C      �� 5D      -	   5        $��searchP��5D   ,   $��Поиск товара��6   $��261,0,-263,-20q�6<   $ 0.5,0.5&�6T   ���	#FF20515C$��Colibri)�6�   .��5E      � ���#edf3f2$��	0,20,0,-4q�6,   $
 0.95Q�6?    5F        5G      $ 20Q�6+   $ 12Q�6<   $	 -85Q�6L   $	 0.6Q�6\   .+�5I      �� $��
Поиск��6   ���	#FF8A8E8F$��Light"�6C   $��	15,10,0,0q�6V   �� 5J      -
   5         ��Name$ 	searchVal��5J      $
��Left=�61   $��26��6L   $��	20,32,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��262��6�   $��Normal"�6�   	 . ���	#FF838080$��13(�6  �� 5K      -   5        $ addToFavorite��5K      $��Add to favorite��64   $��Right=�6N   $��05,32,250,100q�6j   $	��Top=�6�   $	��106��6�   $��26��6�   6�     5L      -   5        $��	datagrid1��5M   2    .  $	��308��6
   $
��Left=�6   $��Bottom=�6C   $	��509��5N   
   	 . $��19,0,0,4q�6'   
����������#666666$ IncludeHeader=�6a   $ Extended=�5O      ��5L      �� ��5N   �   Z�  5P      ��%V   (��       5Q   .   *DataGrid.FocusBorderBrushKey+)�� 6   $ Transparent��6^   5R      5S      �� 5T      -   5         ��Name$ Advirstment��5T   !   ���#ffffff$	��199��6L   $��Right=�6X   $��
0,31,24,11q�6t   .+�5U      �� -   5         ��Name$ ProductImage��5U       $	��150��66   $	��130��6B   $��12,12,12,10q�6P   $!��/images/products/iphone.png��6e   �� 5V      -   5         ��Name$ ProductDescription��5V   $   ���#777777$	��194��6U   $��	12,0,10,0q�6b   $
��Wrap=�6u   �� 6�   $���В базе данных нашого приложения вы можете сравнить цены на следующие товары: Мобильные телефоны, компьютеры, фото-, аудио- и видео техника, а также сопутствующие товары и аксессуары.                           Из таблицы результатов товары можно построчно добавлять в Избранное.��6�   5W   d   5X      5Y      5Z      �� 5[      -   5        $��styles��5[   %   $��
Стили��6   $��263,0,-271,-20q�64   $ 0.5,0.5&�6L   ���	#FF20515C$��Colibri)�6�   .��5\      � ���#edf3f2$��	0,18,0,-2q�6,   $
 0.95Q�6?    � ColumnDefinitions 5]      �� 5^      $
��208* �6+   �� 5_      $��9* �6+   �� 5`      $
��169* �6+    5b        5c      $ 20Q�6+   $ 12Q�6<   $	 -85Q�6L   $	 0.6Q�6\   .+�5e      �� $��Center=�6    $��161,50,161,0q�6=   $ Center=�6S   $
��Wrap=�6j   $	��Top=�6~   $	��450��6�   $��15(�6�   ���#555555$��Calibri)�6�   $��Light"�6�   $��50��6�   $��3��6�   �� 6  $���Вы можете изменить цветовое оформление Вашего приложения - просто выберите другую тему оформления.��6  6  	� 5f      -   5         	�Name$ lightBlueTheme��5f   "   $;��5Светло-синяя тема оформления��6:   $
��Left=�6b   $��20��6}   $��250,235,0,135q�6�    	� 	GroupName$ 
themeGroup��6�   $��3��6�   ��6�   �� *choosedTheme+6�   	� 5g      -   5        $ darkBlueTheme��5g   "   $9��3Тёмно-синяя тема оформления��69   $
��Left=�6_   $��20��6z   $��250,190,0,180q�6�   $ 
themeGroup��6�   $��3��6�   ��6�   �� *choosedTheme+6�   	� 5h      -   5        $ 	blueTheme��5h   "   $H��BСиняя тема оформления (по умолчанию)��65   $
��Left=�6d   $��50��6   $��250,140,0,200q�6�   $ 
themeGroup��6�    d� 	IsChecked$
 TrueY�6�   $��3��6  ��6�   �� *choosedTheme+6  �� 5i      -   5        $ 
themeValue��5i      $y�	Collapsed=�62   �� 5j      -   5        $ 	savetheme��5j      $��
save theme��60   $��Right=�6E   $��
05,32,1,70q�6a   $��Bottom=�6u   $	��106��6�   $��26��6�   6�   5k      5l      5m      �� 5n   
   ���#ffffff$
��Left=�6#   $��3��6>   $��
0,429,-6,0q�6I   $��1��6]   $	��Top=�6k   $	��800��6�    5o        5p      $ 8Q�6#   $	 -90Q�62   $	 0.3Q�6B   $ 2Q�6P   5r      �� 5s   
   $
��Left=�6   $	��141��6+   $��684,329,0,0q�68   $	��Top=�6M   $	��110��6e   $��/images/sale.png��6q   $��1��6�   �� 5t   
   ���	#FF99D8E2$
��Left=�6%   $��1��6@   $��0,42,0,0q�6K   $��1��6]   $	��Top=�6k   $	��800��6�   9� 5u   
   $/��)Написать разработчику��6   ���#cccccc$
��Left=�6G   $��
92,437,0,0q�6b   $��1��6v   $	��Top=�6�   $	��613��6�   $��14(�6�    � Cursor$
 Hand��6�   .��5v      � 
������ $��10,0,8,0q�6,   .+�5w      �� -   5        $ newname��5w      ���#999999$
��Left=�6@   $��25��6[   $
 Wrap=�6h   $��Тема��6|   $	��Top=�6�   $	��200��6�   $��0,5,0,0q�6�   $��2��6�   $��Calibri)�6�   $��13(�6�   �� 5x      -   5        $ newemail��5x      ���#999999$
��Left=�6A   $��25��6\   $
 Wrap=�6i   $��Ваш Email��6}   $	��Top=�6�   $	��200��6�   $��0,35,0,0q�6�   $��2��6�   $��13(�6�   $��Calibri)�6�   �� 5y      -   5        $ newtextarea��5y      ���#999999$
��Left=�6E   $��55��6`   $
 Wrap=�6m   $	��Top=�6�   $	��290��6�   $��	210,5,0,0q�6�   �� 5z      -   5        $ BtnSendEmail��5z      $��Отправить��6/   $��right=�6C   $��0,35,0,0q�6_   $	��Top=�6q   $��85��6�   $��27��6�   $��2��6�   6�   5{      5|      �� 5}   
   -   5        $��copyr��5}      ���#cccccc$
��Left=�67   $��100,526,0,0q�6R   $��1��6g   $
��Wrap=�6t   $K��EВсе права защищены. Раработка Бизид.Л.��6�   $	��Top=�6�   $��11(�6�   5~      5�      