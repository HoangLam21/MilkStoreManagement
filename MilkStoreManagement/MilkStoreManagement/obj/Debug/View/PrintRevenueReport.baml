   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      g cSyncfusion.SfSkinManager.WPF, Version=23.2460.5.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89iLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPFSyncfusion.SfSkinManager 5      1    +MilkStoreManagement.View.PrintRevenueReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MilkStoreManagement.View     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      asyncfusionskinLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF  5      a	 ]Syncfusion.SfChart.WPF, Version=23.2460.5.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c894
syncfusion!http://schemas.syncfusion.com/wpf  	 5      -   5          N�Name$  	Revenuewd��5       N� 
Background
 ����    	RevenueVM � DataContext# [  5       N� Title$ PrintRevenueReport��5      .��5      �� -   5        $��RevenueViewReport��5       �� Orientation$ Vertical=�6*   $��30q�6A   
�������.+�5   
   �� $��BÁO CÁO DOANH THU��6   $��
20 50 20 0q�6-   $��20(�6A   $��center=�6O    
 Custom#��[ 6l   �� 5   
   $��	MilkStore��6   $��
20 10 20 0q�6%   $��16(�69   $��center=�6G   #��[ 6d   �� 5   
   $��1. Thông tin chung:��6   $
��40 0q�6/   $��16(�6=   #��[ 6K   �� 5   
   -   5        $
��NGIn��5      $��Ngay in:��6    $
��70 1q�60   $��16(�6>   �� 5   
   -   5        $��	NGThongKe��5      $��Thoi gian thong ke:��6%   $
��70 1q�6@   $��16(�6N   �� 5   
   $*��$2. Chỉ số thu chi tổng quát: ��6   $
��40 0q�69   $��16(�6G   #��[ 6U   �� 5   
   -   5        $��TongThu��5      $��	Tong Thu:��6#   $
��70 1q�64   $��16(�6B   �� 5   
   -   5        $��TongChi��5      $��	Tong Chi:��6#   $
��70 1q�64   $��16(�6B   �� 5   
   -   5        $��DoanhThu��5      $��	DoanhThu:��6$   $
��70 1q�65   $��16(�6C   �� 5   
   $��3. Chi tiết thu:��6   $
��40 0q�6,   $��16(�6:   #��[ 6H   �� 5    
   ._�5!      �� -   5         ��Name$ listThu��5!   e   $
��auto��6   $��2q�6%   ���#FFCA08���#383838$��11(�6v   $��lexend)�6�   
�������$	��700��6�   $��Disabled=�5"   '   $��Hidden=�6]    �� View 5#      �� 5$      .P�5'      ��  �� Width$	 100��6P    �� DisplayMemberBinding 6*   �� *masp+.��5(      �� $��Mã sản phẩm��63   $	��100��6I   $��Center=�6V   $��Center=�6q   $��12(�6�   $	��0 4q�6�   5)      �� 5*      $	 140��6P    6)   �� *tensp+.��5+      �� $��Tên sản phẩm��63   $	��140��6J   $��Center=�6W   $��Center=�6r   $��12(�6�   $	��0 4q�6�   5,      �� 5-      $	 100��6S    6*   �� *	soluong+.��5.      �� $��Số lượng��63   $	��100��6F   $��Center=�6S   $��Center=�6n   $��12(�6�   $	��0 4q�6�   5/      �� 50      $	 150��6Q    6)   �� *giaban+.��51      �� $��	Giá bán��63   $	��150��6E   $��Center=�6R   $��Center=�6m   $��12(�6�   $	��0 4q�6�   52      �� 53      $	 170��6S    6*   �� *	tongthu+.��54      �� $��
Tổng thu��63   $	��170��6F   $��Center=�6S   $��Center=�6n   $��12(�6�   $	��0 4q�6�   55      56      58      5:      �� 5;   
   $��4. Chi tiết chi��6   $
��40 0q�6+   $��16(�69   #��[ 6G   �� 5<   
   ._�5=      �� -	   5        $ listChi��5=   %   $
��auto��6   $��2q�66   ���#FFCA08���#383838$��11(�6u   $��lexend)�6�   $	��700��6�   $��Disabled=�5>   '   $��Hidden=�6]    5?      �� 5@      .P�5B      �� $	 100��6P    6*   �� *masp+.��5C      �� $��Mã sản phẩm��63   $��80��6I   $��Center=�6U   $��Center=�6p   $��12(�6�   $	��0 4q�6�   5D      �� 5E      $	 140��6P    6)   �� *tensp+.��5F      �� $��Tên sản phẩm��63   $��80��6J   $��Center=�6V   $��Center=�6q   $��12(�6�   $	��0 4q�6�   5G      �� 5H      $	 100��6S    6*   �� *	soluong+.��5I      �� $��Số lượng nhập��63   $��90��6K   $��Center=�6W   $��Center=�6r   $��12(�6�   $	��0 4q�6�   5J      �� 5K      $	 150��6S    6*   �� *	gianhap+.��5L      �� $��Giá nhập��63   $��80��6F   $��Center=�6Q   $��Center=�6o   $��Center=�6�   $��12(�6�   $	��0 4q�6�   5M      �� 5N      $	 170��6P    6*   �� *tong+.��5O      �� $��Tổng tiền��63   $��80��6G   $��Center=�6S   $��Center=�6n   $��12(�6�   $	��0 4q�6�   5P      5Q      5S      5V      �� 5W   
   $ 
Horizontal=�6   $��60 30q�6.   .+�5X      �� $ Vertical=�6   $	��434��60   .+�5Y      �� $"��Nhân viên xuất báo cáo��6   $��	40 0 40 0q�6;   $��16(�6N   #��[ 6\   �� 5Z      $��(Ký, ghi rõ họ tên)��6   $��21��67   $	��298��6C   5\      �� 5]      $ Vertical=�6   $	��234��60   .+�5^      �� $��Quản lý xác nhận��6   $��Center=�64   $��	40 0 40 0q�6Q   $��16(�6d   #��[ 6r   �� 5_      $��(Ký, ghi rõ họ tên)��6   $��19��67   $��97��6C   $��Center=�6N   5`      5b      5d      5e      