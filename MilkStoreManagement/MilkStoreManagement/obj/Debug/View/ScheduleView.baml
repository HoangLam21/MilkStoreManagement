   M S B A M L   `   `   `  ����N  JMilkStoreManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MilkStoreManagement.ViewMilkStoreManagement.View  5      +    %MilkStoreManagement.View.ScheduleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MilkStoreManagement.View     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      -   5          N�Name$  
Schedulewd��5       N� 
Background
 ����    
ScheduleVM � DataContext# [  5      $	��800��5      $
��1170��6   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *
LoadSchewd+   CommandParameter 5   $   ��  �� ElementName$ 
Schedulewd��5      .��5      �� $��15,100,15,0q�6   ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      6%   �� 5      $	��400 �6#   61   .+�5      � $��0��6   .+�5      �� 
 �� CornerRadius$
 40��6   $	��685��5      
�������$	��Top=�5      $��0,0,10,0q�5       J� Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!         	Direction$	 320Q�6+      ShadowDepth$ 5Q�6;      
BlurRadius$ 10Q�6K      Color$ #FFCA08��6[      Opacity$
 0.25Q�6k   ._�5#      �  � RowDefinitions 5$      �� 5%      $��65 �6,   6:   �� 5&      $��80 �6,   6:   �� 5'      $��60 �6,   6:   �� 5(      6.   .+�5*      � $��0��6   .+�5+      �� $��Lịch làm việc��6(   $��24(�5,   !    
 Custom#��[ 6/   ���#747474$��41 10q�5-   6   5.      �� 5/      $
��1.75��6%   $	��670��63   $��Bottom=�6?   ���#fff2c16[   50      � 51      $��1��6   .+�52      �� $
 30��6%   $��60��53   %   $	��130��61   $
��0.75q�54   %   
�������$��20,0,0,0q�55   8   $
��Left=�56   %    57   "     58   &   $	 320Q�67   $ 5Q�6G   $ 10Q�6W   $ #FFCA08��6g   $
 0.25Q�6w   ._�5:   "   �� -   5         ��Name$ cbxChon��5:   +      MaterialDesignFilledComboBox#��[ 5;   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm Kiếm��5<   %   .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 	20,-5,0,0q�5=   %      DecorationVisibility$ Hidden=�5>   %   $��0q�5?   %      
FontFamily# [ 5@   %      
Foreground �#ffca08
������ #��[ 5C   %   $��15(�5D   %   $��60��63   ��5E   %   �� *listTK+��5F   &   �� 5G   *   .R�5H   .   ��  �� Orientation$ 
Horizontal=�69   .+�5I   2   �� ��6<   �� 5J   /   5K   +   5M   #   5N      �� 5O      $
 30��6%   $��60��5P   !   $	��300��6-   
�������$
��Left=�5Q   4   $��Center=�5R   !   $
��0.75q�5S   !   $��	170,0,0,0q�68    5T   "     5U   &   $	 320Q�67   $ 5Q�6G   $ 10Q�6W   $ #FFCA08��6g   $
 0.25Q�6w   ._�5W   "   �� -   5         ��Name$ 	txbSearch��5W   *   
������ $��40��5Y   %   $��	40,0,45,0q�5Z   %   
�������
���   �$��20(�5]   %   $��Center=�63   $ Tìm Kiếm��5^   %   # [ 5_   %   
 �   �   TextFieldCornerRadius$ 10��5a   %   $ Hidden=�5b   %   $��0q�5c   %   .��69    5d   &     5e   *   $ TextChanged��69   . 5f   .      6D   �� *SearchCommand+ 5g   8   �� $ 
Schedulewd��6n   5h   +   .��5i   >   5j   #   5k      '  !MaterialDesignThemes.Wpf.PackIcon  5l         Kind$ Magnify=�66   $��35��5m   !   $��35��6-   $��Center=�5n   !   ���#ffca08$
��Left=�5p   !   $��	425,0,0,0q�5q   !   5r      �� 5s      -   5         ��Name$ 	btnUpdate��5s   %   $	��123��5t   !   $��52��6-   $��0q�5u   !   $��	512,0,0,0q�5v   !   $��20(�5w   !   $y�Hidden=�5x   !   ���	#FF777777$
��Left=�5z   !   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 15��5{   !   #��[ 5|   !   ��5}   "   �� 5~   &    �� 
StartPoint$	 0,0&�6:    �� EndPoint$ 1.5,0&�6K   .��5   *   �   � Color$  #FFCA08��67   ! � Offset$! 0Q�6G   � 5�   *   $  White��67   $! 1Q�6E   5�   '    5�   "     5�   &   $ 5Q�67   $ white��6G   $	 0.5Q�6U   $ 5Q�6c   .��5�   1   Cập nhật 5�   "     5�   &   $ Click��65   . 5�   *      6@   �� *Update+ 5�   8   �� $ 
Schedulewd��6n   5�   '   5�      �� 5�      $��70��6%   $��60��60   $��0q�5�   !   
���   �$��0,0,10,0q�5�   !   $��19(�5�   !   
������ $��Right=�5�   !   $��Center=�6=   #��[ 5�   !   .��5�   "     $ Printer=�5�   %   
���   �$��45��5�   %   $��45��61   $��0,10,0,0q�6<   $��Center=�5�   %   $��Center=�5�   %   5�   #    5�   "     5�   &   $ Click��65   . 5�   *      6@   �� *Print+ 5�   9   �� $ 
Schedulewd��5�   '   5�      5�      �� 5�      $��2��6!   $��0,10,0,0q�6.   ���#faf2d4$
 30, 30, 0, 0��6U   ._�5�      � 	 5�   "   �� 5�   &   $	��159 �67   �� 5�   &   $��95 �67   �� 5�   &   $	��225 �67   �� 5�   &   69   .+�5�   "   � $��0��6'   .+�5�   &   �� $��Thứ��60   " �� TextAlignment$" Center=�5�   )   ���	#FF777777$��Center=�5�   )   $��Center=�5�   )   $	��155��6D   #��[ 5�   )   $��21(�5�   )   5�   #   � 5�   "   $��1��6'   .+�5�   &   �� $��Center=�5�   )   $��Ca��5�   )   $��19,0,0,0q�5�   )   ���	#FF777777$��Center=�5�   )   #��[ 5�   )   $��21(�5�   )   $��35��67   5�   #   � 5�   "   $��2��6'   .+�5�   &   �� $��Mã nhân viên��5�   )   ���	#FF777777$��Center=�5�   )   $��Center=�5�   )   $��15,0,0,0q�6D   #��[ 5�   )   $��21(�5�   )   5�   #   � 5�   "   $��3��6'   .+�5�   &   �� $��Tên nhân viên��5�   )   ���	#FF777777$
��Left=�5�   )   $��Center=�5�   )   $��40,0,0,0q�6D   #��[ 5�   )   $��21(�5�   )   5�   #   5�      5�      � 5�      $��3��6   .+�5�      �� -   5        # ��Name$# ListViewLLV��5�   '   $ �� SelectionMode$$ Single=�5�   )   $��Disabled=�5�   )   $��Hidden=�5�   )   $��2q�6[   ��5�   <   �� *	listLLV+��5�   "   �� 5�   &   % �� 
TargetType"% ��6,   .�5�   *   �� & �� Property& � ��' �� Value' 5�   .   �� 5�   2   ( �� 
TargetType"( ��6B   .R�5�   6   �� ) ��Name$) 
ItemBorder��6=   
������ $	��720��5�   =   $��42��5�   =   $��Center=�5�   =   $��Center=�6Z   $
 25��5�   =   $��4,0,4,0q�6O   ._�5�   :   � 	 5�   >   �� 5�   B   $	��159 �6S   �� 5�   B   $��95 �6S   �� 5�   B   $	��225 �6S   �� 5�   B   6U   .+�5�   >   � $��0��6C   .+�5�   B   �� $" Center=�5�   I   $��Center=�5�   I   $��Center=�5�   I   #��[ 5�   I   $��16(�5�   I   $	��159��6W   ��5�   I   �� *THU+5�   W   5�   ?   � 5�   >   $��1��6C   .+�5�   B   �� $��Center=�5�   I   $��Center=�5�   I   #��[ 5�   I   $��16(�5�   I   ��5�   I   �� *CA+5�   I   5�   ?   � 5�   >   $��2��6C   .+�5�   B   �� $" Center=�5�   I   $��Center=�5�   I   $��Center=�5�   I   $��16(�6d   #��[ 5   I   ��5�   I   �� *MANV+5   I   5  ?   � 5  >   $��3��6C   .+�5  B   �� $��25,0,0,0q�6L   $
��Left=�5  I   $
��Wrap=�5  I   $��Center=�5  I   $��16(�6d   #��[ 5  I   ��5  I   �� *TENNV+5  I   5	  ?   5
  ;   5  7   * �� Triggers* 5  6   P� 5  :   + P� Property+ �@J�IsMouseOver, P� Value, . . �5  >   �� - �� 
TargetName$- 
ItemBorder��6E   & � ��' �#FFF7DA6s   5  ;   P� 5  :   + �@��
IsSelected, . . �5  >   �� $- 
ItemBorder��6E   & � ��' �#FFF7DA6s   5  ;   5  3   5  +   5  '   ��5  "   �� 5  &   .R�5  *   � . � Orientation$. Vertical=�64   5  '    5  "     5  &   $ Loaded��65   . 5   *      6@   �� *	LoadLLV+ 5!  1   �� $ 
Schedulewd��6g   5"  '   5$     5%     5&     5'     5(     � 5)     $��1��6   .+�5*     �� $
 40��6   $	��685��5+     
�������$	��Top=�5-     $��15,0,0,0q�5.      5/       50     $	 320Q�6+   $ 5Q�6;   $ 10Q�6K   $ #FFCA08��6[   $
 0.25Q�6k   ._�52     �  53     �� 54     $��65 �6,   6:   �� 55     6.   .+�57     � $��0��6   .+�58     �� $��Lịch��6(   $��24(�59  !   #��[ 6/   ���#747474$��41 10q�5:  6   5;     �� 5<     $
��1.75��6%   $	��320��63   $��Bottom=�6?   ���#fff2c16[   5=     � 5>     $��1��6    5?     �� 5@  "   $	��390 �60   6?   �� 5A  "   62   .+�5C     �� $
 30��6%   $	��380��5D  !   $
��0.75q�5E  !   ���#ffca08$��
10,15,10,0q�5F  7   ��5G  "   �� 5H  &   $ 0.5,1&�6:   $ 0.8,0&�6K   .��5I  *   � $  #fae187��67   $! 0Q�6G   � 5J  *   $  white��67   $! 1Q�6E   5K  '   ._�5M  "   &
   System.Windows.Controls.Calendar
  $��0,5,0,0q�6+   $��0��6<     CalendarStyle1#���  5N  !     CalendarButtonStyle1/ 
  CalendarButtonStyle#/ �  5O  !     CalendarItemStyle10 
  CalendarItemStyle#0 �  5P  !     CalendarDayButtonStyle11 
  CalendarDayButtonStyle#1 �  5Q  !   $��Center=�6d   5R  #   5S     � 5T     $��1��6#   $��40,30,30,30q�60    5U  "   �� 5V  &   $��45 �64   �� 5W  &   $��40 �64   �� 5X  &   $��40 �64   �� 5Y  &   $��40 �64   	 5[  "   �� 5\  &   $��80 �67   �� 5]  &   $
��Auto �67   .+�5_  "   �� $��0��6,   $��0��69   $��Ca��5`  ,   $��25(�66   #��[ 6D   $��Center=�5a  ,   $��Center=�6G   5b  #   �� 5c  "   $��0��6,   $��1��69   $��65,0,0,0q�6I   $��Thời gian��5d  ,   $��25(�6=   #��[ 6K   $��Center=�5e  ,   5f  #   �� 5g  "   $��1��6,   $��0��69   ���	#FF777777$��1��5i  ,   $��20(�65   #��[ 6C   $��Center=�5j  ,   $��Center=�6G   5k  #   �� 5l  "   $��1��6,   $��1��69   $��50,0,0,0q�6I   ���	#FF777777$��7h - 12h��5n  ,   $��20(�6<   #��[ 6J   $��Center=�5o  ,   $��Center=�6G   5p  #   �� 5q  "   $��2��6,   $��0��69   ���	#FF777777$��2��5s  ,   $��20(�65   #��[ 6C   $��Center=�5t  ,   $��Center=�6G   5u  #   �� 5v  "   $��2��6,   $��1��69   $��50,0,0,0q�6I   ���	#FF777777$��12h30 - 17h30��5x  ,   $��20(�6A   #��[ 6O   $��Center=�5y  ,   $��Center=�6G   5z  #   �� 5{  "   $��3��6,   $��0��69   ���	#FF777777$��3��5}  ,   $��20(�65   #��[ 6C   $��Center=�5~  ,   $��Center=�6G   5  #   �� 5�  "   $��3��6,   $��1��69   $��50,0,0,0q�6I   ���	#FF777777$��18h - 22h30��5�  ,   $��20(�6?   #��[ 6M   $��Center=�5�  ,   $��Center=�6G   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     