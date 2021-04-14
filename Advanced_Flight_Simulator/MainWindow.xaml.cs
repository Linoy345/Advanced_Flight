using System;
using System.Windows;
using System.Data;
using System.Net.Sockets;

namespace Advanced_Flight_Simulator
{
    /***
   * the class MainWindow inherit from the class Window.
   * in this window will shown the the first window in the program. 
   * in this window the user will choose ip and port and will open the flightgear application.
   ***/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /***
         * the function Connect_botton represent the pressing on the connect button and show the displaywindow.
         ***/
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
        /***
         * the function errorMessage will represent message of error to the user if he did any mistake.
         ***/
        public void errorMessage(string message)
        {
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(message, "FlightGear", MessageBoxButton.OK, icon);
        }
        /***
        * the function Button_Click will present the pressing on the connect button and show the displaywindow.
        ***/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayWindow displayWindow = new DisplayWindow();
            displayWindow.Show();
        }
    }
}