   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5   	   *    $MilkStoreManagement.View.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   2local&clr-namespace:MilkStoreManagement.View  5   	   -   5          �Name$  LoginWd��5   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������    LoginVM � DataContext# [  5   	    � Title$ LoginWindow��5   	   $	��800��6   $
��1440��6*   .��5      �� 
�������*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ MouseLeftButtonDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6(   �� *	MoveLogin+
   CommandParameter
 5   4   ��  �� ElementName$ LoginWd��6g   5      ._�5   
   � .+�5      � $��Center=�6   $��Center=�6.   .+�5      � $	��450��6   $	��350��6$    � RowDefinitions 5      �� 5      $	��180 �6(   67   �� 5      6*   .+�5!      � $��0��6   .+�5"      �� $��Center=�6%   $	��Top=�6B   $��0,15,0,0q�6Z   .+�5#      ��  �� TextAlignment$
 Left=�6(   $��30(�6=    
 Custom#��[ 6K   ���#FFCA08$
��Bold"�6�   $	��350��6�   CHÀO MỪNG6�   �� 5$      $ Right=�6(   $��30(�6>   #��[ 6M   ���#FFCA08$
��Bold"�6�   $	��350��6�   ĐẾN VỚI MILKSTORE6�   5%      5&      � 5'      $��1��6   .+�5(      �� .+�5)      �� -   5         ��Name$ dangnhap��5)   &     MaterialDesignFilledTextBox#��[ 5+      
�������$��46.72��5-      $	��350��5.      $��12(�5/      $
��Bold"�50      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground �#FFCA08.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#FFCA08$	��Top=�53       �� AcceptsReturn . $��0,0,0,10q�55      #��[ 56         Hint$ TÊN ĐĂNG NHẬP��57      ��5*      �� *
Username+57      G� 5:      -   5         G�Name$ password��5:   *    # MaterialDesignFilledPasswordBox#��[ 5;      $	��Top=�5<      
�������$��0,0,0,40q�5>      $��46.72��5?      $	��350��5@      $��12(�5A      $
��Bold"�5B      #��[ 5C       �#FFCA08 �#FFCA08$ MẬT KHẨU��5F       5G   "     5H   &   $ PasswordChanged��65   . 5I   *     	 6@   �� *PasswordChangedCommand+
 5J   $   �� $ password��6X   5K   '   5M      �� 5N      $��ĐĂNG NHẬP��6%    �� 	IsDefault . $��47��5P      $	��350��5Q      #��[ 5R      ���#FFCA08
���   �
������ ��5V   "   �� 5W   &    �� 
TargetType" ��66   .R�5X   *   �� #��z��61   #��z��5Y   !   #��z��5Z   !    �� CornerRadius$ 24��5[   !   ._�5\   .   �� $��Center=�6?   $��Center=�6\   5]   +   5^   '    5`   "     5a   &   $ Click��65   . 5b   *     	 6@   �� *Login+
 5c      �� $ LoginWd��5d   '   5f      �� 5g      $��1��6%   $��1��62   ���#FFCA08$��0,25,0,0q�6R   � 5h      $��Center=�6#   $��Center=�6>   $	��250��6[   .+�5i   "   �� $��QUÊN MẬT KHẨU ?��5j      $��0,15,0,0q�5k      $��Center=�5l      #��[ 5m      
������  5p        5q      $ MouseLeftButtonDown��6!   . 5r        	 6,   �� *ForgetPassCommand+
 5s   #   �� $ LoginWd��6V   5t      ��5v   &   �� 5w   *    �� 
TargetType" ��60   .�5x   .   ��  �� Property � �� �� Value
 �   �6K    �� Triggers 5y   .   P� 5z   2    P� Property �@J�IsMouseOver P� Value . . �5{   6   ��  � �� �#FFCA086S   �� 5|   6    � ��$ 	Underline{�6X   5}   3   5   +   5�   #   5�      5�      5�      5�      5�      �� 5�      $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6*   
���   �$��24��6S   $��24��6_   $��0,0,8,0q�6j    5�        5�      $ MouseLeftButtonDown��6)   . 5�        	 64   �� *MinimizeLogin+
 5�      �� $ LoginWd��6?   5�      5�        5�      $ 
CloseThick=�6*   
���   �$��24��6O   $��24��6[    5�        5�      $ MouseLeftButtonDown��6)   . 5�        	 64   �� *
CloseLogin+
 5�      �� $ LoginWd��6?   5�      5�      5�      5�      5�      5�      