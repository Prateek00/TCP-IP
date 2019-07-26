using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ChatBotClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PORT = 11000;
        private string alertMessage;
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;
        private Byte[] bytes = new Byte[256];
        private string dataReceived;
        private Regex ipAddressVerificationRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");


        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializePlatform();
        }

        private void InitializePlatform()
        {
            this.lblMessage.Visibility = Visibility.Hidden;
            this.txtMessageToSend.Visibility = Visibility.Hidden;
            this.btnSend.Visibility = Visibility.Hidden;
            this.lblDisplay.Visibility = Visibility.Hidden;
            this.lblSentMessage.Visibility = Visibility.Hidden;
            this.txtMessageRecevied.Visibility = Visibility.Hidden;
         

            this.txtMessageToSend.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtMessageRecevied.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtMessageRecevied.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.txtMessageToSend.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;

            this.btnSend.IsEnabled = false;
        }




        private async void OnConnectClick(object sender, RoutedEventArgs e)
        {
            this.alertMessage = string.Empty;
            if (!(this.ipAddressVerificationRegex.IsMatch(this.txtIpAddress.Text)))
            {
                this.alertMessage = string.Format("{0} Please enter a valid IP Address\n", this.alertMessage);
                MessageBox.Show(this.alertMessage);
            }

            else
            {
               await this.Connect();
            }
        }

        private async Task Connect()
        {
            
            try
             {
                this.tcpClient = new TcpClient(this.txtIpAddress.Text,PORT);
                Console.WriteLine("Connection Successfull to {0}\n", this.tcpClient.Client.RemoteEndPoint);
                this.lblDisplay.Content = "Connected to " + this.tcpClient.Client.RemoteEndPoint.ToString();
                this.stream = this.tcpClient.GetStream();
                

                this.btnConnect.Visibility = Visibility.Hidden;
                this.txtIpAddress.Visibility = Visibility.Hidden;
                this.lblIpAddress.Visibility = Visibility.Hidden;

                this.txtMessageRecevied.Visibility = Visibility.Visible;
                this.lblDisplay.Visibility = Visibility.Visible;
                this.lblMessage.Visibility = Visibility.Visible;
                this.txtMessageToSend.Visibility = Visibility.Visible;
                this.btnSend.Visibility = Visibility.Visible;

                int count;
                while ((count = await this.stream.ReadAsync(this.bytes, 0, this.bytes.Length)) != 0)
                {
                    this.dataReceived = Encoding.ASCII.GetString(this.bytes, 0, count);
                    this.txtMessageRecevied.Text += this.tcpClient.Client.RemoteEndPoint + " : " + this.dataReceived + "\n";
                }

            }
            catch (Exception exception)
            {
                this.lblDisplay.Content = "Connection to " + this.tcpClient.Client.RemoteEndPoint.ToString() + "failed";
                Console.WriteLine(exception);
            }
        }

        private void OnMessageTextChange(object sender, TextChangedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(this.txtMessageToSend.Text)))
                this.btnSend.IsEnabled = true;
            else
                this.btnSend.IsEnabled = false;
        }

        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            this.lblSentMessage.Visibility = Visibility.Visible;
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(this.txtMessageToSend.Text);
            this.stream.WriteAsync(data, 0, data.Length).Wait();
            this.txtMessageRecevied.Text += " You : " + this.txtMessageToSend.Text + "\n"; 
            Console.WriteLine("Message sent {0}\n", this.txtMessageToSend.Text);
            this.lblSentMessage.Content = "Last sent message : " + this.txtMessageToSend.Text;
            this.txtMessageToSend.Text = string.Empty;
        }

        private void OnIpAddressTextChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtIpAddress.Text))
                this.btnConnect.IsEnabled = true;
            else
                this.btnConnect.IsEnabled = false;
        }
    }
}
