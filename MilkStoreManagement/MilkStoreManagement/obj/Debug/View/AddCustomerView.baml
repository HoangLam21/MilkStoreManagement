   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5      .    (MilkStoreManagement.View.AddCustomerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MilkStoreManagement.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          �Name$  AddCswd��5       � WindowStyle$
 None=�5
       � 
ResizeMode$ NoResize=�5      
������  � AllowsTransparency .    AddCsVM � DataContext# [  5      $	��600��5      $	��450��5       � WindowStartupLocation$ CenterScreen=�6   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *Loadwd+
   CommandParameter
 5      ��  �� ElementName$ AddCswd��6J   5      .��5      �� 
������� �� CornerRadius$ 20��5      ���#ffca08$��2q�5       5$   
     5%      $ MouseLeftButtonDown��6   . 5&        	 6(   �� *
MoveWindow+
 5'   %   �� $ AddCswd��6X   5(      ._�5*   
   �  � ColumnDefinitions 5+      �� 5,      $	��440 �6#   .+�5/      � $��1��6    � RowDefinitions 50      �� 51      $��30 �6$   �� 53      .+�57      � $��0��6   
������ $��	0,0,0,574q�6=   $��2��6P   .+�58      ��  �� Orientation$ 
Horizontal=�59      $��Right=�5:      $��Center=�5;      $��0,0,10,0q�5<      .+�5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   
���   �$��24��6[   $��24��6g   $��0,0,8,0q�6r    5?        5@   "   $ MouseLeftButtonDown��61   . 5A   &     	 6<   �� *
Minimizewd+
 5B   5   �� $ AddCswd��6h   5C   #   5E        5F      $ 
CloseThick=�62   
���   �$��24��6W   $��24��6c    5G        5H   "   $ MouseLeftButtonDown��61   . 5I   &     	 6<   �� *	Closewd+
 5J   5   �� $ AddCswd��6h   5K   #   5M      5N      5P      � 5Q      $��1��6   .+�5R      �� $ Vertical=�6!   $��
0,20,10,10q�5S   !   .+�5U      �� $��
-15,0,0,20q�5V      $��Center=�5W      $#��Thêm thông tin khách hàng��5X      $��24(�5Y      
���   � 
 Custom#��[ 5[      �� 5]      $ 
Horizontal=�6%   $��0,40,0,0q�6>   .+�5^      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5`   "   �� -   5         ��Name$
 MAKH��5h   =   $��10,0,0,0q�5a   "   $	��160��65    % !MaterialDesignFloatingHintTextBox#��[ 5b   "   )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#ffca08$	��Top=�5e   "    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5g   "   $
��Left=�5h   "   #��[ 5i   "      Hint$ Mã khách hàng��5j   "   5l      �� 5m      $ Vertical=�6)   $��40,0,0,0q�5n   )   .+�5p   "   �� -   5        $ TenKH��5x   >   $��10,0,0,0q�5q   #   $	��160��66   #��[ 5r   #   
 �   � �#ffca08$	��Top=�5u   #    . $
 Wrap=�5w   #   $
��Left=�5x   #   #��[ 5y   #   $ Tên khách hàng��5z   #   5{      5|      �� 5}      $ 
Horizontal=�6%   $��0,50,0,0q�5~   %   .+�5�      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5�   "   �� -   5        $ NGSINH��5�   =   $��10,0,0,0q�5�   "   $	��160��65   #��[ 5�   "   
 �   � �#ffca08$	��Top=�5�   "    . $
 Wrap=�5�   "   $
��Left=�5�   "   #��[ 5�   "   $ Ngày sinh ��5�   "   5�      �� 5�      $ Vertical=�6)   $��40,0,0,0q�5�   )   .+�5�   "   �� -   5        $	 SDT��5�   =   $��10,0,0,0q�5�   "   $	��160��65   #��[ 5�   "   
 �   � �#ffca08$	��Top=�5�   "    . $
 Wrap=�5�   "   $
��Left=�5�   "   #��[ 5�   "   $	 SDT��5�   "   5�      5�      �� 5�      $ 
Horizontal=�6%   $��0,50,0,0q�6>   .+�5�      �� $ Vertical=�6)   $��30,0,0,0q�6@   .+�5�   "   �� -   5        $ DOANHSO��5�   =   $��10,0,0,0q�5�   "   $	��160��65   #��[ 5�   "   
 �   � �#ffca08$	��Top=�5�   "    . $
 Wrap=�5�   "    �� 
IsReadOnly . $
��Left=�5�   "   #��[ 5�   "   $ 
Doanh số��5�   "   5�      �� 5�      $ Vertical=�6)   $��40,0,0,0q�5�   )   .+�5�   "   �� -   5        $ GHICHU��5�   =   $��10,0,0,0q�5�   "   $	��160��65   #��[ 5�   "   
 �   � �#ffca08$	��Top=�5�   "    .  . $
 Wrap=�5�   "   $
��Left=�5�   "   #��[ 5�   "   $ Ghi chú��5�   "   5�      5�      �� 5�      -   5         ��Name$ 	btnupdate��5�   !   $��Thêm khách hàng��5�   !   $��0,50,0,0q�5�   !   $	��200��5�   !   $��50��6-   $��0q�5�   !   $��17(�5�   !   $��Center=�5�   !   ���#FFCA08 5�        5�   "   $ Click��61   . 5�   &     	 6<   �� *AddCsCommand+
 5�   8   �� $ AddCswd��6k   5�   #   5�      5�      5�      5�      5�      5�      5�      