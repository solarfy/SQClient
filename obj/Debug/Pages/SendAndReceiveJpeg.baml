   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      C ?SQClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SQClient.PagesSQClient.Pages 5      '   !SQClient.Pages.SendAndReceiveJpeg   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      .localclr-namespace:SQClient.Pages     5        N� Title$  Send And Receive Jpeg��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $&�� UART #8-bit#0-parity#1-stop#none��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 	comboPort��5      $	��120��6.   $��36��6:   $��5q�6F   $��Center=�6Q   ��5      �� 5       �� DataType" ��6'   .R�5      �� $��Center=�68   ��6$   �� 6\   5      5      d� 5      -   5         d�Name$ tglbtnConnect��5      $��88��66   $��36��6A   $��5q�6M   $��连接��6X    d� 	IsChecked$ FalseY�6|   �� 5      $��2��6   $��36��6)   $	��4,0q�65   
�������6B   �� 5      -   5         ��Name$ 
btnReceive��5      $��88��6-   $��36��68   $��10,0,0,0q�6D   $��
JPEG拍照��6V   {�.   � ToolTip$' !从AI模块接收一张JPEG图片��5      �� 5!      -   5        $��textblkTimer��5!      $��00:00:00��60   $��Center=�6@   $��16(�6[   $��10,0,0,0q�6i   �� 5#      -   5        $��	btnRgb565��5#      $��88��6*   $��36��65   $��10,0,0,0q�6A   $��RGB565��6S   $ 接收RGB565数据流��5$   V   {�6   �� 	 �� ElementName$	 
btnReceive��
 �� Path$
 	IsEnabled�6V   �� 5&      -   5        $��88��5&      $��36��6$   $��10,0,0,0q�60   $��
JPEGRGB565��6B   $F @接收一张经过JPEG压缩、解压处理后的RGB565数据流��5'   V   
 � Tag$
 JPEG��5(      {�5'      �� $	 
btnReceive��$
 	IsEnabled�5(      �� 5*      -   5        $��88��5*      $��36��6$   $��10,0,0,0q�60   $��录入RGB565��6B   $= 7将选择的JPEG图片解码至RGB565流，录入设备��5+   V   {�6   �� $	 
btnReceive��$
 	IsEnabled�6V   5,      5-      �� 5/   
   $��1��6   $��内容��6    .��50      �� $��Center=�6   .+�51      �� -   5        $	��img��51      $	��320��6#   $	��240��6/   $
��None=�6<   $��0,12,0,0q�6K   � 52      -	   5        $��procbar��52      $��8��6-   $	��320��68   $
��0,12q�6D   
��� � � � Value$ 0Q�53   "   $��0q�6,   ��52   R   Z� 53   ,   �� 54      -
   5        $��	btnSaveAs��54      $��88��6*   $��36��65   $��图片另存��6B   $y�Hidden=�6k   55      56      57      58      