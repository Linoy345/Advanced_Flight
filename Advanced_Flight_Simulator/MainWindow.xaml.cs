using System;
using System.Windows;
using System.Data;
using System.Net.Sockets;

namespace Advanced_Flight_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();

        }

        private void Connect_botton(object sender1, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Ip.Text) && !String.IsNullOrEmpty(Port.Text))
                {
                    DisplayWindow displayWindow = new DisplayWindow(Ip.Text, Port.Text);
                    displayWindow.Show();
                }
            }
            catch (FormatException)
            {
                errorMessage("Invalid IP or PORT");
            }
            catch (InvalidOperationException)
            {
                errorMessage("Invalid IP or PORT");
            }
            catch (ArgumentOutOfRangeException)
            {
                errorMessage("Invalid IP or PORT");
            }
            catch (SocketException)
            {
                errorMessage("Connection Error");
            }

        }
        public void errorMessage(string message)
        {
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(message, "Remainder - FlightGear", MessageBoxButton.OK, icon);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayWindow displayWindow = new DisplayWindow();
            displayWindow.Show();
        }
    }
}