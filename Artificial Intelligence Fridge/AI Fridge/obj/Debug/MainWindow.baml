   M S B A M L   `   `   `  ����D  @AI Fridge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AI_Fridge	AI_Fridge  5   	       AI_Fridge.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AI_Fridge     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��342* �6   �� 5      $	��13* �6   �� 5      $	��41* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FF0B1A34��6   $ 1Q�61   5      .+�5   
   �� $
��Left=�6   $��
289,28,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��83��6o   $	��266��6{   $��22(�6�   
���   �$
��Bold"�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF59811F��6#   �� 5   !   $�Welcome To AI Fridge��6%   .�6A   ��5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ Black��6'   $ 0Q�65   � 5      $ 	#FF339AE2��6'   $ 1Q�69   5      .�5   "   5      6   �� 5    
   $
��Left=�6   $��207,129,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $	��131��6p   $��32��6|   $��22(�6�   $��Segoe UI Black)�6�   �� 6�   $�User Name		��6�   .�6�   ��5!      �� 5"      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5#      � $ Black��6'   $ 0Q�65   � 5$      $ 	#FF339AE2��6'   $ 1Q�69   5%      .�5&   "   5'      �� 6   �� 6    $� ��6$   .�6,   ��5(      �� 5)      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5*      � $ Black��6'   $ 0Q�65   � 5+      $	 Red��6'   $ 1Q�63   5,      .�5-   "   5.      6   �� 5/   
   $
��Left=�6   $��207,204,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $	��110��6p   $��32��6|   $��22(�6�   $��Segoe UI Black)�6�   �� 6�   $�Password��6�   .�6�   ��50      �� 51      $ 0.5,1&�6*   $ 0.5,0&�6;   .��52      � $ Black��6'   $ 0Q�65   � 53      $ 	#FF2D9AE6��6'   $ 1Q�69   54      .�55   "   56      6   �� 57   
   -   5         ��Name$ btnLog��57      $��Login��6!   $
��Left=�61   $��226,297,0,0q�6L   $	��Top=�6a   $	��112��6y   ���	#FF055D9B$��37��6�   $��22(�6�   $��Segoe UI Black)�6�   �� 58   
   -   5        $ btnLog_Copy��58      $��Forgot Password?��6&   $
��Left=�6A   $��434,297,0,0q�6\   $	��Top=�6q   $	��197��6�   ���	#FF055D9B$��37��6�   $��22(�6�   $��Segoe UI Black)�6�   �� 59   
   -   5        	 ��Name$	 textbox1��59      $
��Left=�6$   $��32��6?   $��450,129,0,0q�6K   
 �� TextWrapping$

 Wrap=�6`   $	��Top=�6t   $	��189��6�   $��18(�6�   6�   �� 5:   
   -   5        $	 textbox2��5:      $
��Left=�6$   $��32��6?   $��450,204,0,0q�6K   $

 Wrap=�6`   $	��Top=�6t   $	��189��6�   $��18(�6�   6�   5<      5=      