   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5      +    %MilkStoreManagement.View.CustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MilkStoreManagement.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N�Name$
  Cswd��5         CsVM � DataContext# [  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCsCommand+   CommandParameter 5   4   ��  �� ElementName$
 Cswd��6d   5      .��5      �� 
������� �� CornerRadius$ 40��5      $��15,100,15,15q�6#   $
��0.75q�69   	 J� Effect	 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      
   	Direction$	
 320Q�6      ShadowDepth$ 5Q�6/      
BlurRadius$ 10Q�6?      Color$ #FFCA08��6O      Opacity$
 0.25Q�6_   ._�5   
   �  � RowDefinitions 5      �� 5      $��64 �6    �� 5      $��80 �6    �� 5      $��* �6    .+�5"      � $��0��6   $��2��6    .+�5#      �� $��0��6   ._�5$      �� $��Khách hàng��6   $��24(�61   ���#747474$
��Bold"�6T    
 Custom#��[ 6f   $��41 10q�6�   5&      �� 5'      $��3��6   $
��1050��6'   ���#fff2c1$
��Left=�6I   $��	50 61 0 0q�6d   �� 5(      $��3��6   $
��1050��6'   ���#fff2c1$
��Left=�6I   $��50 143 0 -82q�6d   5)      � 5*      $��1��6   $��2��6    $��25,0,0,0q�64   .+�5,      ��  �� Orientation$ 
Horizontal=�6   $��3��66   .+�5-      �� $��0,0,0,0q�5.      $��54��5/      $	��200��50      $ 10��51      
����������#FFCA08._�56      �� -   5         ��Name$ cbxChon��57       & "MaterialDesignFloatingHintComboBox#��[ 58      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm Kiếm��59      $��0q�5:         
Foreground �#ffca08$��40��5=      $��14(�5?      $	��110��5A      ��5@      �� *listTK+��5B      �� 5C   "   .R�5D   &   �� $ 
Horizontal=�61   .+�5E   *   �� ��64   �� 5F   '   5G   #   5I      5J      �� 5K      $ 20��6   
�������$��54��6B   $	��262��6N   	 5L        5M      $ #ffca08��6/   $	
 270Q�6?   $ 5Q�6O   $
 0.15Q�6_   ._�5O      �� -   5         ��Name$ 	txbSearch��5Q      $��Center=�5P      $	��232��5R      $��40��5S      
����������#383838$��14(�5V      $��SemiBold"�5W      $��Center=�5X       �� 
CaretBrush �#ffca08.��6N    5Z        5[   "   $ TextChanged��61   . 5\   &      6<   �� *SearchCommand+ 5]   4   �� $
 Cswd��6d   5^   #   .��5_   6   5`      5a      �� 5b        	addButton#��[ 6   $��20,0,0,0q�5c      $	��190��5d      $��54��5e      #��[ 5f      
������ ���#ffffff+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 6��5i      ���#FFCA08.��5m      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5n      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�66   $��-8,0,0,0q�6B   $��18��6T    J� RenderTransformOrigin$ 0.572,0.486&�6_   �� 5o      $��Thêm khách hàng ��6(   $��Center=�6@   $��Center=�6]   $��16(�6x   5p       5q        5r      $ Click��6-   . 5s   "      68   �� *AddCsCommand+ 5t   4   �� $
 Cswd��6d   5u      5w      5y      5z      � 5{      $��2��6   $��2��6    .+�5}      �� $��
50,0,50,50q�6   .+�5      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ 
DatagridNV��5      $��	0 10 0 70q�63    	  AutoGenerateColumns .  ��6b   �� *listKH+ 	  Columns 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 61      
IsReadOnly .    Header$ Mã khách hàng��5�       0 ,MaterialDesignDataGridTextColumnEditingStyle1  +System.Windows.Controls.DataGridBoundColumn   EditingElementStyle# [ 5�          Binding  5�      �� *MAKH+5�      
  5�      $	 230 61    . $ Tên khách hàng��5�      # [ 5�        5�      �� *TENKH+5�      
  5�      $	 180 61   $ Số điện thoại��5�      # [ 5�        5�      �� *SDT+5�      
  5�      $	 180 61    . $ 
Ngày sinh��5�      # [ 5�        5�      �� *NGSINH+5�      
  5�      $	 180 61    . $ 
Doanh số��5�      # [ 5�        5�      �� *	DOANHSO+5�      
  5�       . $ Ghi chú��5�      # [ 5�        5�      �� *GHICHU+5�       5�        5�      $ SelectionChanged��6-   . 5�   "      68   �� *Detail+ 5�      �� $
 Cswd��6C   5�      5�      5�      5�      5�      5�      5�      