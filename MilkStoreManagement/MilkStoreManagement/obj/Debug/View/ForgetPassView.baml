   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5   	   -    'MilkStoreManagement.View.ForgetPassView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MilkStoreManagement.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   -   5          �Name$  	Forgetpwd��5   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .    ForgetPassVM � DataContext# [  5   	    � Title$ ForgetPassView��5   	   $	��450��6    $	��550��6-   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions.	 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  
   Command
 6$   �� *movewd+   CommandParameter 5   4   ��  �� ElementName$ 	Forgetpwd��6i   5      .��5      �� ���#E7E7E7$��4q�5   	    �� CornerRadius$ 15��5   	   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #FFE5D8��6    � Offset$ 0Q�6/   � 5      $ #FFCA08��6   $ 1Q�6/   5      ._�5!   
   �  � RowDefinitions 5"      �� 5#      $��30 �6    �� 5$      .+�5&      � $��0��6   .+�5'      �� $��0,5,0,0q�6   $��Right=�6.    �� Orientation$ 
Horizontal=�6J   .+�5(      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6.   
���   �$��20��6W   $��20��6c   $��0,0,8,0q�6n    5)        5*      $ MouseLeftButtonDown��6-   .	 5+   "     
 68   �� *
Minimizewd+ 5,      �� $ 	Forgetpwd��6A   5-      5/        50      $ 
CloseThick=�6.   
���   �$��20��6S   $��20��6_   $��0,0,5,0q�6j    51        52      $ MouseLeftButtonDown��6-   .	 53   "     
 68   �� *	Closewd+ 54      �� $ 	Forgetpwd��6A   55      57      58      59      � 5:      $��1��6   .+�5;      #  MaterialDesignThemes.Wpf.Card  $��10,10,10,25q�6&   $��1��6;   $	��450��6H   $	��300��6T   $��Center=�6a   $��Center=�6~   $��1��6�   .��5<      �� $��Center=�6!   $��	0,20,0,44q�6>   $	��356��6Q   .+�5=      �� $��	0,30,0,15q�6$   $��QUÊN MẬT KHẨU��67   $
��Bold"�6L    
 Custom#��[ 6^   $��27(�6�   $��Center=�6�   ���#FFCA086�   �� 5>      $��45��5?   !   $	��355��5@   !   
�������$��2q�5B   !   ���#FFCA08$ 5��5D   !   $��0,30,0,5q�5E   !   ._�5G      �� -   5         ��Name$
 mail��5O   !   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Nhập email đã đăng ký !��5G   &   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5H   !   $��0q�5I   !      UnderlineBrush
 ���� $��Center=�5K   !   $��Bottom=�5L   !    �� TextAlignment$ Center=�5M   !   $��15(�5N   !   $	��350��5O   /   $��35��6;   5Q      �� 5R      $��LẤY LẠI MẬT KHẨU��6!    �� 	IsDefault . $��0,10,0,0q�5T      $��40��5U      $	��355��5V      ���#FFCA08
���   �
������ #��[ 5Z       5\        5]   "   $ Click��61   .	 5^   &     
 6<   �� *
SendPass+ 5_   $   �� $ 	Forgetpwd��6Y   5`   #   5b      5c      5d      5e      5f      5g      5h      