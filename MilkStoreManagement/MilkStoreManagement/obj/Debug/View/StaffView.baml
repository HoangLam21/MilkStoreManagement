   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      (    "MilkStoreManagement.View.StaffView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8local&clr-namespace:MilkStoreManagement.View     5      6sys&clr-namespace:System;assembly=mscorlib     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5          N�Name$  QLNVwd��5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        StaffVM � DataContext# [ 5      $	��800��5      $
��1170��6    � 	Resources 5        	BoolToVis��%   &	       �� 5   
   6'   5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6%   �� *LoadCsCommand+
   CommandParameter
 5      ��  �� ElementName$ QLNVwd��6N   5      .��5      �� $��15,100,15,15q�5       ���#ffffff �� CornerRadius$ 40��5"       J� Effect 5#   
   3  -System.Windows.Media.Effects.DropShadowEffect  5$         	Direction$	 320Q�6      ShadowDepth$ 5Q�6/      
BlurRadius$ 10Q�6?      Color$ #FFCA08��6O      Opacity$
 0.25Q�6_   ._�5&   
   �  � RowDefinitions 5'      �� 5(      $��64 �6    �� 5)      $��80 �6    �� 5*      $��* �6    .+�5,      � $��1��6   .+�5-      ��  �� Orientation$ 
Horizontal=�6   $��46 0 0 0q�66   .+�5.      �� $��8,0,0,0q�5/      $��40��50      $	��120��51      $ 10��52      ._�53      �� -   5         ��Name$ cbxChon��54       & "MaterialDesignFloatingHintComboBox#��[ 55      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm Kiếm��56      $��0q�57         
Foreground �#ffca08$��40��5:      $��14(�5;      $	��110��5=      ��5<      �� *listTK+��5?      �� 5@   "   .R�5A   &   �� $ 
Horizontal=�61   .+�5B   *   �� ��64   �� 5C   '   5D   #   5F      5G      �� 5H      $ 20��6   
�������$��54��6B   $	��262��6N    5I        5J      $ #ffca08��6/   $	 270Q�6?   $ 5Q�6O   $
 0.15Q�6_   ._�5L      �� -   5         ��Name$ 	txbSearch��5M      $	��232��5N      $��40��5O      
�������
����������#383838$��16(�5S      $��SemiBold"�5T      $��Center=�5U      .��6%    5V        5W   "   $ TextChanged��61   . 5X   &     	 6<   �� *SearchCommand+
 5Y      �� $ QLNVwd��6I   5Z   #   .��5[   6   5\      5]      �� 5^      $��40��6   $��40��6)   ._�5_      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�62   $��30��6A   $��30��6M   $��Center=�6X   $��Center=�6u   ���#ffca086�   5`      5a      5b      �� 5c      $��0��6   ._�5d      �� $��Nhân viên��6   $��24(�6,   ���#747474$
��Bold"�6O    
 Custom#��[ 6b   $��41 10q�6�   5f      �� 5g      $��3��6   $
��1079��6#   ���#fff2c1$��Center=�6E   $��0 61 0 0q�6b   �� 5h      $��3��6   $
��1079��6#   ���#fff2c1$��Center=�6E   $��0 143 0 -82q�6b   �� 5i        	addButton#��[ 6   $��Center=�68   $��500 18 0 18q�6S   .��5j      �� $ 
Horizontal=�6   .+�5l      �� $��Thêm nhân viên��6    $��16(�66   $��Center=�6D   $��Regular"�6_   $��Lexend)�6t   5n       5o        5p      $ Click��6%   . 5q        	 60   �� *AddNVCommand+
 5r      �� $ QLNVwd��6M   5s      5u      � 5w      $��2��6   $
��46,0q�6    .+�5x      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ 
DatagridNV��5x      $��	0 10 0 70q�6/    	  AutoGenerateColumns .  ��6^   �� *	ListNV1+ 	  Columns 5z      0
  *System.Windows.Controls.DataGridTextColumn
  5|      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6-      
IsReadOnly .    Header$ Mã nhân viên��5       0 ,MaterialDesignDataGridTextColumnEditingStyle1  +System.Windows.Controls.DataGridBoundColumn    EditingElementStyle#  [ 5�      !   Binding! 5~      �� *MANV+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Ảnh��61    . $ 75 6P   "   CellTemplate" 5�      �� 5�   "   .R�5�   &   �� $��45��6-   $��45��69   ._�5�   *   A� $��Center=�62   $��Center=�6M   $��40��6j   $��40��6u   $��1��6�   ��5�   .   �� 5�   2   AVA��# �� ImageSource# 6J   �� *AVA+$ �� StringFormat$$  ��5�   +   5�   '   5�   #   5�      
  5�      $	 200 6-    . $ Tên nhân viên��5�      #  [ 5�      ! 5�      �� *TENNV+5�      
  5�      $	 120 6-    . $ Giới tính��5�      #  [ 5�      ! 5�      �� *GIOI+5�      
  5�      $	 200 6-    . $ 
Ngày sinh��5�      #  [ 5�      ! 5�      �� *NGSINH+5�      
  5�      $	 150 6-    . $ Số điện thoại��5�      #  [ 5�      ! 5�      �� *SDT+5�      
  5�       . $ Chức Vụ��5�      #  [ 5�      ! 5�      �� *CHUCVU+5�       5�        5�      $ SelectionChanged��6)   . 5�        	 64   �� *Detail+
 5�      �� $ QLNVwd��6Q   5�      5�      5�      5�      5�      5�      