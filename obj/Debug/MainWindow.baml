   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?SQClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SQClientSQClient 5   	      SQClient.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   (localclr-namespace:SQClient     5   	     � Title$  SQClient��5   	   $	��700��6   $
��1300��6'    [� ShowsNavigationUI .   � TaskbarItemInfo 5
      *  $System.Windows.Shell.TaskbarItemInfo  5   
      ProgressState$ Normal=�6   ��5      � 5   
    � ColumnDefinitions 5      �� 5      $
��0.2* �6#   $	��100��60   �� 5      $
��Auto �6#   �� 5      $
��0.8* �6#   $	��100��60   .+�5      �� $��0��6    � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '��       �� 5      " ��6   .�5      ��  � ��$ 12q�63   5      5      .+�5      �� �� 5      $"��Pages/DisplayDataStream.xaml?�6    	 �� 
TargetName$	 frame��6K   .�6^   	数据流5       5!      �� 5#      �� 5$      $#��Pages/SendAndReceiveJpeg.xaml?�6    $	 frame��6L   .�6_   
收发JPEG5&      5'      5(      �� 5*      $��1��6   $��4��6+   $��Stretch=�65   $��Center=�6Q    � 5,      -   5        $��frame��5,      $��2��6!   
  � Source$"
 Pages/DisplayDataStream.xaml?�61   5-      50      