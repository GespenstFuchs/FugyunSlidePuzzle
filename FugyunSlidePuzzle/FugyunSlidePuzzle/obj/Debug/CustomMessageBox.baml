   M S B A M L   `   `   `  ����L  HFugyunSlidePuzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FugyunSlidePuzzleFugyunSlidePuzzle  5      (    "FugyunSlidePuzzle.CustomMessageBox   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:FugyunSlidePuzzle     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  	エラー��5      $	��500��5	      $	��230��5
      ���	#FBC0C0FF$��16(�5       � 
ResizeMode$ NoResize=�5       � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�5       � WindowStyle$ SingleBorderWindow=�5       � 	Resources 5         CommonButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6*   .�5      ��  � ��
 ��+��6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 border��5      #��z��5       $ 15��5!      ._�5"      �� $��Center=�6/   $��Center=�6L   5#       5$      P� 5%       �@J�IsMouseOver . . �5&   "   �� $ border��6)    � ��
 ��U��6S   5'      P� 5(       �@J�	IsFocused . . �5)   "   �� $ border��6)    � ��
 ��U��6S   5*      5,      5.      5/      50      .��51      �  � RowDefinitions 52   
   �� 53      $��* �6   �� 54      $��70 �6   .+�57   
   � $��0��6   $��0��6    58      �� 59      $��* �6     � ColumnDefinitions 5<      �� 5=      $	��120 �6#   �� 5>      $��* �6#   .+�5A      �� $��0��5B      $��0��5C      $��Right=�5D      $��Center=�5E      .+�5F      �� -   5         ��Name$ InfomationImage��5G      $��72��5H      $��72��5I      $��Infomation.png��5J      $y�	Collapsed=�5K      �� 5L      -   5        $ 
ErrorImage��5M      $��72��5N      $��72��5O      $��	Error.png��5P      $y�	Collapsed=�5Q      �� 5R      -   5        $ WarningImage��5S      $��72��5T      $��72��5U      $��Warning.png��5V      $y�	Collapsed=�5W      �� 5X      -   5        $ QuestionImage��5Y      $��72��5Z      $��72��5[      $��Question.png��5\      $y�	Collapsed=�5]      5^      �� 5_      $��0��5`      $��1��5a      $
��Left=�5b      $��Center=�5c      .+�5d      �� -   5         ��Name$ MessageTextBlock��5e      $��0��5f      $��1��5g      $��10,0,0,0q�5h      $��メッセージ��5i      5j      5k      �� 5m   
   $��1��5n      $��0��5o      $��Center=�5p      $	��Top=�5q       �� Orientation$ 
Horizontal=�5r      .+�5s      �� -   5         ��Name$ Button1��5t      $	��100��5u      $��40��5v      $��Button1��5x      #��[  5y      �� 5z      -   5        $
 Border1��5{      $��30��5|      $y�	Collapsed=�5}      �� 5~      -	   5        $ Button2��5      $	��100��5�      $��40��5�      $��Button2��5�      #��[  5�      $y�	Collapsed=�5�      �� 5�      -
   5        $
 Border2��5�      $��30��5�      $y�	Collapsed=�5�      �� 5�      -   5        $ Button3��5�      $	��100��5�      $��40��5�      $��Button3��5�      #��[  5�      $y�	Collapsed=�5�      5�      5�      5�      