   M S B A M L   `   `   `  ����H  DChatBotClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ChatBotClientChatBotClient  5   	       ChatBotClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ChatBotClient     5   	     � Title$  Chatbot Client��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ lblIpAddress��5
      $��
IP Address��6&   $
��Left=�6;   $��
241,21,0,0q�6V   $	��Top=�6j    J� RenderTransformOrigin$ 0.448,-0.214&�6�   �� 5   
   -   5         ��Name$ txtIpAddress��5      $
��Left=�6(   $��23��6C   $��
345,24,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��145��6�   6�   �� 5   
   -   5         ��Name$ 
btnConnect��5      $��Connect��6%   $
��Left=�67   $��
533,24,0,0q�6R   $	��Top=�6f   $��61��6~   $ 0.549,3.769&�6�   �� 5   
   -   5        $ 
lblMessage��5      $��Chat Message��6$   $
��Left=�6;   $��
356,94,0,0q�6V   $	��Top=�6j   $ -0.317,0.454&�6�   �� 5   
   -   5        $ txtMessageToSend��5      $
��Left=�6,   $��36��6G   $��288,302,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��256��6�   $ 
0.163,0.69&�6�   6�   �� 5   
   -   5        $ btnSend��5      $
��Send��6"   $
��Left=�61   $��380,357,0,0q�6L   $	��Top=�6a   $��61��6y   $ 0.549,3.769&�6�   �� 5   
   -   5        $ 
lblDisplay��5      $��Connected to ��6$   $
��Left=�6<   $��
356,63,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ lblSentMessage��5      $��Sent message: ��6(   $
��Left=�6A   $��367,384,0,0q�6\   $	��Top=�6q   �� 5   
   -	   5        $ txtMessageRecevied��5      $
��Left=�6.   $	��137��6I   $��241,125,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��329��6�    �� 
IsReadOnly . 6�   5      5      