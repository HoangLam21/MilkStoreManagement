   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5   	   -    'MilkStoreManagement.View.ChangePassword   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MilkStoreManagement.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   -   5          �Name$  ChangePasswd��5   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .    ChangePassVM � DataContext# [  5   	    � Title$ ForgetPassView��5   	   $	��500��6    $	��500��6-   .��5      �� $��3q�6    �� CornerRadius$ 15��5      
����������#FFCA08*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5      	   	EventName$	 MouseLeftButtonDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6(   �� *MoveWd+   CommandParameter 5   (   ��  �� ElementName$ ChangePasswd��6`   5      ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      $	��300 �6    �� 5       .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��Right=�5#      $��Center=�5$      $��0,0,10,0q�5%      .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6*   
���   �$��24��6S   $��24��6_   $��0,0,8,0q�6j    5'        5(      $	 MouseLeftButtonDown��6)   .
 5)         64   �� *
MinimizeWd+ 5*   8   �� $ ChangePasswd��6p   5+      5-        5.      $ 
CloseThick=�6*   
���   �$��24��6O   $��24��6[    5/        50      $	 MouseLeftButtonDown��6)   .
 51         64   �� *	Closewd+ 52   8   �� $ ChangePasswd��6p   53      55      56      � 57      $��1��6   .+�58      �� .+�59      �� $��32(�6!   ���#FFCA08$��	0,-8,0,10q�5:       $��Center=�63    
 Custom#��[ 5;       $��Đổi mật khẩu��6E   5<      �� 5=      $ 10��6   $��78��6/   $	��380��6;   
������� J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         ShadowDepth$ 5Q�6/      Color$ #FFCA08��6@      Opacity$	 0.5Q�6P      
BlurRadius$ 10Q�6^   ._�5A      G� -   5         G�Name$ OldPass��5A   &    # MaterialDesignFilledPasswordBox#��[ 5B   !   $��Center=�5C   !   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#FFCA08)  #MaterialDesignThemes.Wpf.HintAssist   
Foreground �#FFCA08$��50��5F   !   $	��330��6-   $��15(�5G   !   
�������$
��Bold"�5I   !   #��[ 5J   !      Hint$ Nhập mật khẩu cũ��5K   !    5L        5M   "   $	 PasswordChanged��61   .
 5N   &      6<   �� *OldPassChangedCommand+ 5O   8   �� $ OldPass��6k   5P   #   5R      5S      �� 5T      $ 10��6   $	��150��6/   $��0,10,0,0q�6<   $	��380��6N   
������� 5U        5V      $ 5Q�6/   $ #FFCA08��6@   $	 0.5Q�6P   $ 10Q�6^   ._�5X      �� $��Center=�6%   .+�5Y      G� -   5        $ NewPass��5Y   *   #��[ 5Z   !    �#ffca08 �#ffca08$��0,0,0,15q�5]   !   $��50��5^   !   $	��330��6-   $��15(�69   
���   �
�������$
��Bold"�5a   !   #��[ 5b   !   $ Nhập mật khẩu mới��5c   !    5d   "     5e   &   $	 PasswordChanged��65   .
 5f   *      6@   �� *PasswordChangedCommand+ 5g   %   �� $ NewPass��5h   '   5j      G� 5k      -   5        $ 	PassAgain��5k   *   #��[ 5l   !   $��50��5m   !   $	��330��6-   $��15(�69    �#ffca08 �#ffca08
���   �
�������$
��Bold"�5r   !   #��[ 5s   !   $% Nhập lại mật khẩu mới��5t   !    5u   "     5v   &   $	 PasswordChanged��65   .
 5w   *      6@   �� *NewPassChangedCommand+ 5x   %   �� $ 	PassAgain��5y   '   5{      5|      5}      5      5�      � 5�      $��2��6   .+�5�      �� .+�5�      �� $��Center=�5�      $��Center=�68   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 5��5�      $	��300��5�      $��45��6)   $��0q�5�      
�������$��18(�5�   /   #��[ 5�      $��	0,30,0,10q�6B   ��5�      �� 5�       �� 
StartPoint$	 0,0&�62    �� EndPoint$ 1.5,0&�6C   .��5�   "   �  � Color$ #FFCA08��6/    � Offset$ 0Q�6?   � 5�   "   $ White��6/   $ 1Q�6=   5�       5�        5�      $ 3Q�6/   $ #ffca08��6?   $	 0.5Q�6O   $ 5Q�6]   .��5�   )   Lưu thay đổi 5�        5�      $	 Click��6-   .
 5�   "      68   �� *Save+ 5�   8   �� $ ChangePasswd��6p   5�      5�      �� 5�      $��Center=�5�      $��Center=�68   $ 5��5�      $	��300��5�      $��45��6)   $��0q�5�      
�������$��18(�5�   /   #��[ 5�      $��0,5,0,10q�6B   ��5�      �� 5�      $	 0,0&�62   $ 1.5,0&�6C   .��5�   "   � $ White��6/   $ 0Q�6=   � 5�   "   $ #ffca08��6/   $ 1Q�6?   5�       5�        5�      $ 3Q�6/   $ #ffca08��6?   $	 0.5Q�6O   $ 5Q�6]   .��5�   )   Thoát 5�        5�      $	 Click��6-   .
 5�   "      68   �� *	Closewd+ 5�   8   �� $ ChangePasswd��6p   5�      5�      5�      5�      5�      5�      5�      