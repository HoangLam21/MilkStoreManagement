   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5   	   1    +MilkStoreManagement.View.DetailCustomerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MilkStoreManagement.View     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  
DetailCswd��5   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency .    
DetailCsVM � DataContext# [  5   	   $	��600��5   	   
������ $	��450��5   	    � WindowStartupLocation$ CenterScreen=�6   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *	GetMAKH+
   CommandParameter
 5   '   ��  �� ElementName$ 
DetailCswd��6]   5      .��5      �� 
������� �� CornerRadius$ 20��5      ���#ffca08$��2q�5   	    5"   
     5#      $ MouseLeftButtonDown��6   . 5$        	 6(   �� *
MoveWindow+
 5%   '   �� $ 
DetailCswd��6]   5&      ._�5(   
   �  � ColumnDefinitions 5)      �� 5*      .+�5,      � $��0��6    � RowDefinitions 5-      �� 5.      $��30 �6$   �� 5/      .+�51      � $��0��6   
������ .+�52      ��  �� Orientation$ 
Horizontal=�53       $��Right=�54       $��Center=�55       $��0,0,10,0q�56       .+�58      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   
���   �$��24��6[   $��24��6g   $��0,0,8,0q�6r    59        5:   "   $ MouseLeftButtonDown��61   . 5;   &     	 6<   �� *
Minimizewd+
 5<   7   �� $ 
DetailCswd��6m   5=   #   5?        5@      $ 
CloseThick=�62   
���   �$��24��6W   $��24��6c    5A        5B   "   $ MouseLeftButtonDown��61   . 5C   &     	 6<   �� *	Closewd+
 5D   7   �� $ 
DetailCswd��6m   5E   #   5G      5H      5I      � 5J      $��1��6   .+�5K      �� $ Vertical=�6!   $��
0,20,10,10q�5L      .+�5N      �� $��
-15,20,0,0q�5O      $��Center=�5P      $��Thông tin khách hàng��5Q      $��24(�5R      ���#8B8989 
 Custom#��[ 5T      �� 5W      $ 
Horizontal=�6%   $��0,40,0,0q�6>   .+�5X      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5Z   "   �� -   5         ��Name$
 MAKH��5c   &   $��10,0,0,0q�5[      $	��160��6    % !MaterialDesignFloatingHintTextBox#��[ 5\      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#ffca08$	��Top=�5_       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5a       �� 
IsReadOnly . $
��Left=�5c      #��[ 5d         Hint$ Mã khách hàng��5e      5g      �� 5h      $ Vertical=�6)   $��40,0,0,0q�5i      .+�5k   "   �� -   5        $ TenKH��5s   '   $��10,0,0,0q�5l      $	��160��6   #��[ 5m      
 �   � �#ffca08$	��Top=�5p       . $
 Wrap=�5r      $
��Left=�5s      #��[ 5t      $ Tên khách hàng��5u      5v      5w      �� 5x      $ 
Horizontal=�6%   $��0,50,0,0q�5y      .+�5{      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5}   "   �� -   5        $ NGSINH��5�   &   $��10,0,0,0q�5~      $	��160��6   #��[ 5      
 �   � �#ffca08$	��Top=�5�       . $
 Wrap=�5�      $
��Left=�5�      #��[ 5�      $ Ngày sinh ��5�      5�      �� 5�      $ Vertical=�6)   $��40,0,0,0q�5�      .+�5�   "   �� -   5        $	 SDT��5�   &   $��10,0,0,0q�5�      $	��160��6   #��[ 5�      
 �   � �#ffca08$	��Top=�5�       . $
 Wrap=�5�      $
��Left=�5�      #��[ 5�      $	 SDT��5�      5�      5�      �� 5�      $ 
Horizontal=�6%   $��0,50,0,0q�6>   .+�5�      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5�   "   �� -   5        $ DOANHSO��5�   &   $��10,0,0,0q�5�      $	��160��6   #��[ 5�      
 �   � �#ffca08$	��Top=�5�       . $
 Wrap=�5�       . $
��Left=�5�      #��[ 5�      $ 
Doanh số��5�      5�      �� 5�      $ Vertical=�6)   $��40,0,0,0q�5�      .+�5�   "   �� -   5        $ GHICHU��5�   &   $��10,0,0,0q�5�      $	��160��6   #��[ 5�      
 �   � �#ffca08$	��Top=�5�       . $
 Wrap=�5�       .  $
��Left=�5�      #��[ 5�      $ Ghi chú��5�      5�      5�      �� 5�      -   5         ��Name$ 	btnupdate��5�      $��CẬP NHẬT��5�   !   $��0,70,0,0q�5�      $	��250��5�      $��50��6+   $��0q�5�      $��18(�5�      ���#FFCA08 5�        5�   "   $ Click��61   . 5�   &     	 6<   �� *Update+
 5�      �� $ 
DetailCswd��6T   5�   #   5�      5�      5�      5�      5�      5�      5�      