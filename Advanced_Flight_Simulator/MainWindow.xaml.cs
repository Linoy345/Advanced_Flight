using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("Start all");
                int port =5400;
                string host = "127.0.0.1";
                Socket s = new Socket(AddressFamily.InterNetwork,
                     SocketType.Stream, ProtocolType.Tcp);

                Console.WriteLine("Establishing Connection to {0}",
                    host);
                s.Connect(host, port);
                Console.WriteLine("Connection established");
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);


                string fileName = "C:/Users/adamp/source/repos/Advanced_Flight_Simulator/Advanced_Flight_Simulator/reg_flight.csv";
                using (var reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("Start send");
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(line);
                        s.Send(msg);
                        Console.WriteLine(msg);
                        Console.WriteLine(line);
                        Console.WriteLine("End send");
                        Thread.Sleep(100);


                    }
                }

            }
            catch (Exception e1)
            {
                Console.WriteLine("Error..... " + e1.StackTrace);
            }
        }
    }
}
