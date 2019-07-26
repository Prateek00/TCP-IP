using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Sockets;
using System.Net;

namespace ChatBotServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PORT = 11000;
        private TcpListener tcp_ip_listener = null;
        private TcpClient tcpClient = null;
        private Byte[] bytes = new Byte[256];
        private string dataReceived = null;

        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializePlatform();
        }

        /// <summary>
        /// On form load the structure of page.
        /// </summary>
        private void InitializePlatform()
        {
            this.lblReceived.Visibility = Visibility.Hidden;
            this.txtReceived.Visibility = Visibility.Hidden;
            this.lblReceived.Visibility = Visibility.Hidden;
            this.txtMessage.Visibility = Visibility.Hidden;
            this.btnSend.Visibility = Visibility.Hidden;
            this.lblSentMessage.Visibility = Visibility.Hidden;

            this.txtReceived.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtReceived.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtMessage.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtMessage.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;

            this.btnStopServer.IsEnabled = false;
            this.btnSend.IsEnabled = false;
        }

        /// <summary>
        /// start listening for client in asynchronous way.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnRunServerClickAsync(object sender, RoutedEventArgs e)
        {
           await this.StartServerAsync();
        }

        private async Task StartServerAsync()
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse("192.168.1.38");
                this.tcp_ip_listener = new TcpListener(iPAddress, PORT);
                this.tcp_ip_listener.Start();

                Console.WriteLine("Server is running at port {0}\n", PORT);
                Console.WriteLine("Local endPoint is {0}\n", this.tcp_ip_listener.LocalEndpoint);
                Console.WriteLine("Waiting for the connection");

                this.lblDisplay.Content = "Waiting For Connection";
                
                this.btnStopServer.IsEnabled = true;
                this.btnRunServer.IsEnabled = false;

                this.tcpClient = await this.tcp_ip_listener.AcceptTcpClientAsync();

                this.lblReceived.Visibility = Visibility.Visible;
                this.txtReceived.Visibility = Visibility.Visible;
                this.txtMessage.Visibility = Visibility.Visible;
                this.btnSend.Visibility = Visibility.Visible;
                this.lblSentMessage.Visibility = Visibility.Visible;

                Console.WriteLine("Connection established {0}\n", this.tcpClient.Client.RemoteEndPoint);
                this.lblDisplay.Content = "Connection established to " + this.tcpClient.Client.RemoteEndPoint;

                int count;
                while ((count = await this.tcpClient.GetStream().ReadAsync(this.bytes, 0, this.bytes.Length)) != 0)
                {
                    this.dataReceived = Encoding.ASCII.GetString(this.bytes, 0, count);
                    this.txtReceived.Text += this.tcpClient.Client.RemoteEndPoint + " : " + this.dataReceived + "\n";
                }


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(string.Format("There is some error, server not listening at port number {0}\n", PORT));
            }
        }

       /// <summary>
       /// stoping the server.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void OnStopServerClick(object sender, RoutedEventArgs e)
        {
            this.tcpClient.Close();
            this.tcp_ip_listener.Stop();
            this.txtReceived.Text = string.Empty;
            this.lblDisplay.Content = "Server is not running";
            this.btnRunServer.IsEnabled = true;
            this.btnStopServer.IsEnabled = false;
        }

        private void OnTextMessageChange(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtMessage.Text))
                this.btnSend.IsEnabled = false;
            else
                this.btnSend.IsEnabled = true;
        }

        /// <summary>
        /// Sending the message to the client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            Byte[] byteToSend = new Byte[256];
            byteToSend = Encoding.ASCII.GetBytes(this.txtMessage.Text);
            this.tcpClient.GetStream().WriteAsync(byteToSend,0,byteToSend.Length).Wait();
            this.txtReceived.Text +=  " You : " + this.txtMessage.Text + "\n";
            this.lblSentMessage.Content = "Last sent message : " + this.txtMessage.Text;
            this.txtMessage.Text = string.Empty;
        }
    }
}
