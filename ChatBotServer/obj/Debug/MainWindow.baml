   M S B A M L   `   `   `  ����H  DChatBotServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ChatBotServerChatBotServer  5   	       ChatBotServer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ChatBotServer     5   	     � Title$  Chatbot Server��5   	   $
��Auto��6    $��731.622��6.    � SizeToContent$ WidthAndHeight=�6>   .��5	      � .+�5
   
   �� -   5         ��Name$ 
lblDisplay��5
      $��Server is not running��6$   $
��Left=�6D   $��
311,10,0,0q�6_   $	��Top=�6s    J� RenderTransformOrigin$ 0.188,-0.709&�6�   �� 5   
   -   5        $ lblReceived��5      $��Chat messages��6%   $
��Left=�6=   $��
311,74,0,0q�6X   $	��Top=�6l   $ -0.317,0.454&�6�   �� 5   
   -   5         ��Name$ txtReceived��5      $
��Left=�6'   $	��170��6B   $��211,105,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��316��6�   $ 
0.163,0.69&�6�    �� 
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ btnRunServer��5      $��
Run Server��6'   $
��Left=�6<   $��
226,42,0,0q�6W   $	��Top=�6k   $��75��6�   $ 0.501,1.063&�6�   6�   �� 5   
   -   5        $ btnStopServer��5      $��Stop Server��6(   $
��Left=�6>   $��
422,41,0,0q�6Y   $	��Top=�6m   $��75��6�   $ 0.501,1.063&�6�   6�   �� 5   
   -   5        $ 
txtMessage��5      $
��Left=�6&   $��43��6A   $��263,290,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��202��6�   $ 0.527,-0.398&�6�   6�   �� 5   
   -   5        $ btnSend��5      $
��Send��6"   $
��Left=�61   $��342,347,0,0q�6L   $	��Top=�6a   $��58��6y   6�   �� 5   
   -   5        $ lblSentMessage��5      $��Last send message : ��6(   $
��Left=�6G   $��313,384,0,0q�6b   $	��Top=�6w   5      5      