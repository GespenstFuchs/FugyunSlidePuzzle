   M S B A M L   `   `   `  ���� L  HFugyunSlidePuzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FugyunSlidePuzzleFugyunSlidePuzzle  "    FugyunSlidePuzzle.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:FugyunSlidePuzzle     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$'  !ふぎゅんスライドパズル��$
��1400��$	��740��$��16(� � WindowStartupLocation$ CenterScreen=� � 	Resources    CommonButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName J� SnapsToDevicePixels � RowDefinitions ��Name K� ZIndex K� IsItemsHost ��Name  RoundedTabItemStyle �� Padding  ComboBoxToggleButton � ColumnDefinitions  ComboBoxTextBox �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �� 
IsReadOnly  � AllowsTransparency! �� IsDropDownOpen" � ActualWidth# �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% P� 
SourceName  AlignedCheckBoxStyle& �� Orientation' F�Name=  7System.Windows.Controls.Primitives.DataGridColumnHeader  EditDataGridCellStyle*  $System.Windows.Controls.DataGridCell( �� Triggers  ReadOnlyDataGridCellStyle��%�  &	        '�� h    &	 �    &	 �    &	 o    '�� �    7  7  &	 	    '  �    &	 p    &	 �    �� " ��.���  � ��
 ��+����  � ��
 �������  � ��$
 Bold"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��#��z��$ 15��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border�� � ��
 ��U��P� 
 �@J�	IsFocused . . ��� $ border�� � ��
 ��U���� " ��.���  � �� �� " ��.R�� }�.  .  �� $
��Auto ��� $��* �.+��� $ HeaderPanel��$��0��$��0,0,4,0q�$ 1��
������  . �� $ Border��$��1��$��0,0,0,0q�
����+��$��0q�$ 5��._��� $ PART_SelectedContentHost��$��4q�$��SelectedContent���� " ��.���  � �� �� " ��.R��� $ Border��$
 10,2q�#��z��#��z��$��2q�$ 	20,20,0,0��._��� $ ContentSite��$��Center=�$��Center=�$��Header��	 P� 
 �@��
IsSelected . . ��� $ Border�� � ��
 ������ $ Border�� � ��
 ��+��P� 
 �@��
IsSelected .  . ��� $ Border�� � ��
 ������� $ Border�� � ��
 �����P� 
 �@J�IsMouseOver . . ��� $ Border�� � ��
 ������ $ Border�� � ��
 ��+����  � ��$ 20(��� " d�.R��  �� �� $��20 �.+��� $��Border��$��2��
�������
����+��$��2q�$ 5,5,5,5��F� $��1��$��4,0,0,0q�$��Center=�"����        � 	=  	= � z     	
����+���� " ��.R��� $��PART_ContentHost��
������ |�.  �� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R�� .+�d� $��ToggleButton��$��2��$ Press=�|�.  8��   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite��$��	10,3,23,3q�$
��Left=�$��Center=�#��z #��z #��z�� .  �� $ PART_EditableTextBox��$��3,3,23,3q�$
��Left=�$	��Top=�
������ |�. # z 8�� $y�Hidden=���Z� � $��Popup��  . |�.  #��z! $��Bottom=�$��Slide=�.��� $��DropDown��#��z" #��z#  . .+��� $ DropDownBorder��
�������
����+��$��2q��� $��4,6,4,6q� . .����  . $$ 	Contained=�	 P� 
 �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P� 
 � {� .  . ���  � ��
 �����P� 
 �@��
IsGrouping . . ���  � �� .  P� $% Popup��
 �@�AllowsTransparency . . ��� $ DropDownBorder�� �@��CornerRadius$ 4���� $ DropDownBorder�� � ��$ 0,2,0,0q��� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $��Center=�$& 
Horizontal=�.+�� $��16��$��16��$��Center=�.+��� $ Border��$��16��$��16��
�������
����+��$��2q�F� $' 	CheckMark��"����    ��[ р�[  � � $�     	
����  �$��3��$y�Hidden=��� $��5,0,0,0q�$��Center=�#��z��	 P� 
 �@d�	IsChecked$
 TrueY�. ��� $ 	CheckMark�� � y�$ Visible=�P� 
 �@d�	IsChecked$ FalseY�. ��� $ 	CheckMark�� � y�$ Hidden=�P� 
 � {� .  . ���  �@J�Opacity$	 0.5Q��� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ Yu Gothic UI)���  � ��$ 20(���  � ��$
 Bold"���  � ��
 �� ����  � ��
 ������� "  .���  � ��
 �������  � ��
 ��  ���  � ��$ Yu Gothic UI)���  � ��$ 20(���  � ��$
 Bold"���  � ��$ Center=���  � ��$ Center=���  �@�Cursor$
 Hand��( P� 
 �@ 
IsSelected . . ���  � �� �#EAD9FF��  � ��
 �   ��� "  .���  �@��TextAlignment$ Center=���  � ��
 �����( P� 
 �@ 
IsSelected . . ���  � �� �#EAD9FF��  � ��
 �   �.��� ���	#FFB9D1EA �� $��* � �� -   ) ��Name$) RightColumnDefinition��$	��630 �$
��1380���� $
��Auto ��� $��* �.+�� $��0�� �� $��* �.+��� -   * ��Name$* PuzzleCanvas��$��0��.+��� -   + ��Name$+ NewGameButton��, �� Left$, 20��
- �� Top$- 20��$	��180��$��40��$��新規開始��$
��Bold"�#��[  . J� Effect. 3  -System.Windows.Media.Effects.DropShadowEffect  -   ButtonShadowEffect1��/   
BlurRadius$/ 50Q�0   Opacity$0 0Q�1   ShadowDepth$1 0Q�2   Color$2 
Darkviolet��3 � Triggers3 :� 4 :� RoutedEvent$4 Button.Click��.[��� .���� .��W� 5 g� AutoReverse5 . 6 �� 
TargetName$6 ButtonShadowEffect1��7 �� TargetProperty$7 Opacity�8 W� From$8 0X�	9 W� To$	9 0.8X�: g� Duration$: 0:0:0.4D��� -   $+ 
RedoButton��$	, 220��$- 20��$	��180��$��40��$��元に戻す��$
��Bold"�#��[  .   -   ButtonShadowEffect2��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect2��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -   ; ��Name$; TimeTextBlock��$	, 452��$- 30��$��Center=�$	��Top=�$��18(�$
��Bold"�< J� RenderTransformOrigin$< 0.5,0.5&�$��０秒��$��NoWrap=��� -	   $+ BlinkingButton��$, 20��$- 80��$	��180��$��40��$��指定ピースを点滅��$
��Bold"�#��[  .   -
   ButtonShadowEffect3��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect3��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -   = ��Name$= PieceNumberComboBox��$	, 220��$- 80��$	��100��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 ������� -   $; CompletionRateTextBlock��$	, 340��$- 88��$��Center=�$	��Top=�$��20(�$
��Bold"�$��完成率：０％��$��NoWrap=��� -   > ��Name$> KeyDownCheckBox��$, 20��$	- 142��$��18(�#��[ .���� �� $��18(�$-�'矢印キーでピースを動かす。�� �� $��18(�$
��Bold"�
���  ��$K�E（他項目では、矢印・Ｆ１・ＢＫＳＰキーが無効）���� -   $��1��$��8��$��Stretch=�$��Stretch=�
���� ��� $��2�� �� $��* �.+��� -   ? ��Name$? SettingTabControl��$��10,20,20,20q�.@��� $	��100��$��設定��#��[ .��� ���	#FBC0C0FF �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $
��Auto � �� $	��150 ��� $��* ��� $��60 �.+��� -   $; SettingTextBlock��$��0��$��0��$��2��$��20,0,0,0q�$��Center=�
���   �$K��E※設定は、新規開始ボタン押下時に反映されます。���� -   $ + SettingTextBlockStopButton��$��0��$��2��$��50��$��40��$��停止��#��[  .   -   ButtonShadowEffect4��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect4��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $��1��$��0��$��20,0,0,0q�$��Center=�$��パズル画像���� -   $ ImagePathTextBox��$��1��$��1��$��36��$��Center=�
�������
����+��$��2q�@ �� 
CaretBrush
@ ��  �$��20(�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� -   $+ ImageSelectButton��$��1��$��2��$��50��$��40��$��選択��#��[  .   -   ButtonShadowEffect5��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect5��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $��2��$��0��$��20,0,0,0q�$��Center=�$��ピース数���� $��2��$��1��$��Center=�$& 
Horizontal=�.+��� -   $= PieceCountComboBox��$	��100��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $��３×３���� $��４×４���� $��５×５���� $��６×６���� $��７×７���� $��８×８���� $��	30,0,10,0q�$��Center=�$��ピース移動速度���� -   $= PieceSpeedComboBox��$	��100��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $	��１���� $	��２���� $	��３���� $	��４���� $	��５���� $	��６���� $	��７���� $	��８���� $	��９���� $��１０���� $��0,0,0,0q�$��Center=�$��（１：最速）���� $��3��$��0��$��20,0,0,0q�$��Center=�$��文字サイズ���� $��3��$��1��$��Center=�$& 
Horizontal=�.+��� -   $= FontSizeComboBox��$	��100��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $��１０���� $��１１���� $��１２���� $��１３���� $��１４���� $��１５���� $��１６���� $��１７���� $��１８���� $��１９���� $��２０���� $��２１���� $��２２���� $��２３���� $��２４���� $��２５���� $��２６���� $��２７���� $��２８���� $��２９���� $��３０���� $��	30,0,10,0q�$��Center=�$��ピースサイズ���� -   $= PieceSizeComboBox��$	��180��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $��５０×５０���� $��６０×６０���� $��７０×７０���� $��８０×８０���� $��９０×９０���� $��１００×１００���� $��4��$��0��$��20,0,0,0q�$��Center=�$��	文字色���� $��4��$��1��$& 
Horizontal=�.+��� -   $+ FontColorSettingButton��$	��130��$��40��$
��Left=�$��Center=�$��文字色設定��#��[  .   -   ButtonShadowEffect6��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect6��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -   $; FontColorSampleTextBlock��$��10,0,0,0q�$��Center=�$
��Bold"�
����  �$��文字色サンプル���� $��5��$��0��$��20,0,0,0q�$��Center=�$��線色���� $��5��$��1��$& 
Horizontal=�.+��� -   $+ LineColorSettingButton��$	��130��$��40��$
��Left=�$��線色設定��#��[  .   -   ButtonShadowEffect7��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect7��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -   $; LineColorSampleTextBlock��$��10,0,0,0q�$��Center=�$
��Bold"�$��線色サンプル���� $��6��$��0��$��20,0,0,0q�$��Center=�$��	背景色���� $��6��$��1��$& 
Horizontal=�.+��� -    $+ BackColorSettingButton��$	��130��$��40��$
��Left=�$��背景色設定��#��[  .   -!   ButtonShadowEffect8��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect8��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -"   $; BackgroundSampleTextBlock��$��10,0,0,0q�$��Center=�$
��Bold"�
�������$��背景色サンプル���� $��7��$��0��$��20,0,0,0q�$��Center=�$��ピース移動音���� -#   $ PieceMoveSoundPathTextBox��$��7��$��1��$��36��$��Center=�
�������
����+��$��2q�
@ ��  �$��20(�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� -$   $ + PieceMoveSoundSelectButton��$��7��$��2��$��50��$��40��$��5,5,5,0q�$	��Top=�$��選択��#��[  .   -%   ButtonShadowEffect9��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect9��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $��8��$��0��$��20,0,0,0q�$��Center=�$��クリア音���� -&   $ ClearSoundPathTextBox��$��8��$��1��$��36��$��Center=�
�������
����+��$��2q�
@ ��  �$��20(�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� -'   $+ ClearSoundSelectButton��$��8��$��2��$��50��$��40��$��選択��#��[  .   -(   ButtonShadowEffect10��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect10��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $��9��$��0��$��20,0,0,0q�$��Center=�$��番号表示���� -)   $> NumberShowCheckBox��$��9��$��1��$
��Left=�$��Center=�$!��ピースに番号を表示��$
 TrueY�#��[ �� $��10��$��0��$��20,0,0,0q�$��Center=�$��新規開始時���� -*   $= SelectTabItemComboBox��$��10��$��1��$	��380��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $��タブを変更しない���� $'��!操作履歴タブを表示する���� $9��3パズル画像（完成図）タブを表示する���� $��11��$��1��$& 
Horizontal=�.+��� -+   $+ SettingSaveButton��$	��180��$��40��$��設定を保存��#��[  .   -,   ButtonShadowEffect11��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect11��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� --   $+ SettingReadButton��$	��180��$��40��$��20,0,0,0q�$��設定を読み込み��#��[  .   -.   ButtonShadowEffect12��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect12��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $	��180��$��ピース配置設定��#��[ .��� ���	#FBC0C0FF �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $��60 �.+�� $��0��$��0�� �� $��50 � �� $	��100 ��� $��* �.+��� $��0��$��0��$��20,0,0,0q�$��Center=�$��ピース数���� -/   $&=  PiecePlacementPieceCountComboBox��$��0��$��1��$	��100��$��40��$
��Left=�$��Center=� ��%/   '��       �� " ��.���  � ��
 �����@��� $��３×３���� $��４×４���� $��５×５���� $��６×６���� $��７×７���� $��８×８��� $��1��$��0��$��20,0,0,0q� �� $��50 ��� $��50 ��� $��50 � �� $
��Auto ��� $��* �.+��� $��0��$��0��$��Center=�$��ピース番号���� -0   $+ PiecePlacementInitButton��$��1��$��0��$	��230��$��40��$
��Left=�$!��ピース配置を初期化��#��[  .   -1   ButtonShadowEffect13��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect13��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -2   $+ PiecePlacementSaveButton��$��1��$��1��$	��230��$��40��$��0,0,20,0q�$��Right=�$��ピース配置を保存��#��[  .   -3   ButtonShadowEffect14��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect14��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -4   $!+ SlidePuzzleReflectionButton��$��2��$��0��$	��230��$��40��$
��Left=�$$��スライドパズルに反映��#��[  .   -5   ButtonShadowEffect15��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect15��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -6   $+ PiecePlacementReadButton��$��2��$��1��$	��230��$��40��$��0,0,20,0q�$��Right=�$$��ピース配置を読み込み��#��[  .   -7   ButtonShadowEffect16��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect16��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -8   $; PiecePlacementTextBlock��$��2��$��0��$��	20,10,0,0q�$��Center=�$��22(�$
��Bold"�$��◆ピース配置��&   System.Windows.Controls.DataGrid  -9   A  Name$#A PiecePlacementSettingDataGrid��$��3��$��0��$��20,4,0,0q�B   AutoGenerateColumnsB .  ���	#FFB9D1EA$��2q�C   CanUserAddRowsC .  D   CanUserDeleteRowsD .  E   CanUserReorderColumnsE .  F   CanUserResizeColumnsF . G   CanUserResizeRowsG . H   CanUserSortColumnsH .  I   	CellStyle#I [ J   GridLinesVisibility$	J All=�K   HeadersVisibility$K Column=�$L   HorizontalScrollBarVisibility$L Visible=�M   
IsReadOnlyM .  N   SelectionUnit$
N Cell=�O   VerticalGridLinesBrush
O �� ��"P   VerticalScrollBarVisibility$P Visible=�Q   ColumnsQ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumnR   Width5  /System.Windows.Controls.DataGridLengthConverter$	R 100 S   Header$S 列１��1	  +System.Windows.Controls.DataGridBoundColumnT 	  BindingT �� *	Column0+U 	  ElementStyleU �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V 	  EditingElementStyleV �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����  $	R 100 $S 列２��T �� *	Column1+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����  $	R 100 $S 列３��T �� *	Column2+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W   	CellStyleW �� X �� BasedOn#X [ "  ( �� Y �� BindingY �� *Value+Z �� ValueZ 3.a���  � ��
 �������  �@�Cursor$ No��  $	R 100 $S 列４��T �� *	Column3+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W �� #X [ "  ( �� Y �� *Value+Z 4.a���  � ��
 �������  �@�Cursor$ No��  $	R 100 $S 列５��T �� *	Column4+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W �� #X [ "  ( �� Y �� *Value+Z 5.a���  � ��
 �������  �@�Cursor$ No��  $	R 100 $S 列６��T �� *	Column5+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W �� #X [ "  ( �� Y �� *Value+Z 6.a���  � ��
 �������  �@�Cursor$ No��  $	R 100 $S 列７��T �� *	Column6+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W �� #X [ "  ( �� Y �� *Value+Z 7.a���  � ��
 �������  �@�Cursor$ No��  $	R 100 $S 列８��T �� *	Column7+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��V �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �����W �� #X [ "  ( �� Y �� *Value+Z 8.a���  � ��
 �������  �@�Cursor$ No���� -:   $); #PiecePlacementSettingErrorTextBlock��$��4��$��0��$��	20,4,0,20q�$
��Left=�$��Stretch=�$
��Bold"�
���  ��$N��H※設定は、シャッフルボタン押下時に反映されます。��$y�	Collapsed=��� $	��130��$��操作履歴��#��[ .��� ���	#FBC0C0FF �� $��60 ��� $��40 ��� $��40 ��� $��* �$	��100���� $��50 ��� $	��230 �.+��� -;   $$+ OperationHistoryInitSaveButton��$��0��$��0��$	��280��$��40��$��	20,20,0,0q�$
��Left=�$*��$操作履歴・初期配置を保存��#��[  .   -<   ButtonShadowEffect17��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect17��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� $��1��$��0��$��	20,10,0,0q�$l��f保存した初期配置は、【ピース配置を読み込み】ボタンにて読み込めます。��� $��2��$��0�� �� $
��Auto ��� $��* �.+��� -=   $; OperationHistoryTextBlock��$��0��$��0��$��	20,10,0,0q�$��22(�$
��Bold"�$��◆操作履歴���� ->   $"> OperationHistoryEditCheckBox��$��0��$��1��$��	0,10,20,0q�$��Right=�$��Center=�$!��操作履歴を編集する��#��[ ]� $��3��$��0��.+��� -?   $ OperationHistoryTextBox��$��
20,0,20,10q�[ �� AcceptsReturn[ . 
�������
����+��$��2q�
@ ��  �$\ �� HorizontalScrollBarVisibility$\ Visible=� . ] �� TextWrapping$] NoWrap=�"^ �� VerticalScrollBarVisibility$^ Visible=��� $��4��$��0��$��20,0,0,4q�$��Bottom=�$��22(�$
��Bold"�$��◆初期配置���� -@   $%+ InitSlidePuzzleReflectionButton��$��4��$��0��$	��200��$��40��$��	0,0,240,0q�$��Right=�$$��スライドパズルに反映��#��[  .   -A   ButtonShadowEffect18��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect18��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D��� -B   $$+ PiecePlacementReflectionButton��$��4��$��0��$	��200��$��40��$��0,0,20,0q�$��Right=�$��ピース配置に反映��#��[  .   -C   ButtonShadowEffect19��$/ 50Q�$0 0Q�$1 0Q�$2 
Darkviolet��3 :� $4 Button.Click��.[��� .���� .��W� 5 . $6 ButtonShadowEffect19��$7 Opacity�$8 0X�$	9 0.8X�$: 0:0:0.4D�  -D   $A InitDataGrid��$��5��$��0��$��
20,0,20,20q�B .  ���	#FFB9D1EA$��2q�C .  D .  E .  F . G . H .  #I [ $	J All=�$K Column=�$L Visible=�M . $
N Cell=�
O �� ��$P Visible=�Q   $	R 100 $S 列１��T �� *	Column0+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列２��T �� *	Column1+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列３��T �� *	Column2+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列４��T �� *	Column3+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列５��T �� *	Column4+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列６��T �� *	Column5+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列７��T �� *	Column6+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30��  $	R 100 $S 列８��T �� *	Column7+U �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 30���� $	��240��$$��パズル画像（完成図）��#��[ .���� ���	#FBC0C0FF$
��Auto=�$
��Auto=�.���� -E   _ ��Name$_ PuzzleImage��$��20,20,20,20q�