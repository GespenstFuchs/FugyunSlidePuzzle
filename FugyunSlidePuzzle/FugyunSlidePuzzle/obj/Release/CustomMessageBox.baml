   M S B A M L   `   `   `  ���� L  HFugyunSlidePuzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FugyunSlidePuzzleFugyunSlidePuzzle  (    "FugyunSlidePuzzle.CustomMessageBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:FugyunSlidePuzzle     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  	エラー��$	��500��$	��230�����	#FBC0C0FF$��16(� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=� � WindowStyle$ SingleBorderWindow=� � 	Resources    CommonButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%r  &	        �� " ��.���  � ��
 ��+����  � ��
 �������  � ��$
 Bold"���  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� $
 border��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � ��
 ��U��P�  �@J�	IsFocused . . ��� $ border�� � ��
 ��U��.���  � RowDefinitions �� $��* ��� $��70 �.+�� $��0��$��0�� �� $��* � � ColumnDefinitions �� $	��120 ��� $��* �.+��� $��0��$��0��$��Right=�$��Center=�.+��� -    ��Name$ InfomationImage��$��72��$��72��$��Infomation.png��$y�	Collapsed=��� -   $ 
ErrorImage��$��72��$��72��$��	Error.png��$y�	Collapsed=��� -   $ WarningImage��$��72��$��72��$��Warning.png��$y�	Collapsed=��� -   $ QuestionImage��$��72��$��72��$��Question.png��$y�	Collapsed=��� $��0��$��1��$
��Left=�$��Center=�.+��� -    ��Name$ MessageTextBlock��$��0��$��1��$��10,0,0,0q�$��メッセージ���� $��1��$��0��$��Center=�$	��Top=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ Button1��$	��100��$��40��$��Button1��#��[  �� -   $
 Border1��$��30��$y�	Collapsed=��� -	   $ Button2��$	��100��$��40��$��Button2��#��[  $y�	Collapsed=��� -
   $
 Border2��$��30��$y�	Collapsed=��� -   $ Button3��$	��100��$��40��$��Button3��#��[  $y�	Collapsed=�